using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Models;

namespace TattooStudio.Repository
{
    public interface IWorkREpository
    {
        void Create(Work work);
        void Delete(int id);
        Work Read(int id);
        IQueryable<Work> ReadAll();       

    }
}
