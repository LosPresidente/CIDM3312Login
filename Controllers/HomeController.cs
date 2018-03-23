using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Midterm.Models;

namespace Midterm.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
       /* public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }*/

        

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult Prihlaseni(){
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
/* 
        public IActionResult About(LoginViewModel loginViewModel){

            string name = "Karla";
            @ViewBag.Jmena = name;
            if(loginViewModel.Username == "cat@cat.cat"){
                loginViewModel.UserCorr = true;
            }else{
                loginViewModel.UserCorr = false;
            }

            if(loginViewModel.Password == "cat"){
                loginViewModel.PassCorr = true;
            }else{
                loginViewModel.PassCorr = false;
            }

            if((loginViewModel.UserCorr==true)&&(loginViewModel.PassCorr==true)){
                loginViewModel.Login = true;
            }else{
                loginViewModel.Login = false;
            }

            return View(loginViewModel);
        }
        */
    }
}
