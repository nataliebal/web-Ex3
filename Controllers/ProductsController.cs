using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading;
using WebApplication1.Models;
using System.Text;
using System.Xml;

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
            if (check(ip))
            {
                data.Ip = ip;
                data.Port = port;
                server.connect_server();
                server.open();
                ViewBag.lon = data.Lon;
                ViewBag.lat = data.Lat;
                return View("display");
            }
            else
            {
                data.Time = port;
                data.FileName = ip;
                data.initialize();
                Session["time"] = port;
                
                return View("Animation");
            }
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

        [HttpGet]
        public ActionResult save(string ip, int port, int time, int duration,string fileName)
        {
            data.Ip = ip;
            data.Port = port;
            data.Time = time;
            data.FileName = fileName;
            server.connect_server();
            server.open();
            ViewBag.lon = data.Lon;
            ViewBag.lat = data.Lat;
            ViewBag.eof = data.Eof;
            Session["time"] = time;
            Session["duration"] = duration;
            return View();
        }

        [HttpPost]
        public void GetData()
        {
            server.open();
        }

        [HttpPost]
        public void WriteToFile()
        {
            server.open();
            data.fileWriting();
        }

        [HttpPost]
        public string LoadFromFile()
        {
            data.fileReading();
            return ToXml();
        }

        public bool check(string ip)
        {
            string[] parts = ip.Split('.');
            if (parts.Length == 4) return true;
            return false;
        }

        private string ToXml()
        {
            //Initiate XML stuff
            StringBuilder sb = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings();
            XmlWriter writer = XmlWriter.Create(sb, settings);

            writer.WriteStartDocument();
            //writer.WriteStartElement("Val");

           data.ToXml(writer);

            //writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            return sb.ToString();
        }

    }
}