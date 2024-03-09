using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace progettoSettimanale_mvc2_backend.Models
{
    public class Admin
    {
        public string IdAdmin { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        public string Password { get; set; }
        public Admin() { }
        public Admin(string username, string password)
        {

            Username = username;
            Password = password;
        }
    }
}
