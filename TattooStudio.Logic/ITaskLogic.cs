using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TattooStudio.Logic
{
    public interface ITaskLogic
    {
        IEnumerable<object> HowManyTimes();
        IEnumerable<object> WhatWanted();
    }
}
