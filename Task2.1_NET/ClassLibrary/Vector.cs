using System;

namespace ClassLibrary
{
    public class Vector
    {
        public double X { get; set; }       //property for 'X' dimension of vector
        public double Y { get; set; }       //property for 'Y' dimension of vector
        public double Z { get; set; }       //property for 'Z' dimension of vector

        public double Length                //property for vector length calculation
        {
            get
            {
                return Math.Round(Math.Sqrt(X * X + Y * Y + Z * Z), 4);
            }
        }

        /// <summary>
        /// Constructor for Vector type
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
        /// Method for addition of vectors
        /// </summary>
        /// <param name="first">First vector</param>
        /// <param name="second">Second vector</param>
        /// <returns>New vector type instance</returns>
        public static Vector operator +(Vector first, Vector second)
        {
            return new Vector((first.X + second.X), (first.Y + second.Y), (first.Z + second.Z));
        }

        /// <summary>
        /// Method for subtruction of vectors
        /// </summary>
        /// <param name="first">First vector</param>
        /// <param name="second">Second vector</param>
        /// <returns>New vector type instance</returns>
        public static Vector operator -(Vector first, Vector second)
        {
            return new Vector((first.X - second.X), (first.Y - second.Y), (first.Z - second.Z));
        }

        /// <summary>
        /// Method for scalar multiplication of vectors
        /// </summary>
        /// <param name="first">First vector</param>
        /// <param name="second">Second vector</param>
        /// <returns>Scalar double type</returns>
        public static double operator *(Vector first, Vector second)
        {
            return ((first.X * second.X) + (first.Y * second.Y) + (first.Z * second.Z));
        }

        /// <summary>
        /// Method for vector multiplication of vectors
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
        /// Method for vector and scalar multiplication
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="scalar">Scalar (number)</param>
        /// <returns>New vector type instance</returns>
        public static Vector operator *(Vector vector, double scalar)
        {
            return new Vector(vector.X * scalar,
                              vector.Y * scalar,
                              vector.Z * scalar);
        }

        /// <summary>
        /// Method for vector and scalar division
        /// </summary>
        /// <param name="vector">Vector</param>
        /// <param name="scalar">Scalar (number)</param>
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
    }
}
