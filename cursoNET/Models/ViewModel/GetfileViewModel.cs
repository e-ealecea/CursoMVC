using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace cursoNET.Models.ViewModel
{
    public class GetfileViewModel
    {
     
        [Required]
        [Display(Name = "Archivo uno")]
        public HttpPostedFileBase PostedFile { get; set; }

        [Required]
        [Display(Name = "Archivo dos")]
        public HttpPostedFileBase PostedFile2 { get; set; }

        [Required]
        [Display(Name = "Cadena2")]
        public string FName { get; set; }

    }
}