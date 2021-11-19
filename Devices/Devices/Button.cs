using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public class Button
    {
        object obj;

        public Button(object obj)
        {
            this.obj = obj;
        }

        public void Press()
        {
            if(obj is Lamp lamp)
            {
                if (lamp.IsActive)
                    lamp.TurnOff();
                else
                    lamp.TurnOn();
            }
            else if (obj is ElectricMotor motor)
            {
                if (motor.IsActive)
                    motor.TurnOff();
                else
                    motor.TurnOn();
            }           
        }
    }
}
