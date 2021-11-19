using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public class Lamp
    {
        public bool IsActive { get; private set; }

        public void TurnOn()
        {
            IsActive = true;
        }

        public void TurnOff()
        {
            IsActive = false;
        }
    }
}
