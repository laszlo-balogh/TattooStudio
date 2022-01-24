using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Models;

namespace TattooStudio.Repository
{
    public interface ITattooRepository
    {
        Tattoo Create(Tattoo tattoo);
        void Delete(int id);
        Tattoo Read(int id);
        List<Tattoo> ReadAll();
    }
}
