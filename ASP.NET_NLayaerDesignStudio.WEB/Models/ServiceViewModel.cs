using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.NET_NLayaerDesignStudio.WEB.Models
{
    public class ServiceViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? Price { get; set; }

        public string Img { get; set; }

    }
}