using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public class ElectricMotor : ButtonMahagedDevice
    {
        public double RotationSpeed { get; private set; }

        double nominalRotationSpeed;

        public ElectricMotor(double nominalSpeed) 
        {
            nominalRotationSpeed = nominalSpeed;
        }

        public override void TurnOn()
        {
            base.TurnOn();
            RotationSpeed = nominalRotationSpeed;
        }

        public override void TurnOff()
        {
            RotationSpeed = 0;
            base.TurnOff();
        }

        public void IncreaseRotationSpeed(double delta)
        {
            if (IsActive && delta > 0)
                RotationSpeed += delta;
        }

        public void DecreaseRotationSpeed(double delta)
        {
            if (IsActive && delta > 0)
                RotationSpeed -= delta;

            if (RotationSpeed < 0)
                RotationSpeed = 0;
        }
    }
}
