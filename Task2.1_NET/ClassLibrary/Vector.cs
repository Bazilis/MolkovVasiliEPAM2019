using System;

namespace ClassLibrary
{
    public class Vector
    {
        public double X { get; set; }       // automatic property for 'X' dimension of vector
        public double Y { get; set; }       // automatic property for 'Y' dimension of vector
        public double Z { get; set; }       // automatic property for 'Z' dimension of vector

        public double Length                // property for vector length calculation
        {
            get
            {
                return Math.Round(Math.Sqrt(X * X + Y * Y + Z * Z), 4);
            }
        }

        /// <summary>
        /// Constructor with parameters for Vector type
        /// </summary>
        /// <param name="x">'X' dimension of vector</param>
        /// <param name="y">'Y' dimension of vector</param>
        /// <param name="z">'Z' dimension of vector</param>
        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        /// <summary>
        /// Constructor without parameters for Vector type
        /// </summary>
        public Vector()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        /// <summary>
        /// Overloaded operator '+' for addition of Vector types
        /// </summary>
        /// <param name="first">First vector type instance</param>
        /// <param name="second">Second vector type instance</param>
        /// <returns>New vector type instance</returns>
        public static Vector operator +(Vector first, Vector second)
        {
            return new Vector((first.X + second.X),
                              (first.Y + second.Y),
                              (first.Z + second.Z));
        }

        /// <summary>
        /// Overloaded operator '-' for subtruction of Vector types
        /// </summary>
        /// <param name="first">First vector type instance</param>
        /// <param name="second">Second vector type instance</param>
        /// <returns>New vector type instance</returns>
        public static Vector operator -(Vector first, Vector second)
        {
            return new Vector((first.X - second.X),
                              (first.Y - second.Y),
                              (first.Z - second.Z));
        }

        /// <summary>
        /// Overloaded operator '*' for scalar multiplication of Vector types
        /// </summary>
        /// <param name="first">First vector type instance</param>
        /// <param name="second">Second vector type instance</param>
        /// <returns>Scalar double type</returns>
        public static double operator *(Vector first, Vector second)
        {
            return ((first.X * second.X) + (first.Y * second.Y) + (first.Z * second.Z));
        }

        /// <summary>
        /// Overloaded operator '^' for vector multiplication of vectors
        /// </summary>
        /// <param name="first">First vector</param>
        /// <param name="second">Second vector</param>
        /// <returns>New vector type instance</returns>
        public static Vector operator ^(Vector first, Vector second)
        {
            return new Vector((first.Y * second.Z - first.Z * second.Y),
                              (first.Z * second.X - first.X * second.Z),
                              (first.X * second.Y - first.Y * second.X));
        }

        /// <summary>
        /// Overloaded operator '*' for Vector type and scalar double type multiplication
        /// </summary>
        /// <param name="vector">Vector type instance</param>
        /// <param name="scalar">Scalar (number) double type</param>
        /// <returns>New vector type instance</returns>
        public static Vector operator *(Vector vector, double scalar)
        {
            return new Vector(vector.X * scalar,
                              vector.Y * scalar,
                              vector.Z * scalar);
        }

        /// <summary>
        /// Overloaded operator '/' for Vector type and scalar double type division
        /// </summary>
        /// <param name="vector">Vector type instance</param>
        /// <param name="scalar">Scalar (number) double type</param>
        /// <returns>New vector type instance</returns>
        public static Vector operator /(Vector vector, double scalar)
        {
            return new Vector(vector.X / scalar,
                              vector.Y / scalar,
                              vector.Z / scalar);
        }

        /// <summary>
        /// Override ToString() method
        /// </summary>
        /// <returns>String type</returns>
        public override string ToString()
        {
            return ($"vector ({X}; {Y}; {Z})");
        }

        /// <summary>
        /// Overload comparison operator '=='
        /// </summary>
        /// <param name="first">First vector type</param>
        /// <param name="second">Second vector type</param>
        /// <returns>True or false</returns>
        public static bool operator ==(Vector first, Vector second)
        {
            return (first.X == second.X &&
                    first.Y == second.Y &&
                    first.Z == second.Z);
        }

        /// <summary>
        /// Overload comparison operator '!='
        /// </summary>
        /// <param name="first">First vector</param>
        /// <param name="second">Second vector</param>
        /// <returns>True or false</returns>
        public static bool operator !=(Vector first, Vector second)
        {
            return (first.X != second.X ||
                    first.Y != second.Y ||
                    first.Z != second.Z);
        }

        /// <summary>
        /// Override Equals() method
        /// </summary>
        /// <param name="obj">Object type</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if(obj == null)
            {
                return false;
            }

            Vector vector = (Vector)obj;

            if (X == vector.X && Y == vector.Y && Z == vector.Z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Override GetHashCode() method
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return ((X + Y + Z).GetHashCode());
        }
    }
}
