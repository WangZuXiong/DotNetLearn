using System;
/// <summary>
/// 外观模式
/// </summary>
public class FacadePattern 
{
    public interface IShape
    {
        void Draw();
    }

    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Draw Rectangle");
        }
    }

    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Draw Circle");
        }
    }

    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Draw Square");
        }
    }

    public class ShapeMaker
    {
        private IShape _circle;
        private IShape _rectangle;
        private IShape _square;

        public ShapeMaker()
        {
            _circle = new Circle();
            _rectangle = new Rectangle();
            _square = new Square();
        }

        public void DrawCircle()
        {
            _circle.Draw();
        }

        public void DrawRectangle()
        {
            _rectangle.Draw();
        }

        public void DrawSquare()
        {
            _square.Draw();
        }
    }

    public void Main()
    {
        ShapeMaker shapeMaker = new ShapeMaker();
        shapeMaker.DrawCircle();
        shapeMaker.DrawRectangle();
        shapeMaker.DrawSquare();
    }
}
