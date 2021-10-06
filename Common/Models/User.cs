using Common.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class User : Person
    {
        
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public bool IsAdministrator { get; set; }

        
    }
}
