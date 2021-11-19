using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public class TVSet : IButtonMahagedDevice
    {
        public bool IsActive{ get; private set; }
        int programNumber;
        int maxProgramNumber;

        public TVSet(int maxProgramNumber)
        {
            this.maxProgramNumber = maxProgramNumber;
            programNumber = 1;
        }

        public void TurnOff()
        {
            IsActive = false;
        }

        public void TurnOn()
        {
            IsActive = true;
        }

        public void ChooseProgram(int number)
        {
            if (0 < programNumber && programNumber <= maxProgramNumber)
                programNumber = number;
        }
    }
}
