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
    public class WorkRepository : IWorkRepository
    {
        private readonly TattooStudioDbContext db;
        private readonly ILogger<WorkRepository> logger;
        public WorkRepository(ILogger<WorkRepository> logger,TattooStudioDbContext db)
        {
            this.db = db;
            this.logger = logger;
        }
        public Work Create(Work work)
        {
            try
            {
                db.Add(work);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetType().Name + " - " + ex.Message, ex.Message);
                return null;
            }
      

            return work;
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

        public List<Work> ReadAll()
        {
            try
            {
                return db.Works.ToList();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.GetType().Name + " - " + ex.Message, ex.Message);
                return new List<Work>();
            }

           
        }

    }
}
