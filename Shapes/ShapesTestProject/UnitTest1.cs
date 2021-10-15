using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes;

namespace ShapesTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void TestDraw()
        {
            var list = new List<object>();
            list.Add(new Rectangle(new Point(1, 1), 5, 3));
            list.Add(new Circle(new Point(-1, 2), 4));
            DrawObjects(list);

        }

        void DrawObjects(List<object> objects)
        {
            foreach(var obj in objects)
            {
                if (obj is Rectangle rectangle)
                    rectangle.Draw();
                else if (obj is Circle circle)
                    circle.Draw();
            }
        }
    }
}
