using System;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();

        Square shape1 = new("Blue", 15.15);
        shapes.Add(shape1);

        Rectangle shape2 = new("Yellow", 15,1.5);
        shapes.Add(shape2);

        Circle shape3 = new("Purple", 3.5);
        shapes.Add(shape3);


        foreach(Shape s in shapes){
            string color = s.GetColor();
            double area = s.GetArea();
            Console.WriteLine($"The color of the shape is {color} and the area of the shape is {area}"); 
        }
    }
}