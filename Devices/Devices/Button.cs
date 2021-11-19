using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public class Button
    {
        IButtonMahagedDevice device;

        public Button(IButtonMahagedDevice device)
        {
            this.device = device;
        }

        public void Press()
        {
            if (device.IsActive)
            {
                device.TurnOff();
            }
            else
                device.TurnOn();
        }
    }
}
