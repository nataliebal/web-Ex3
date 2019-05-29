using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : Controller
    {
        private DataModel data;
        private MyServer server;
        public ProductsController()
        {
            data = DataModel.getInstance();
            server = MyServer.getInstance();
        }
        // GET: Products
        public ActionResult display()
        {
            data.Ip = "127.0.0.1";
            data.Port = 5400;
            server.connect_server(1);
            ViewBag.lon = data.Lon;
            ViewBag.lat = data.Lat;
            return View();
        }
    }
}