using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;

namespace FormAsAService.Controllers
{
    public class HomeController : Controller
    {
        FormAsAServiceDbContext db = new FormAsAServiceDbContext();

        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        // GET: /ManageFormTypes
        public ActionResult ManageFormTypes()
        {
            return View();
        }

        // GET: /ListFormTypes
        public ActionResult ListFormTypes()
        {
            return View();
        }

        // GET: /ListFormTypes
        public ActionResult FormTypesView()
        {
            // ako poslat do view list of objects ...typu z databaze ?
            var formTypes = db.FormTypes;
            return View(formTypes.ToList());
        }

        public ActionResult Edit (int? id)
        {
            if (id == null)
            {
                return View(new FormType());
            }

            FormType formTypes = db.FormTypes.Find(id);
            //FormType formTypes = from item in db.FormTypes
            //                  where item.Id == id
            //                  select new FormType
            //                  {
            //                      Name= item.Name, 
            //                      ElementTypes = item.ElementTypes.ToList(), 
            //                      Id = item.Id
            //                  };
            if (formTypes == null)
            {
                return HttpNotFound();
            }
            return View(formTypes);
        }
    }
}