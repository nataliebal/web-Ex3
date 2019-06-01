using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
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
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult display(string ip, int port)
        {
            data.Ip = ip;
            data.Port = port;
            server.connect_server();
            server.open();
            ViewBag.lon = data.Lon;
            ViewBag.lat = data.Lat;
            return View();
        }

        [HttpGet]
        public ActionResult lineDisplay(string ip,int port,int time)
        {
            data.Ip = ip;
            data.Port = port;
            data.Time = time;
            server.connect_server();
            server.open();
            ViewBag.lon = data.Lon;
            ViewBag.lat = data.Lat;
            Session["time"] = time;
            return View();
        }
        [HttpPost]
        public void GetData()
        {
            server.open();
        }
    }
}