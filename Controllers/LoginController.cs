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
            bool UpperCase = false;
            bool Poradi = false;
            string emailIn = "Email Incorrect";
            string passShort = "Password too short";
            string passNoUp = "Password must contain uppcase letter";
            int prvni=0;
            int druhy=0;

            checkPass = loginViewModel.Password;
            checkName = loginViewModel.Username;
            char[] meno = checkName.ToCharArray();
            char[] heslo = checkPass.ToCharArray();

           // int dylkaMena = meno.Length();
           // int dylkaHesla = heslo.Length();
           for(int i = 0; i< meno.Length;i++){
               if(meno[i] == '@'){
                   prvni = i;
               }

               if(meno[i]=='.'){
                   druhy = i;
               }
           }
           if(prvni < druhy){
               Poradi = true;
           }
            
            if((meno[0] != '@') && ( meno.Length != '.') ){
                EmailCorr = true;
            }
            //this is for the email
            if(EmailCorr == false){
                ViewBag.EmailIncorrect = emailIn;
            }
 

            if((heslo.Length >= 8) ){
                PassLong = true;
            }

           //this is for the length of the password
            if(PassLong == false){
                ViewBag.PasswordShort = passShort;
            }


            for(int i = 0;i<heslo.Length;i++){
                if(char.IsUpper(heslo[i])){
                    UpperCase = true;
                }else{

                }
            }

                        //this for the uppercaseness of the password
            if(UpperCase == false){
                ViewBag.PasswordNoUp = passNoUp;
            }

            
            foreach (var r in Repo.Users)
            {
                if(r.Username == loginViewModel.Username){
                    if(r.Password == loginViewModel.Password){
                        PassCorr = true;
                    }
                }
                
            }

         if((PassCorr==true)&&(EmailCorr==true)&&(PassLong==true)&&(UpperCase==true)&&(Poradi==true) ){
                return View("SignGo", loginViewModel);
            }else{
                return View("SignNo", loginViewModel);
            }
            
        }

        [HttpPost]
        public ViewResult SignUP(string checkName, string checkPass,LoginViewModel loginViewModel){
            bool EmailCorr = false;
            bool PassCorr = false;
            bool PassLong = false;
            bool UpperCase = false;
            bool Poradi = false;
            string emailIn = "Email Incorrect";
            string passShort = "Password too short";
            string passNoUp = "Password must contain uppcase letter";
            int prvni=0;
            int druhy=0;

            checkPass = loginViewModel.Password;
            checkName = loginViewModel.Username;
            char[] meno = checkName.ToCharArray();
            char[] heslo = checkPass.ToCharArray();

           // int dylkaMena = meno.Length();
           // int dylkaHesla = heslo.Length();
           
           
            
            if((meno[0] != '@') && ( meno.Length != '.') ){
                EmailCorr = true;
            }

            for(int i = 0; i< meno.Length;i++){
               if(meno[i] == '@'){
                   prvni = i;
               }

               if(meno[i]=='.'){
                   druhy = i;
               }
           }
           if(prvni < druhy){
               Poradi = true;
           }else{
               EmailCorr=false;
           }

            //this is for the email
            if(EmailCorr == false){
                ViewBag.EmailIncorrect = emailIn;
            }
 

            if((heslo.Length >= 8) ){
                PassLong = true;
            }

           //this is for the length of the password
            if(PassLong == false){
                ViewBag.PasswordShort = passShort;
            }


            for(int i = 0;i<heslo.Length;i++){
                if(char.IsUpper(heslo[i])){
                    UpperCase = true;
                }else{

                }
            }

                        //this for the uppercaseness of the password
            if(UpperCase == false){
                ViewBag.PasswordNoUp = passNoUp;
            }

            /* 
            foreach (var r in Repo.Users)
            {
                if(r.Username == loginViewModel.Username){
                    if(r.Password == loginViewModel.Password){
                        PassCorr = true;
                    }
                }
                
            }
*/
         if(/*(PassCorr==true)&&*/(EmailCorr==true)&&(PassLong==true)&&(UpperCase==true)&&(Poradi==true) ){
                Repo.AddUsers(loginViewModel);
                return View("SignIn", loginViewModel);
            }else{
                return View("SignNo", loginViewModel);
            }



           // Repo.AddUsers(loginViewModel);
           // return View("SignIn");
        }



    }
}
