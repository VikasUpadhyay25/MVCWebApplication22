using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWebApplication22.Models;

namespace MVCWebApplication22.Controllers
{
    //public class HomeController : Controller
    //{
    //    public ActionResult Index()
    //    {
    //        return View();
    //    }

    //    public ActionResult About()
    //    {
    //        ViewBag.Message = "Your application description page.";

    //        return View();
    //    }

    //    public ActionResult Contact()
    //    {
    //        ViewBag.Message = "Your contact page.";

    //        return View("Contact");
    //    }


    //    public ActionResult Create()
    //    {
    //        ViewBag.Message = "Your contact page.";

    //        return View(new Provider());
    //    }

    //[HttpPost]
    //    public ActionResult Create(Provider p)
    //    {
    //        if (ModelState.IsValid)
    //        {

    //            Provider newP = p;
    //            p.InsertProvider(p);
    //        }

    //        return RedirectToAction("ShowProviders");
    //    }

    //public ActionResult Edit(int? id, string name, string type)
    //{
    //    ViewBag.Message = "Your contact page.";

    //    return View(new Provider() { ProviderId = id ?? 0, ProviderType = type, ProviderName = name });
    //}

    //    public ActionResult Details(int? id)
    //    {
    //        ViewBag.Message = "Your contact page.";

    //        var result = Provider.GetProviderDataByProviderId(id ?? 0);


    //        Provider newP = new Provider()
    //        {
    //            ProviderId = Convert.ToInt32(result.Tables[0].Rows[0][0].ToString()),
    //            ProviderName = result.Tables[0].Rows[0]["ProviderName"].ToString(),
    //            ProviderType = result.Tables[0].Rows[0]["ProviderType"].ToString(),
    //            Address = result.Tables[0].Rows[0]["Address"].ToString(),
    //            City = result.Tables[0].Rows[0]["City"].ToString(),
    //            State = result.Tables[0].Rows[0]["State"].ToString(),

    //        };
    //        return View(newP);
    //    }

    //    public ActionResult Delete(int? id, string name, string type)
    //    {
    //        ViewBag.Message = "Your contact page.";

    //        return View(new Provider() { ProviderId = id ?? 0, ProviderType = type, ProviderName = name });
    //    }

    //[HttpPost]
    //public ActionResult Edit(Provider p)
    //{
    //    if (ModelState.IsValid)
    //    {

    //        Provider newP = p;
    //        p.UpdateProvider(p);
    //    }

    //    return RedirectToAction("ShowProviders");
    //}

    //    [HttpPost]
    //    public ActionResult Delete(Provider p)
    //    {
    //        if (ModelState.IsValid)
    //        {

    //            Provider.DeleteProvider(p.ProviderId);
    //        }

    //        return RedirectToAction("ShowProviders");
    //    }

    //    public ActionResult ShowProviders()
    //    {
    //        List<Provider> p = new List<Provider>();

    //        var dataTables = Provider.GetProviderData();

    //        foreach (DataRow data in dataTables.Tables[0].Rows)
    //        {
    //            //Provider newProvider = new Provider()
    //            //{
    //            //    ProviderId = Convert.ToInt32(data[0].ToString()),
    //            //    ProviderName = data[1].ToString(),
    //            //    ProviderType = data[2].ToString()
    //            //};

    //            //p.Add(newProvider);

    //            p.Add(new Provider()
    //            {
    //                ProviderId = Convert.ToInt32(data[0].ToString()),
    //                ProviderName = data[1].ToString(),
    //                ProviderType = data[2].ToString()
    //            });
    //        }

    //        return View(p);
    //    }
    //}





    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult ContactUs()
        //{
        //    Provider p = new Provider();
        //    //p.ProviderId = 12;
        //    //p.ProviderName = "Vikas";
        //    //p.ProviderType = "Claim";
        //    //ViewBag.Message = "Welcome to the Tata Group";

        //    var data = provider.GetProviderData();

        //    p.ProviderId = Convert.ToInt32(data.Tables[0].Rows[0][0].ToString());
        //    p.ProviderName = data.Tables[0].Rows[0][1].ToString();
        //    p.ProviderType = data.Tables[0].Rows[0][2].ToString();
        //    return View(p);
        //}

        public ActionResult Create()
        {
            ViewBag.Message = "Your contact page.";

            return View(new Provider());
        }

        [HttpPost]
        public ActionResult Create(Provider p)
        {
            if (ModelState.IsValid)
            {
                Provider newP = p;
                p.InsertProvider(p);
            }

            return RedirectToAction("ShowProvider");
        }

        public ActionResult Edit(int? id, string name, string type)
        {
            ViewBag.Message = "Your contact page.";

            return View(new Provider() { ProviderId = id ?? 0, ProviderType = type, ProviderName = name });
        }

        public ActionResult Delete(int? id, string name, string type)
        {
            ViewBag.Message = "Your contact page.";

            return View(new Provider() { ProviderId = id ?? 0, ProviderType = type, ProviderName = name });
        }



        public ActionResult ShowProvider()
        {
            List<Provider> p = new List<Provider>();

            var dataTables = Provider.GetProviderData();

            foreach (DataRow data in dataTables.Tables[0].Rows)
            {
                //Provider newProvider = new Provider()
                //{
                //    ProviderId = Convert.ToInt32(data[0].ToString()),
                //    ProviderName = data[1].ToString(),
                //    ProviderType = data[2].ToString()
                //};

                //p.Add(newProvider);

                p.Add(new Provider()
                {
                    ProviderId = Convert.ToInt32(data[0].ToString()),
                    ProviderName = data[1].ToString(),
                    ProviderType = data[2].ToString()
                });
            }
            return View(p);
        }

        [HttpPost]
        public ActionResult Edit(Provider p)
        {
            if (ModelState.IsValid)
            {

                Provider newP = p;
                p.UpdateProvider(p);
            }

            return RedirectToAction("ShowProvider");
        }

        [HttpPost]
        public ActionResult Delete(Provider p)
        {
            if (ModelState.IsValid)
            {

                Provider.DeleteProvider(p.ProviderId);
            }

            return RedirectToAction("ShowProvider");
        }

        public ActionResult Details(int? id)
        {
            ViewBag.Message = "Your contact page.";

            var result = Provider.GetProviderDataByProviderId(id ?? 0);


            Provider newP = new Provider()
            {
                ProviderId = Convert.ToInt32(result.Tables[0].Rows[0][0].ToString()),
                ProviderName = result.Tables[0].Rows[0]["ProviderName"].ToString(),
                ProviderType = result.Tables[0].Rows[0]["ProviderType"].ToString(),
                //Address = result.Tables[0].Rows[0]["Address"].ToString(),
                //City = result.Tables[0].Rows[0]["City"].ToString(),
                //State = result.Tables[0].Rows[0]["State"].ToString(),

            };
            return View(newP);
        }

        public ActionResult ProvidersDetails()
        {
            List<Provider> p = new List<Provider>();

            List<SelectListItem> providers = new List<SelectListItem>();

            var dataTables = Provider.GetProviderData();

            foreach (DataRow data in dataTables.Tables[0].Rows)
            {
                providers.Add(new SelectListItem()
                {
                    Text = data[1].ToString(),
                    Value = data[0].ToString()
                });
            }

            return View(providers);
        }

    }
}