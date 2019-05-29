using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class DataModel
    {
        public static DataModel instance = null;
        private double lon1;
        private double lat1;
        private string ip;
        private int port;
        private DataModel() {
       
        }
        public static DataModel getInstance()
        {
            if (instance == null)
            {
                instance = new DataModel();
            }
            return instance;
        }
        public string Ip
        {
            get
            {
                return ip;
            }
            set
            {
                ip = value;
            }
        }
        public int Port
        {
            get
            {
                return port;
            }
            set
            {
                port = value;
            }
        }
        public double Lon
        {
            get
            {
                return lon1;
            }
            set
            {
                lon1 = value;
            }
        }
        public double Lat
        {
            get
            {
                return lat1;
            }
            set
            {
                lat1 = value;
            }
        }
    }
   
}