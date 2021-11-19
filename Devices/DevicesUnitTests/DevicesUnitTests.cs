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
            var lamp = new Lamp();
            var button = new Button(lamp);

            Assert.IsFalse(lamp.IsActive);
            button.Press();
            Assert.IsTrue(lamp.IsActive);
            button.Press();
            Assert.IsFalse(lamp.IsActive);
        }
    }
}
