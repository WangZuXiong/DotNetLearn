using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// 装饰器模式
/// </summary>
public class DecoratorPattern 
{
    public interface IShape
    {
        void Draw();
    }

    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Shape Rectangle");
        }
    }

    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Shape Circle");
        }
    }

    public abstract class ShapeDecorator : IShape
    {
        protected IShape decoratedShape;
        public ShapeDecorator(IShape decoratedShape)
        {
            this.decoratedShape = decoratedShape;
        }
        public void Draw()
        {
            decoratedShape.Draw();
        }
    }

    public class RedShapeDecorator : ShapeDecorator
    {
        public RedShapeDecorator(IShape decoratedShape) : base(decoratedShape)
        {
            this.decoratedShape = decoratedShape;
        }

        public new void Draw()
        {
            decoratedShape.Draw();
            SetRedBorder(decoratedShape);
        }

        public void SetRedBorder(IShape shape)
        {
            Console.WriteLine("Border color: Red");
        }
    }

    public void Main()
    {
        IShape circle = new Circle();
        ShapeDecorator redCircle = new RedShapeDecorator(new Circle());
        ShapeDecorator redRectangle = new RedShapeDecorator(new Rectangle());

        Console.WriteLine("Circle with normal border");
        circle.Draw();

        Console.WriteLine("Circle of red border");
        redCircle.Draw();

        Console.WriteLine("Rectangle of red border");
        redRectangle.Draw();
    }
}
