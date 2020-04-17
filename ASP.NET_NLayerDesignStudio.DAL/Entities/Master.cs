using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_NLayerDesignStudio.DAL.Entities
{
    public class Master
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public int YearsOfWork { get; set; }

        public virtual ICollection<Service> Services { get; set; }

        public Master()
        {
            Services = new List<Service>();
        }
    }
}
