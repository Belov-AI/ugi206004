using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Devices;

namespace DevicesUnitTests
{
    [TestClass]
    public class DevicesUnitTests
    {
        [TestMethod]
        public void TestLamp()
        {
            var lamp = new Lamp();
            Assert.IsFalse(lamp.IsActive);

            lamp.TurnOn();
            Assert.IsTrue(lamp.IsActive);

            lamp.TurnOff();
            Assert.IsFalse(lamp.IsActive);
        }

        [TestMethod]
        public void TestButton()
        {
            TestButtonWithNewDevice(new Lamp());
            TestButtonWithNewDevice(new ElectricMotor(1200));
            TestButtonWithNewDevice(new TVSet(100));
        }

        void TestButtonWithNewDevice(ButtonMahagedDevice device)
        {
            var button = new Button(device);
            Assert.IsFalse(device.IsActive);
            button.Press();
            Assert.IsTrue(device.IsActive);
            button.Press();
            Assert.IsFalse(device.IsActive);
        }
    }
}
