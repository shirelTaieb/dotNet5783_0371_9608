using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlImplementation;

namespace BLApi
{
    public static class Factory
    {
        public static IBl Get()
        {
            IBl bl = new Bl();
            return bl;
        }
    }
}
