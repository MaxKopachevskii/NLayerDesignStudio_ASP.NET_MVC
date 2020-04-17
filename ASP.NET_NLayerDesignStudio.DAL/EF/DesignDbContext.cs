using ASP.NET_NLayerDesignStudio.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASP.NET_NLayerDesignStudio.DAL.EF
{
    public class DesignDbContext : DbContext
    {
        public DbSet<Service> Services { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Example> Examples { get; set; }

        static DesignDbContext()
        {
            Database.SetInitializer<DesignDbContext>(new DbInialize());
        }
        public DesignDbContext(string connectionString)
            : base(connectionString)
        {
        }
    }

    public class DbInialize : DropCreateDatabaseAlways<DesignDbContext>
    {
        protected override void Seed(DesignDbContext db)
        {
            Master master1 = new Master { Name = "Ольга", Age = 25, YearsOfWork = 5 };
            Master master2 = new Master { Name = "Андрей", Age = 30, YearsOfWork = 8 };
            Master master3 = new Master { Name = "Евгений", Age = 32, YearsOfWork = 9 };

            db.Masters.Add(master1);
            db.Masters.Add(master2);
            db.Masters.Add(master3);
            db.SaveChanges();

            Service service1 = new Service { Name = "Разработка идеи", Description = "3D визуализация", Price = 1000, MasterId = master1.Id, Img = "https://miro.medium.com/max/3600/1*wV8t5zwwqz97i1pTFbMUCw.jpeg" };
            Service service2 = new Service { Name = "Рабочий проект дизайна", Description = "Для строительных работ", Price = 700, MasterId = master2.Id, Img = "https://evrodom.kh.ua/images/untitled-2470.jpg" };
            Service service3 = new Service { Name = "Авторское сопровождение", Description = "Выезд на обьект для контроля строительных работ", Price = 500, MasterId = master3.Id, Img = "https://www.topdom.ru/gallery/flats/97/1.jpg" };
            Service service4 = new Service { Name = "Ремонтно-строительные работы", Description = "Реализация задуманого дизайна", Price = 1200, MasterId = master2.Id, Img = "https://www.brd24.com/up/iblock/dc2/dc208ba17a16ba0d50bb9f1c1d4d5407.jpg" };

            Example example1 = new Example { Name = "ЖК «Duderhof Club»", Desc = "Просторная квартира в современном стиле, ЖК «Duderhof Club», 146 кв.м.", Img = "https://www.ivd.ru/uploads/597094ac201b7.jpg" };
            Example example2 = new Example { Name = "ЖК «Символ»", Desc = "Интерьер квартиры в современном стиле, ЖК «Символ», 64 кв.м.", Img = "https://geometrium.com/wp-content/uploads/2019/04/viza_vander_park-2.jpg" };
            Example example3 = new Example { Name = "ЖК «Остров»", Desc = "Интерьер квартиры в современном стиле, ЖК «Остров», 90 кв.м.", Img = "https://dominterier.ru/wp-content/uploads/2018/12/vr-13.jpg" };
            Example example4 = new Example { Name = "ЖК «1147»", Desc = "Квартира в современном стиле, ЖК «1147», 97 кв.м.", Img = "https://n1s1.elle.ru/75/ec/41/75ec415754d2587b15ea558b0e766780/1880x1410_0xac120003_2303638321572337726.jpg" };

            db.Examples.Add(example1);
            db.Examples.Add(example2);
            db.Examples.Add(example3);
            db.Examples.Add(example4);

            db.Services.Add(service1);
            db.Services.Add(service2);
            db.Services.Add(service3);
            db.Services.Add(service4);
            db.SaveChanges();

            base.Seed(db);
        }
    }
}
