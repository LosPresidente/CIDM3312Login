using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Midterm.Models;

namespace Midterm.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        /* 
        public IActionResult Prihlaseni(){
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
*/
        [HttpGet]
        public ViewResult SignIN(){
            return View();
        }

        [HttpGet]
        public ViewResult SignUP(){
            return View();
        }


        [HttpPost]
        public ViewResult SignIN(string checkName, string checkPass, LoginViewModel loginViewModel){
            bool EmailCorr = false;
            bool PassCorr = false;
            bool PassLong = false;

            checkPass = loginViewModel.Password;
            checkName = loginViewModel.Username;
            char[] meno = checkName.ToCharArray();
            char[] heslo = checkPass.ToCharArray();

            int dylkaMena = meno.GetLength();
            int dylkaHesla = heslo.GetLength();
            
            if((meno[0] != '@') && ( meno[dylkaMena]!='.') ){
                EmailCorr = true;
            }

            if((dylkaHesla <=7)){
                PassLong = true;
            }


            
            foreach (var r in Repo.Users)
            {
                if(r.Username == loginViewModel.Username){
                    if(r.Password == loginViewModel.Password){
                        PassCorr = true;
                    }
                }
                
            }

         if((PassCorr==true)&&(EmailCorr==true)&&(PassLong==true) ){
                return View("SignGo", loginViewModel);
            }else{
                return View("SignNo", loginViewModel);
            }
            
        }

        [HttpPost]
        public ViewResult SignUP(LoginViewModel loginViewModel){
            Repo.AddUsers(loginViewModel);
            return View("SignIn");
        }



    }
}
