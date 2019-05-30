using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
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
            server.open(1);
            ViewBag.lon = data.Lon;
            ViewBag.lat = data.Lat;
            return View();
        }

        [HttpGet]
        public ActionResult lineDisplay(string ip,int port,int time)
        {
            data.Ip = ip;
            data.Port = port;
            server.connect_server();
            Task t = new Task(new Action(func));
            t.Start();
            //server.open(2);

            while (true)
            {
                if (server.set) break;
            }
            ViewBag.lon = data.Lon;
            ViewBag.lat = data.Lat;
            return View();
        }

        public void func()
        {
            server.open(2);
        }
    }
}