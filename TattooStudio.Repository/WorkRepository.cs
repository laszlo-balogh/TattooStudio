using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Data;
using TattooStudio.Models;

namespace TattooStudio.Repository
{
    class WorkRepository : IWorkREpository
    {
        TattooStudioDbContext db;
        public void Create(Work work)
        {
            db.Add(work);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            db.Remove(id);
            db.SaveChanges();
        }

        public Work Read(int id)
        {
            return db.Works.FirstOrDefault(w => w.WorkID == id);
        }

        public IQueryable<Work> ReadAll()
        {
            return db.Works;
        }

       
    }
}
