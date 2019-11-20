using System;

namespace ClassLibrary
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Vector operator +(Vector first, Vector second)
        {
            return new Vector((first.X + second.X), (first.Y + second.Y), (first.Z + second.Z));
        }

        public static Vector operator -(Vector first, Vector second)
        {
            return new Vector((first.X - second.X), (first.Y - second.Y), (first.Z - second.Z));
        }

        public static double operator *(Vector first, Vector second)
        {
            return ((first.X * second.X) + (first.Y * second.Y) + (first.Z * second.Z));
        }
    }
}
