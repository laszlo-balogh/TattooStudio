using Microsoft.Extensions.Logging;
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
        private readonly TattooStudioDbContext db;
        private readonly ILogger<TattooRepository> logger;
        public TattooRepository(ILogger<TattooRepository> logger,TattooStudioDbContext db)
        {
            this.db = db;
            this.logger = logger;
        }
        public Tattoo Create(Tattoo tattoo)
        {

            try
            {
                db.Add(tattoo);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetType().Name + " - " + ex.Message, ex.Message);
                return null;
            }

           
            
            return tattoo;
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

        public List<Tattoo> ReadAll()
        {
            try
            {
                return db.Tattoos.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetType().Name + " - " + ex.Message, ex.Message);
                return new List<Tattoo>();
            }

            
        }
    }
}
