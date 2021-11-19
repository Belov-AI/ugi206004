using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public class TVSet : ButtonMahagedDevice
    {
        int programNumber;
        int maxProgramNumber;

        public TVSet(int maxProgramNumber)
        {
            this.maxProgramNumber = maxProgramNumber;
            programNumber = 1;
        }

        public override void TurnOff()
        {
            base.TurnOff();
        }

        public override void TurnOn()
        {
            base.TurnOn();
        }

        public void ChooseProgram(int number)
        {
            if (0 < programNumber && programNumber <= maxProgramNumber)
                programNumber = number;
        }
    }
}
