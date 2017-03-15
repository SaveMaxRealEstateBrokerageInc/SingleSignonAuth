using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SingleSignonAuth.Controllers
{
    public class UserController : ApiController
    {
        public ActionResult ManageAccount(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                string page = "~/" + id + ".html";
                return new FilePathResult(page, "text/html");
            }
            return new FilePathResult("~/html/login.html", "text/html");
        }
    }
}
