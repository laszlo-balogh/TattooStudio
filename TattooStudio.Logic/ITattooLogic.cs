using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Models;

namespace TattooStudio.Logic
{
    public interface ITattooLogic
    {
        List<Tattoo> ReadAll();
        Tattoo Create(Tattoo tattoo);
        Tattoo Read(int id);
    }
}
