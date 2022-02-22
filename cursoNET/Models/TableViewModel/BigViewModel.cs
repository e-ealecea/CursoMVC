using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using cursoNET.Models;

namespace cursoNET.Models.TableViewModel
{
    public class BigViewModel
    {
        public List<UserTableViewModel> Users { get; set; }
        public List<SelectListItem> ListItemsCity { get; set; }
    }
}