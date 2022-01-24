using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Models;

namespace TattooStudio.Repository
{
    public interface IWorkRepository
    {
        Work Create(Work work);
        void Delete(int id);
        Work Read(int id);
        List<Work> ReadAll();       

    }
}
