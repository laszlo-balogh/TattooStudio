using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TattooStudio.Models;

namespace TattooStudio.Logic
{
    public interface ITaskLogic
    {
        int HowManyTimes(string name,DateTime bornDate);
        IEnumerable<KeyValuePair<DateTime, List<Tattoo>>> WhatWanted(string name, DateTime bornDate);


    }
}
