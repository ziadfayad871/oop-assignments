using static Program;

public partial class Program
{
    public static void Main()
    {
        Shape3D[] shapes = new Shape3D[2];
        shapes[0] = new Sphere(radius: 3.0, density: 2.5, x: 0.0, y: 0.0, z: 0.0);
        shapes[1] = new Cube(sideLength: 2.0, density: 3.0, x: 1.0, y: 1.0, z: 1.0);

        double totalMass = 0.0;
        foreach (Shape3D s in shapes)
        {
            if (s is SolidShape solid)
                totalMass += solid.getMass();
        }
        Console.WriteLine("Total Mass: " + totalMass);

        Console.Write("Enter scale factor: ");
        double factor = double.Parse(Console.ReadLine() ?? "1");

        foreach (Shape3D s in shapes)
        {
            if (s is Transformable t)
                t.scale(factor);
        }
        Console.WriteLine("\nAfter Scaling:");
        foreach (Shape3D s in shapes)
        {
            Console.WriteLine($"Type: {s.GetType().Name}");
            Console.WriteLine("New Volume: " + s.gatVolume());

            if (s is SolidShape solid)
                Console.WriteLine("New Mass: " + solid.getMass());

            Console.WriteLine("--------------------");
        }
    }
}

    public abstract class Shape3D
    {
        public abstract double gatVolume();
        public abstract double getSurfaceArea();
    }
    public abstract class SolidShape : Shape3D
    {
        public double density;
    public double getMass()
    {
        return density * gatVolume();
    }
    }

    public interface Transformable
    {
        void scale(double factor);
        void move(double dx, double dy, double dz);
    }

    public class Sphere : SolidShape, Transformable
    {
        public double radius;
        public double x, y, z;
        public Sphere(double radius, double density, double x, double y, double z)
        {
            this.radius = radius;
            this.density = density;
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override double gatVolume()
        {
            return (4.0 / 3.0) * System.Math.PI * System.Math.Pow(radius, 3);
        }
        public override double getSurfaceArea()
        {
            return 4 * System.Math.PI * System.Math.Pow(radius, 2);
        }
        public void scale(double factor)
        {
            radius *= factor;
        }
        public void move(double dx, double dy, double dz)
        {
            x += dx;
            y += dy;
            z += dz;
        }
    }
    public class Cube : SolidShape, Transformable
    {
        public double sideLength;
        public double x, y, z;
        public Cube(double sideLength, double density, double x, double y, double z)
        {
            this.sideLength = sideLength;
            this.density = density;
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public override double gatVolume()
        {
            return System.Math.Pow(sideLength, 3);
        }
        public override double getSurfaceArea()
        {
            return 6 * System.Math.Pow(sideLength, 2);
        }
        public void scale(double factor)
        {
            sideLength *= factor;
        }
        public void move(double dx, double dy, double dz)
        {
            x += dx;
            y += dy;
            z += dz;
        }
    }


// question :
/* Task:
Create a multi-level class hierarchy involving abstract classes and interfaces.
Requirements:
1. Create an abstract class Shape3D with:
 • abstract double getVolume()
 • abstract double getSurfaceArea()
2. Create an abstract subclass SolidShape with:
 • field: density
 • concrete method: getMass() = density * getVolume()
3. Create interface Transformable:
 • void scale(double factor)
 • void move(double dx, double dy, double dz)
4. Create classes:
 • Sphere extends SolidShape implements Transformable
 • Cube extends SolidShape implements Transformable
Sphere fields:
 • radius, x, y, z
Cube fields:
 • side, x, y, z
5. Write a test program that:
 • Creates an array of Shape3D
 • Calculates total mass
 • Scales all shapes by a user-given factor
 • Prints new volumes & masses
*/