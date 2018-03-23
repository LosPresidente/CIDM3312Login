using System;


namespace Midterm.Models
{
    

    public class LoginViewModel
    {
            public LoginViewModel(string Username, string Password){
                this.Username = Username;
                this.Password = Password;
            }

            public LoginViewModel(){

            }

        public string Username {get;set;}


        public string Password {get;set;}

/* 
        public bool? UserCorr {get;set;}


        public bool PassCorr {get;set;}

 
        public bool Login {get;set;}
        */
    }
}