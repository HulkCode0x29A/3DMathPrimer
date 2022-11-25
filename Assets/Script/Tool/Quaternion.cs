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
        /// Rotate point by quaternion
        /// </summary>
        /// <param name="rotation"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static Vector3 operator *(Quaternion rotation, Vector3 point)
        {
            Matrix4x4 matrix = GetRotationMatrix(rotation);
            Vector3 position = matrix * point;
            return position;
        }

        /// <summary>
        /// Quaternion multiplication
        /// </summary>
        /// <param name="lhs"></param>
        /// <param name="rhs"></param>
        /// <returns></returns>
        public static Quaternion operator*(Quaternion lhs,Quaternion rhs)
        {
            float w = lhs.w * rhs.w - lhs.x * rhs.x - lhs.y * rhs.y - lhs.z * rhs.z;
            float x = lhs.w * rhs.x + rhs.w * lhs.x + lhs.y * rhs.z - rhs.y * lhs.z;
            float y = lhs.w * rhs.y + rhs.w * lhs.y + lhs.z * rhs.x - rhs.z * lhs.x;
            float z = lhs.w * rhs.z + rhs.w * lhs.z + lhs.x * rhs.y - rhs.x * lhs.y;
            return new Quaternion(x,y,z,w);
        }

        /// <summary>
        /// Get matrix from quaternion
        /// </summary>
        /// <param name="q"></param>
        /// <returns></returns>
        public static Matrix4x4 GetRotationMatrix(Quaternion q)
        {
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

        public override string ToString()
        {
            return string.Format("[{0},{1}-{2}-{3}]",w,x,y,z) ;
        }
    }
}

