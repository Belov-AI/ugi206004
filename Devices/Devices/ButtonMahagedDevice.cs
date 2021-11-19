using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devices
{
    public abstract class ButtonMahagedDevice
    {
        public bool IsActive { get; private set; }
        public  virtual void TurnOn()
        {
            IsActive = true;
        }
        public virtual void TurnOff()
        {
            IsActive = false;
        }
    }
}
