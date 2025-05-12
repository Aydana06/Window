using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserControlLibrary
{
    public class RadialClickEventArgs: EventArgs
    {
        public bool isPlus { get; private set; }

        public RadialClickEventArgs(bool isPlus)
        {
            this.isPlus = isPlus;
        }
    }
}
