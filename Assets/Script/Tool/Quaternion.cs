using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Finch
{
    public struct Quaternion
    {
        public float x;

        public float y;

        public float z;

        public float w;

        static readonly Quaternion identityQuaternion = new Quaternion(0, 0, 0, 1);
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    case 2:
                        return z;
                    case 3:
                        return w;
                    default:
                        throw new IndexOutOfRangeException("Invalid Quaternion Index");
                }
            }

            set
            {
                switch (index)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                    case 2:
                        z = value;
                        break;
                    case 3:
                        w = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException("Invalid Quaternion Index");
                }
            }
        }

        /// <summary>
        /// Gets the unit quaternion that indicates no rotation
        /// </summary>
        public static Quaternion identity
        {
            get
            {
                return identityQuaternion;
            }
        }

        /// <summary>
        /// Construct quaternions in terms of x,y,z,w
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="w"></param>
        public Quaternion(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        /// <summary>
        /// Construct quaternions from vector
        /// </summary>
        /// <param name="vector"></param>
        public Quaternion(Vector4 vector)
        {
            this.x = vector.x;
            this.y = vector.y;
            this.z = vector.z;
            this.w = vector.w;
        }

        /// <summary>
        /// Construct a half-corner quaternion
        /// </summary>
        /// <param name="theta">rotate angle</param>
        /// <param name="axis">usually need normalize</param>
        public Quaternion(float theta, Vector3 axis)
        {
            float radian = theta * 0.5f * Mathf.Deg2Rad;
            float sinTheta = Mathf.Sin(radian);
            float cosTheta = Mathf.Cos(radian);
            axis = sinTheta * axis;
            this.x = axis.x;
            this.y = axis.y;
            this.z = axis.z;
            this.w = cosTheta;
        }

        /// <summary>
        /// Get the conjugate of the quaternion
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public static Quaternion Conjugate(Quaternion q)
        {
            return new Quaternion(-q.x, -q.y, -q.z, q.w);
        }

        /// <summary>
        /// Get the conjugate of the quaternion
        /// </summary>
        public void Conjugate()
        {
            this = Conjugate(this);
        }

        public Quaternion conjugated
        {
            get
            {
                return Conjugate(this);
            }
        }

        /// <summary>
        /// Obtain the magnitude of the quaternion
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public static float Magnitude(Quaternion q)
        {
            return Mathf.Sqrt(q.w * q.w + q.x * q.x + q.y * q.y + q.z * q.z);
        }

        public float magnitude
        {
            get
            {
                return Magnitude(this);
            }
        }

        /// <summary>
        /// Normalize quaternion
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public static Quaternion Normalize(Quaternion q)
        {
            float mag = q.magnitude;
            //can't divide zero
            if (mag < Mathf.Epsilon)
                return Quaternion.identity;

            float w = q.w / mag;
            float x = q.x / mag;
            float y = q.y / mag;
            float z = q.z / mag;
            return new Quaternion(x, y, z, w);
        }

        /// <summary>
        /// Normalize quaternion
        /// </summary>
        public void Normalize()
        {
            this = Normalize(this);
        }

        public Quaternion normalized
        {
            get
            {
                return Normalize(this);
            }
        }

        /// <summary>
        /// Get the inverse of the quaternion
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public static Quaternion Inverse(Quaternion q)
        {
            float mag2 = q.magnitude * q.magnitude;
            Quaternion conjugate = q.conjugated;
            float w = conjugate.w / mag2;
            float x = conjugate.x / mag2;
            float y = conjugate.y / mag2;
            float z = conjugate.z / mag2;
            return new Quaternion(x, y, z, w);
        }

        public Quaternion inverse
        {
            get
            {
                return Inverse(this);
            }
        }

        /// <summary>
        /// Obtain Euler Angle represented by quaternion
        /// </summary>
        /// <returns></returns>
        public static Vector3 ToEulerAngles(Quaternion q)
        {
            //https://en.wikipedia.org/wiki/Conversion_between_quaternions_and_Euler_angles#Quaternion_to_Euler_angles_conversion


            float sinRcosP = 2 * (q.w * q.x + q.y * q.z);
            float cosRcosP = 1 - 2 * (q.x * q.x + q.y * q.y);
            float x = Mathf.Atan2(sinRcosP, cosRcosP);

            float sinp = 2 * (q.w * q.y - q.z * q.x);
            float y = 0;
            if (Mathf.Abs(sinp) >= 1)
                y = Mathf.PI / 2 * Mathf.Sign(sinp);// use 90 degrees if out of range
            else
                y = Mathf.Asin(sinp);

            float sinYcosP = 2 * (q.w * q.z + q.x * q.y);
            float cosYcosP = 1 - 2 * (q.y * q.y + q.z * q.z);
            float z = Mathf.Atan2(sinYcosP, cosYcosP);
            return new Vector3(x * Mathf.Rad2Deg, y * Mathf.Rad2Deg, z * Mathf.Rad2Deg);
        }

        public Vector3 eulerAngles
        {
            get
            {
                return ToEulerAngles(this);
            }
        }

        /// <summary>
        /// Get the Angle between the two quaternions
        /// </summary>
        /// <param name="q1"></param>
        /// <param name="q2"></param>
        /// <returns></returns>
        public static float Angle(Quaternion q1, Quaternion q2)
        {
            float numerator = q1.x * q2.x + q1.y * q2.y + q1.z * q2.z + q1.w * q2.w;
            float denominator = q1.magnitude * q2.magnitude;
            float cosTheta = numerator / denominator;
            float angle = Mathf.Acos(cosTheta);
            return angle;
        }

        /// <summary>
        /// Returns the quaternion rotated according to the xyz axis
        /// </summary>
        /// <param name="rotatex"></param>
        /// <param name="rotatey"></param>
        /// <param name="rotatez"></param>
        /// <returns></returns>
        public static Quaternion Euler(float rotatex, float rotatey, float rotatez)
        {
            //formula(10.25)
            float h = rotatey * 0.5f * Mathf.Deg2Rad;
            float p = rotatex * 0.5f * Mathf.Deg2Rad;
            float b = rotatez * 0.5f * Mathf.Deg2Rad;
            float w = Mathf.Cos(h) * Mathf.Cos(p) * Mathf.Cos(b) + Mathf.Sin(h) * Mathf.Sin(p) * Mathf.Sin(b);
            float x = Mathf.Cos(h) * Mathf.Sin(p) * Mathf.Cos(b) - Mathf.Sin(h) * Mathf.Cos(p) * Mathf.Sin(b);
            float y = Mathf.Sin(h) * Mathf.Cos(p) * Mathf.Cos(b) + Mathf.Cos(h) * Mathf.Sin(p) * Mathf.Sin(b);
            float z = Mathf.Cos(h) * Mathf.Cos(p) * Mathf.Sin(b) - Mathf.Sin(h) * Mathf.Sin(p) * Mathf.Cos(b);
            return new Quaternion(x, y, z, w);
        }

        /// <summary>
        /// Returns the quaternion rotated according to the xyz axis
        /// </summary>
        /// <param name="rotatex"></param>
        /// <param name="rotatey"></param>
        /// <param name="rotatez"></param>
        /// <returns></returns>
        public static Quaternion Euler2(float rotatex, float rotatey, float rotatez)
        {
            float xRadian = rotatex * 0.5f * Mathf.Deg2Rad;
            float yRadian = rotatey * 0.5f * Mathf.Deg2Rad;
            float zRadian = rotatez * 0.5f * Mathf.Deg2Rad;
            Quaternion qx = new Quaternion(Mathf.Sin(xRadian), 0, 0, Mathf.Cos(xRadian));
            Quaternion qy = new Quaternion(0, Mathf.Sin(yRadian), 0, Mathf.Cos(yRadian));
            Quaternion qz = new Quaternion(0, 0, Mathf.Sin(zRadian), Mathf.Cos(zRadian));

            return qz * qy * qx;
        }

        /// <summary>
        /// Quaternion spherical interpolation
        /// </summary>
        /// <param name="q1"></param>
        /// <param name="q2"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public static Quaternion Slerp(Quaternion q1, Quaternion q2, float t)
        {
            float theta = Angle(q1, q2);
            float f1 = Mathf.Sin((1 - t) * theta) / Mathf.Sin(theta);
            float f2 = Mathf.Sin(t * theta) / Mathf.Sin(theta);
            Quaternion q = q1 * f1 + q2 * f2;
            return q;
        }


        /// <summary>
        /// Quaternion addition
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Quaternion operator +(Quaternion lhs, Quaternion rhs)
        {
            float w = lhs.w + rhs.w;
            float x = lhs.x + rhs.x;
            float y = lhs.y + rhs.y;
            float z = lhs.z + rhs.z;
            return new Quaternion(x, y, z, w);
        }

        /// <summary>
        /// Quaternion subtraction
        /// </summary>
        /// <returns></returns>
        public static Quaternion operator -(Quaternion lhs, Quaternion rhs)
        {
            float w = lhs.w - rhs.w;
            float x = lhs.x - rhs.x;
            float y = lhs.y - rhs.y;
            float z = lhs.z - rhs.z;
            return new Quaternion(x, y, z, w);
        }
        /// <summary>
        /// Rotate point by quaternion
        /// </summary>
        /// <param name="quaternion"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 operator *(Quaternion quaternion, Vector3 point)
        {
            Matrix4x4 matrix = quaternion.rotationMatrix;
            Vector3 position = matrix * point;
            return position;
        }

        /// <summary>
        /// Quaternion multiplication
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Quaternion operator *(Quaternion lhs, Quaternion rhs)
        {
            float w = lhs.w * rhs.w - lhs.x * rhs.x - lhs.y * rhs.y - lhs.z * rhs.z;
            float x = lhs.w * rhs.x + rhs.w * lhs.x + lhs.y * rhs.z - rhs.y * lhs.z;
            float y = lhs.w * rhs.y + rhs.w * lhs.y + lhs.z * rhs.x - rhs.z * lhs.x;
            float z = lhs.w * rhs.z + rhs.w * lhs.z + lhs.x * rhs.y - rhs.x * lhs.y;
            return new Quaternion(x, y, z, w);
        }

        /// <summary>
        /// Quaternion scalar multiplication
        /// </summary>
        /// <param name="quaternionm"></param>
        /// <param name="scalar"></param>
        /// <returns></returns>
        public static Quaternion operator *(Quaternion q, float scalar)
        {
            float w = scalar * q.w;
            float x = scalar * q.x;
            float y = scalar * q.y;
            float z = scalar * q.z;
            return new Quaternion(x, y, z, w);
        }

        /// <summary>
        /// Quaternion division
        /// </summary>
        /// <param name="q1"></param>
        /// <param name="q2"></param>
        /// <returns></returns>
        public static Quaternion operator /(Quaternion q1, Quaternion q2)
        {
            return q1 * q2.inverse;
        }

        /// <summary>
        /// Get matrix from quaternion
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public static Matrix4x4 GetRotationMatrix(Quaternion q)
        {
            //formula(7.16)
            Matrix4x4 matrix = Matrix4x4.identity;
            matrix[0, 0] = 1 - 2 * (q.y * q.y + q.z * q.z);
            matrix[0, 1] = 2 * (q.x * q.y - q.w * q.z);
            matrix[0, 2] = 2 * (q.x * q.z + q.w * q.y);
            matrix[1, 0] = 2 * (q.x * q.y + q.w * q.z);
            matrix[1, 1] = 1 - 2 * (q.x * q.x + q.z * q.z);
            matrix[1, 2] = 2 * (q.y * q.z - q.w * q.x);
            matrix[2, 0] = 2 * (q.x * q.z - q.w * q.y);
            matrix[2, 1] = 2 * (q.y * q.z + q.w * q.x);
            matrix[2, 2] = 1 - 2 * (q.x * q.x + q.y * q.y);
            return matrix;
        }

        /// <summary>
        /// Obtain the quaternion from the matrix
        /// </summary>
        /// <returns></returns>
        public static Quaternion GetQuaternion(Matrix4x4 m)
        {
            float x = 0, y = 0, z = 0, w = 0;

            //get max values
            float wSquaredMinus1 = m[0, 0] + m[1, 1] + m[2, 2];
            float xSquaredMinus1 = m[0, 0] - m[1, 1] - m[2, 2];
            float ySquaredMinus1 = -m[0, 0] + m[1, 1] - m[2, 2];
            float zSquaredMinus1 = -m[0, 0] - m[1, 1] + m[2, 2];

            int biggestIndex = 0;
            float biggestSquaredMinus1 = wSquaredMinus1;
            if (xSquaredMinus1 > biggestSquaredMinus1)
            {
                biggestSquaredMinus1 = xSquaredMinus1;
                biggestIndex = 1;
            }

            if (ySquaredMinus1 > biggestSquaredMinus1)
            {
                biggestSquaredMinus1 = ySquaredMinus1;
                biggestIndex = 2;
            }

            if (zSquaredMinus1 > biggestSquaredMinus1)
            {
                biggestSquaredMinus1 = zSquaredMinus1;
                biggestIndex = 3;
            }

            //calc square roots and division
            float biggestVal = Mathf.Sqrt(biggestSquaredMinus1 + 1.0f) * 0.5f;
            float mult = 0.25f / biggestVal;

            switch (biggestIndex)
            {
                case 0:
                    w = biggestVal;
                    x = (m[2, 1] - m[1, 2]) * mult;
                    y = (m[0, 2] - m[2, 0]) * mult;
                    z = (m[1, 0] - m[0, 1]) * mult;
                    break;
                case 1:
                    x = biggestVal;
                    w = (m[2, 1] - m[1, 2]) * mult;
                    y = (m[1, 0] + m[0, 1]) * mult;
                    z = (m[0, 2] + m[2, 0]) * mult;
                    break;
                case 2:
                    y = biggestVal;
                    w = (m[0, 2] - m[2, 0]) * mult;
                    x = (m[1, 0] + m[0, 1]) * mult;
                    z = (m[2, 1] + m[1, 2]) * mult;
                    break;
                case 3:
                    z = biggestVal;
                    w = (m[1, 0] - m[0, 1]) * mult;
                    x = (m[0, 2] + m[2, 0]) * mult;
                    y = (m[2, 1] + m[1, 2]) * mult;
                    break;
                default:
                    break;
            }

            return new Quaternion(x, y, z, w);
        }

        public Matrix4x4 rotationMatrix
        {
            get
            {
                return GetRotationMatrix(this);
            }
        }

        public override string ToString()
        {
            return string.Format("[{0:0.00},{1:0.00} {2:0.00} {3:0.00}]", w, x, y, z);
        }
    }
}

