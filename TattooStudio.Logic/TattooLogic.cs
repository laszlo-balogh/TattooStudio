using System;
using System.Collections.Generic;
using TattooStudio.Repository;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Models;

namespace TattooStudio.Logic
{
    public class TattooLogic : ITattooLogic
    {
        ITattooRepository tattooRepo;
        public TattooLogic(ITattooRepository tattooRepo)
        {
            this.tattooRepo = tattooRepo;
        }

        public IEnumerable<Tattoo> ReadAll()
        {
            return this.tattooRepo.ReadAll();
        }
    }
}
