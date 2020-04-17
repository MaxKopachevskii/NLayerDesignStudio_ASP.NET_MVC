using ASP.NET_NLayerDesignStudio.DAL.EF;
using ASP.NET_NLayerDesignStudio.DAL.Entities;
using ASP.NET_NLayerDesignStudio.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_NLayerDesignStudio.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private DesignDbContext db;
        private MasterRepository masterRepository;
        private ServiceRepository serviceRepository;
        private ExampleRepository exampleRepository;

        public UnitOfWork(string connectionString)
        {
            db = new DesignDbContext(connectionString);
        }

    public IRepository<Master> Masters
        {
            get
            {
                if (masterRepository == null)
                    masterRepository = new MasterRepository(db);
                return masterRepository;
            }
        }

        public IRepository<Service> Services
        {
            get
            {
                if (serviceRepository == null)
                    serviceRepository = new ServiceRepository(db);
                return serviceRepository;
            }
        }

        public IRepository<Example> Examples
        {
            get
            {
                if (exampleRepository == null)
                    exampleRepository = new ExampleRepository(db);
                return exampleRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
