using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollection.Models;

namespace TrashCollection.Controllers
{
    public class BaseController : Controller
    {
        //private string _myString;
        //public int MyProperty { get; set; }
        //public string MyUpperCaseString { get { return _myString.ToUpper(); } }

        //public string MyLowerCaseString
        //{
        //    get { return _myString.ToLower(); }
        //    set { _myString = value; }
        //}

        public string UserId => User.Identity.GetUserId();

        public ApplicationDbContext Context => new ApplicationDbContext();

        public string GetUserId()
        {
            return User.Identity.GetUserId();
        }
    }
}