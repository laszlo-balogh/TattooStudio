using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Models;

namespace TattooStudio.Repository
{
    interface IReadyTattoo
    {
        void Create(ReadyTattoo readyTattoo);
        void Delete(int id);
        ReadyTattoo Read(int id);
        IQueryable<ReadyTattoo> ReadAll();
    }
}
