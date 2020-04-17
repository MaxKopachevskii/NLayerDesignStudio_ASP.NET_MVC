using ASP.NET_NLayerDesignStudio.DAL.EF;
using ASP.NET_NLayerDesignStudio.DAL.Entities;
using ASP.NET_NLayerDesignStudio.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_NLayerDesignStudio.DAL.Repositories
{
    public class MasterRepository : IRepository<Master>
    {
        private DesignDbContext db;

        public MasterRepository(DesignDbContext context)
        {
            this.db = context;
        }

        public void Create(Master item)
        {
            db.Masters.Add(item);
        }

        public void Delete(int id)
        {
            var master = db.Masters.Find(id);
            if (master != null)
            {
                db.Masters.Remove(master);
            }
        }

        public Master Get(int id)
        {
            return db.Masters.Find(id);
        }

        public IEnumerable<Master> GetAll()
        {
            return db.Masters;
        }

        public void Update(Master item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
