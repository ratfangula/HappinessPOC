using HappinessPOC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HappinessPOC.Controllers
{
    public class CustomHappyItemsController : Controller
    {
        // GET: CustomHappyItems
        public ActionResult Index(HappinessRepository repo)
        {
            return View(repo.GetHappyItems().ToList());
        }
    }
}