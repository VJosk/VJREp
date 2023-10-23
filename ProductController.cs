using Microsoft.AspNetCore.Mvc;
    using System;
   

namespace ASp_Yank.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            // Add action logic here
            throw new NotImplementedException();
        }

        public ActionResult s(int Id)
        {

            return View("Details");
        }
    }
}
