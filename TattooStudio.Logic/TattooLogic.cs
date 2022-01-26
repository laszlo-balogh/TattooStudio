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
        private readonly ITattooRepository tattooRepo;
        public TattooLogic(ITattooRepository tattooRepo)
        {
            this.tattooRepo = tattooRepo;
        }

        public Tattoo Create(Tattoo tattoo)
        {
            return tattooRepo.Create(tattoo);
        }

        public Tattoo Read(int id)
        {
            return this.tattooRepo.Read(id);
        }

        public List<Tattoo> ReadAll()
        {
            return this.tattooRepo.ReadAll();
        }
    }
}
