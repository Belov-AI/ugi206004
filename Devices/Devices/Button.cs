using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public class Button
    {
        Lamp lamp;

        public Button(Lamp lamp)
        {
            this.lamp = lamp;
        }

        public void Press()
        {
            if (lamp.IsActive)
                lamp.TurnOff();
            else
                lamp.TurnOn();
        }
    }
}
