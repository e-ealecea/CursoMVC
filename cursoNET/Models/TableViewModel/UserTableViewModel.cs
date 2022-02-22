using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace cursoNET.Models.TableViewModel
{
    public class UserTableViewModel
    {
        public int Id { get; set; }
        public string Email{get; set;}
        public int? Edad{ get; set; } //Como en la base de datos puede ser nulo se tiene que poner el ?
    }
}