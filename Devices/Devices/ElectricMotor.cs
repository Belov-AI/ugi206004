using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public class ElectricMotor
    {
        public bool IsActive { get; private set; }
        public double RotationSpeed { get; private set; }

        double nominalRotationSpeed;

        public ElectricMotor(double nominalSpeed) 
        {
            nominalRotationSpeed = nominalSpeed;
        }

        public void TurnOn()
        {
            IsActive = true;
            RotationSpeed = nominalRotationSpeed;
        }

        public void TurnOff()
        {
            RotationSpeed = 0;
            IsActive = false;
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
