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
            var list = new List<Shape>();
            list.Add(new Rectangle(new Point(1, 1), 5, 3));
            list.Add(new Circle(new Point(-1, 2), 4));
            DrawObjects(list);

        }

        [TestMethod]
        public void TestSquareConstructor()
        {
            var square = new Square(new Point(1, 1), 2);

            Assert.AreEqual(2, square.Width);
            Assert.AreEqual(2, square.Height);
        }

        [TestMethod]
        public void TestChangeRectangleWidth()
        {
            var rectangle = new Rectangle(new Point(0, 0), 5, 3);
            ChangeRectangleWidth(rectangle);

            Assert.AreEqual(6, rectangle.Width);
            Assert.AreEqual(3, rectangle.Height);
        }

        [TestMethod]
        public void TestChangeSquareWidth()
        {
            var square = new Square(new Point(0, 0), 5);
            ChangeRectangleWidth(square);

            Assert.AreEqual(6, square.Width);
            Assert.AreEqual(6, square.Height);
        }

        [TestMethod]
        public void TestCheckRectangleArea()
        {
            var rectangle = new Rectangle(new Point(1, 1), 1, 1);
            Assert.IsTrue(CheckRectangleArea(rectangle));
        }

        [TestMethod]
        public void TestCheckSqareArea()
        {
            var square = new Square(new Point(1, 1), 1);
            Assert.IsTrue(CheckRectangleArea(square));
        }

        [TestMethod]
        public void TestSegmentIsOn()
        {
            var p1 = new Point(1, 0);
            var p2 = new Point(3, 1);
            var m1 = new Point(1, 1);
            var m2 = new Point(2, 0.5);
            var m3 = new Point(4, 1.5);
            var m4 = new Point(-1, -1);

            var segment = new Segment(p1, p2);

            Assert.IsTrue(segment.IsOn(p1));
            Assert.IsTrue(segment.IsOn(p2));
            Assert.IsTrue(segment.IsOn(m2));

            Assert.IsFalse(segment.IsOn(m1));
            Assert.IsFalse(segment.IsOn(m3));
            Assert.IsFalse(segment.IsOn(m4));

        }

        [TestMethod]
        public void TestOYintersection()
        {
            var p1 = new Point(1, 0);
            var p2 = new Point(3, 1);
            var line = new Line(p1, p2);
            Assert.IsTrue(CheckOYIntersection(line));

            var segment = new Segment(p1, p2);
            Assert.IsTrue(CheckOYIntersection(segment));
        }

        void DrawObjects(List<Shape> shapes)
        {
            foreach (var shape in shapes)
                shape.Draw();
        }

        bool CheckRectangleArea(Rectangle rectangle)
        {
            rectangle.Width = 4;
            rectangle.Height = 5;
            return rectangle.Area == 20;
        }

        void ChangeRectangleWidth(Rectangle rectangle)
        {
            rectangle.Width += 1; 
        }

        bool CheckOYIntersection(Line line)
        {
            return line.IsOn(new Point(0, line.B));
        }
    }
}
