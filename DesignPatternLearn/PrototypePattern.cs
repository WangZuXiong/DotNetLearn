using System;
using System.Collections.Generic;

/// <summary>
/// 原型模式
/// </summary>
public class PrototypePattern
{
    public abstract class Shape : ICloneable
    {
        private string _id;
        protected string Type;
        public abstract void Draw();

        public string GetShapeType()
        {
            return Type;
        }

        public string GetId()
        {
            return _id;
        }

        public void SetId(string id)
        {
            _id = id;
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
    }

    //创建扩展了上面抽象类的实体类。
    public class Rectangle : Shape
    {
        public Rectangle()
        {
            Type = "Rectangle";
        }
        public override void Draw()
        {
            Console.WriteLine("Inside Rectangle::draw() method.");
        }
    }
    public class Square : Shape
    {
        public Square()
        {
            Type = "Square";
        }
        public override void Draw()
        {
            Console.WriteLine("Inside Square::draw() method.");
        }
    }

    public class Circle : Shape
    {
        public Circle()
        {
            Type = "Circle";
        }
        public override void Draw()
        {
            Console.WriteLine("Inside Circle::draw() method.");
        }
    }

    //创建一个类，从数据库获取实体类，并把它们存储在一个 Hashtable 中。
    public class ShapeCache
    {
        public static Dictionary<string, Shape> ShapeDict = new Dictionary<string, Shape>();

        public static Shape GetShape(string shapeId)
        {
            Shape shape = ShapeDict[shapeId];
            return (Shape)shape.Clone();
        }

        public static void LoadCache()
        {
            Circle circle = new Circle();
            circle.SetId("1");
            ShapeDict.Add(circle.GetId(), circle);

            Square square = new Square();
            square.SetId("2");
            ShapeDict.Add(square.GetId(), square);

            Rectangle rectangle = new Rectangle();
            rectangle.SetId("3");
            ShapeDict.Add(rectangle.GetId(), rectangle);
        }
    }

    public void Main()
    {
        ShapeCache.LoadCache();

        Shape cloneShape = ShapeCache.GetShape("1");
        Console.WriteLine("shape type::" + cloneShape.GetShapeType());

        Shape cloneShape2 = ShapeCache.GetShape("2");
        Console.WriteLine("shape type::" + cloneShape2.GetShapeType());

        Shape cloneShape3 = ShapeCache.GetShape("3");
        Console.WriteLine("shape type::" + cloneShape3.GetShapeType());
    }
}
