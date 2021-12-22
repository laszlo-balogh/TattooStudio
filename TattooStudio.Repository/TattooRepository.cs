using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Data;
using TattooStudio.Models;

namespace TattooStudio.Repository
{
    public class TattooRepository : ITattooRepository
    {
        TattooStudioDbContext db;
        public TattooRepository(TattooStudioDbContext db)
        {
            this.db = db;
        }
        public void Create(Tattoo tattoo)
        {
            db.Add(tattoo);
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            db.Remove(Read(id));
            db.SaveChanges();
        }

        public Tattoo Read(int id)
        {
            return db.Tattoos.FirstOrDefault(t => t.TattooID == id);
        }

        public IQueryable<Tattoo> ReadAll()
        {
            return db.Tattoos;
        }
    }
}
