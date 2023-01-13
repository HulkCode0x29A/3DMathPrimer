using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixUtil
{
    /// <summary>
    /// Obtain the matrix of rotation about the z axis
    /// </summary>
    /// <param name="theta">rotate angle</param>
    /// <returns></returns>
    public static Matrix4x4 GetRotateZMatrix(float theta)
    {
        //formula (3.1.8)
        float radian = Mathf.Deg2Rad * theta;
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = Mathf.Cos(radian);
        matrix[0, 1] = -Mathf.Sin(radian);
        matrix[1, 0] = Mathf.Sin(radian);
        matrix[1, 1] = Mathf.Cos(radian);
        return matrix;
    }

    /// <summary>
    /// Obtain the matrix of rotation about the X-axis
    /// </summary>
    /// <param name="theta">rotate angle</param>
    /// <returns></returns>
    public static Matrix4x4 GetRotateXMatrix(float theta)
    {
        //formula (3.1.6)
        float radian = Mathf.Deg2Rad * theta;
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[1, 1] = Mathf.Cos(radian);
        matrix[1, 2] = -Mathf.Sin(radian);
        matrix[2, 1] = Mathf.Sin(radian);
        matrix[2, 2] = Mathf.Cos(radian);
        return matrix;
    }

    /// <summary>
    /// Obtain the matrix of rotation about the y axis
    /// </summary>
    /// <param name="theta">rotate angle</param>
    /// <returns></returns>
    public static Matrix4x4 GetRotateYMatrix(float theta)
    {
        //formula (3.1.7)
        float radian = Mathf.Deg2Rad * theta;
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = Mathf.Cos(radian);
        matrix[0, 2] = Mathf.Sin(radian);
        matrix[2, 0] = -Mathf.Sin(radian);
        matrix[2, 2] = Mathf.Cos(radian);
        return matrix;
    }

    /// <summary>
    /// Obtain the matrix of any rotation Angle about any axis
    /// </summary>
    /// <param name="n">rotate axis</param>
    /// <param name="angle">rotate angle</param>
    /// <returns></returns>
    public static Matrix4x4 GetRotateByAxisMatrix(Vector3 n, float angle)
    {
        //formula (3.1.18)
        Matrix4x4 matrix = Matrix4x4.identity;
        float theta = Mathf.Deg2Rad * angle;
        matrix[0, 0] = n.x * n.x * (1 - Mathf.Cos(theta)) + Mathf.Cos(theta);
        matrix[0, 1] = n.x * n.y * (1 - Mathf.Cos(theta)) - n.z * Mathf.Sin(theta);
        matrix[0, 2] = n.x * n.z * (1 - Mathf.Cos(theta)) + n.y * Mathf.Sin(theta);
        matrix[1, 0] = n.x * n.y * (1 - Mathf.Cos(theta)) + n.z * Mathf.Sin(theta);
        matrix[1, 1] = n.y * n.y * (1 - Mathf.Cos(theta)) + Mathf.Cos(theta);
        matrix[1, 2] = n.y * n.z * (1 - Mathf.Cos(theta)) - n.x * Mathf.Sin(theta);
        matrix[2, 0] = n.x * n.z * (1 - Mathf.Cos(theta)) - n.y * Mathf.Sin(theta);
        matrix[2, 1] = n.y * n.z * (1 - Mathf.Cos(theta)) + n.x * Mathf.Sin(theta);
        matrix[2, 2] = n.z * n.z * (1 - Mathf.Cos(theta)) + Mathf.Cos(theta);
        return matrix;
    }

    /// <summary>
    /// Gets the matrix rotated according to the xyz axis
    /// </summary>
    /// <param name="rotatex">x degree</param>
    /// <param name="rotatey">y degree</param>
    /// <param name="rotatez">z degree</param>
    /// <returns></returns>
    public static Matrix4x4 GetRotateXYZMatrix(float rotatex, float rotatey, float rotatez)
    {
        float alpha = rotatex * Mathf.Deg2Rad;
        float beta = rotatey * Mathf.Deg2Rad;
        float gamma = rotatez * Mathf.Deg2Rad;
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = Mathf.Cos(beta) * Mathf.Cos(gamma);
        matrix[0, 1] = Mathf.Sin(alpha) * Mathf.Sin(beta) * Mathf.Cos(gamma) - Mathf.Cos(alpha) * Mathf.Sin(gamma);
        matrix[0, 2] = Mathf.Cos(alpha) * Mathf.Sin(beta) * Mathf.Cos(gamma) + Mathf.Sin(alpha) * Mathf.Sin(gamma);
        matrix[1, 0] = Mathf.Cos(beta) * Mathf.Sin(gamma);
        matrix[1, 1] = Mathf.Sin(alpha) * Mathf.Sin(beta) * Mathf.Sin(gamma) + Mathf.Cos(alpha) * Mathf.Cos(gamma);
        matrix[1, 2] = Mathf.Cos(alpha) * Mathf.Sin(beta) * Mathf.Sin(gamma) - Mathf.Sin(alpha) * Mathf.Cos(gamma);
        matrix[2, 0] = -Mathf.Sin(beta);
        matrix[2, 1] = Mathf.Sin(alpha) * Mathf.Cos(beta);
        matrix[2, 2] = Mathf.Cos(alpha) * Mathf.Cos(beta);

        return matrix;
    }

    /// <summary>
    /// Obtain the matrix rotated about the YXZ axis
    /// The matrix is derived from negative angles
    /// </summary>
    /// <param name="heading">rotate y</param>
    /// <param name="pitch">rotate x</param>
    /// <param name="bank">rotate z</param>
    /// <returns></returns>
    public static Matrix4x4 GetReverseRotateYXZMatrix(float heading, float pitch, float bank)
    {
        float h = heading * Mathf.Deg2Rad;
        float p = pitch * Mathf.Deg2Rad;
        float b = bank * Mathf.Deg2Rad;
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = Mathf.Cos(h) * Mathf.Cos(b) - Mathf.Sin(h) * Mathf.Sin(p) * Mathf.Sin(b);
        matrix[0, 1] = Mathf.Cos(h) * Mathf.Sin(b) + Mathf.Sin(h) * Mathf.Sin(p) * Mathf.Cos(b);
        matrix[0, 2] = -Mathf.Sin(h) * Mathf.Cos(p);
        matrix[1, 0] = -Mathf.Cos(p) * Mathf.Sin(b);
        matrix[1, 1] = Mathf.Cos(p) * Mathf.Cos(b);
        matrix[1, 2] = Mathf.Sin(p);
        matrix[2, 0] = Mathf.Sin(h) * Mathf.Cos(b) + Mathf.Cos(h) * Mathf.Sin(p) * Mathf.Sin(b);
        matrix[2, 1] = Mathf.Sin(h) * Mathf.Sin(b) - Mathf.Cos(h) * Mathf.Sin(p) * Mathf.Cos(b);
        matrix[2, 2] = Mathf.Cos(h) * Mathf.Cos(p);
        return matrix;
    }

    /// <summary>
    /// Obtain Euler angles from the matrix
    /// </summary>
    /// <param name="matrix"></param>
    public static Vector3 GetEulerAngleFromReverseRotateYXZ(Matrix4x4 matrix)
    {
        float heading, pitch, bank;

        float sinp = matrix[1, 2];

        pitch = Mathf.Asin(sinp);

        float cosp = Mathf.Cos(pitch);
        pitch = pitch * Mathf.Rad2Deg;

        if (sinp > 0.9999f)
        {
            //Gimbal Lock
            bank = 0;
            float cosh = matrix[0, 0];
            float sinh = matrix[2, 0];
            heading = Mathf.Atan2(sinh, cosh);
            heading = heading * Mathf.Rad2Deg;
        }
        else
        {
            float sinh = -matrix[0, 2] / cosp;
            float cosh = matrix[2, 2] / cosp;
            heading = Mathf.Atan2(sinh, cosh);
            heading = heading * Mathf.Rad2Deg;

            float sinb = -matrix[1, 0] / cosp;
            float cosb = matrix[1, 1] / cosp;
            bank = Mathf.Atan2(sinb, cosb);
            bank = bank * Mathf.Rad2Deg;
        }
        Vector3 angle = new Vector3(pitch, heading, bank);
        return angle;
    }

    /// <summary>
    /// Obtain the matrix rotated about the YXZ axis
    /// </summary>
    /// <param name="heading">rotate y</param>
    /// <param name="pitch">rotate x</param>
    /// <param name="bank">rotate z</param>
    /// <returns></returns>
    public static Matrix4x4 GetRotateYXZMatrix(float heading, float pitch, float bank)
    {
        float h = heading * Mathf.Deg2Rad;
        float p = pitch * Mathf.Deg2Rad;
        float b = bank * Mathf.Deg2Rad;
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = Mathf.Cos(b) * Mathf.Cos(h) - Mathf.Sin(b) * Mathf.Sin(p) * Mathf.Sin(h);
        matrix[0, 1] = -Mathf.Sin(b) * Mathf.Cos(p);
        matrix[0, 2] = Mathf.Cos(b) * Mathf.Sin(h) + Mathf.Sin(b) * Mathf.Sin(p) * Mathf.Cos(h);
        matrix[1, 0] = Mathf.Sin(b) * Mathf.Cos(h) + Mathf.Cos(b) * Mathf.Sin(p) * Mathf.Sin(h);
        matrix[1, 1] = Mathf.Cos(b) * Mathf.Cos(p);
        matrix[1, 2] = Mathf.Sin(b) * Mathf.Sin(h) - Mathf.Cos(b) * Mathf.Sin(p) * Mathf.Cos(h);
        matrix[2, 0] = -Mathf.Cos(p) * Mathf.Sin(h);
        matrix[2, 1] = Mathf.Sin(p);
        matrix[2, 2] = Mathf.Cos(p) * Mathf.Cos(h);
        return matrix;
    }

    /// <summary>
    /// Get the scaling matrix
    /// </summary>
    /// <param name="scale">scale size</param>
    /// <returns></returns>
    public static Matrix4x4 GetScaleMatrix(Vector3 scale)
    {
        //formula (3.2.3)
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = scale.x;
        matrix[1, 1] = scale.y;
        matrix[2, 2] = scale.z;
        return matrix;
    }

    /// <summary>
    /// Gets the matrix scaled about the axis
    /// </summary>
    /// <param name="n">axis</param>
    /// <param name="k">scale size</param>
    /// <returns></returns>
    public static Matrix4x4 GetScaleByAxisMatrix(Vector3 n, float k)
    {
        //formula (3.7.11)
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = 1 + (k - 1) * n.x * n.x;
        matrix[0, 1] = (k - 1) * n.x * n.y;
        matrix[0, 2] = (k - 1) * n.x * n.z;
        matrix[1, 0] = (k - 1) * n.x * n.y;
        matrix[1, 1] = 1 + (k - 1) * n.y * n.y;
        matrix[1, 2] = (k - 1) * n.y * n.z;
        matrix[2, 0] = (k - 1) * n.x * n.z;
        matrix[2, 1] = (k - 1) * n.z * n.y;
        matrix[2, 2] = 1 + (k - 1) * n.z * n.z;
        return matrix;
    }

    /// <summary>
    /// Get the matrix projected onto the xy plane
    /// </summary>
    /// <returns></returns>
    public static Matrix4x4 GetProjectionXYMatrix()
    {
        //formula (3.4.3)
        Matrix4x4 matrix = Matrix4x4.zero;
        matrix[0, 0] = 1;
        matrix[1, 1] = 1;
        return matrix;
    }

    /// <summary>
    /// Get the matrix projected onto the xz plane
    /// </summary>
    /// <returns></returns>
    public static Matrix4x4 GetProjectionXZMatrix()
    {
        //formula (3.4.4)
        Matrix4x4 matrix = Matrix4x4.zero;
        matrix[0, 0] = 1;
        matrix[2, 2] = 1;
        return matrix;
    }

    /// <summary>
    /// Get the matrix projected onto the yz plane
    /// </summary>
    /// <returns></returns>
    public static Matrix4x4 GetProjectionYZMatrix()
    {
        //formula (3.4.5)
        Matrix4x4 matrix = Matrix4x4.zero;
        matrix[1, 1] = 1;
        matrix[2, 2] = 1;
        return matrix;
    }

    /// <summary>
    /// Gets the matrix projected onto any axis
    /// </summary>
    /// <param name="n">axis</param>
    /// <returns></returns>
    public static Matrix4x4 GetProjectionByAxisMatrix(Vector3 n)
    {
        //formula (3.5.2)
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = 1 - n.x * n.x;
        matrix[0, 1] = -n.x * n.y;
        matrix[0, 2] = -n.x * n.z;
        matrix[1, 0] = -n.x * n.y;
        matrix[1, 1] = 1 - n.y * n.y;
        matrix[1, 2] = -n.y * n.z;
        matrix[2, 0] = -n.x * n.z;
        matrix[2, 1] = -n.z * n.y;
        matrix[2, 2] = 1 - n.z * n.z;
        return matrix;
    }

    /// <summary>
    /// Gets the matrix reflected by any axis
    /// </summary>
    /// <param name="n"></param>
    /// <returns></returns>
    public static Matrix4x4 GetReflectByAxisMatrix(Vector3 n)
    {
        //formula (3.6.2)
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = 1 - 2 * n.x * n.x;
        matrix[0, 1] = -2 * n.x * n.y;
        matrix[0, 2] = -2 * n.x * n.z;
        matrix[1, 0] = -2 * n.x * n.y;
        matrix[1, 1] = 1 - 2 * n.y * n.y;
        matrix[1, 2] = -2 * n.y * n.z;
        matrix[2, 0] = -2 * n.x * n.z;
        matrix[2, 1] = -2 * n.z * n.y;
        matrix[2, 2] = 1 - 2 * n.z * n.z;
        return matrix;
    }

    /// <summary>
    /// Obtain the shear matrix
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static Matrix4x4 GetShearXYMatrix(float s, float t)
    {
        //formula (3.7.3)
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 2] = s;
        matrix[1, 2] = t;
        return matrix;
    }

    /// <summary>
    /// Obtain the shear matrix
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static Matrix4x4 GetShearXZMatrix(float s, float t)
    {
        //formula (3.7.4)
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 1] = s;
        matrix[2, 1] = t;
        return matrix;
    }

    /// <summary>
    /// Obtain the shear matrix
    /// </summary>
    /// <param name="s"></param>
    /// <param name="t"></param>
    /// <returns></returns>
    public static Matrix4x4 GetShearYZMatrix(float s, float t)
    {
        //formula (3.7.5)
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[1, 0] = s;
        matrix[2, 0] = t;
        return matrix;
    }

    /// <summary>
    /// Get the move matrix
    /// </summary>
    /// <param name="trans"></param>
    /// <returns></returns>
    public static Matrix4x4 GetTranslationMatrix(Vector3 trans)
    {
        //formula (3.8.1)
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 3] = trans.x;
        matrix[1, 3] = trans.y;
        matrix[2, 3] = trans.z;
        return matrix;
    }

    /// <summary>
    /// Get the projection matrix
    /// </summary>
    /// <param name="pos">point position</param>
    /// <param name="d">projection position</param>
    /// <returns></returns>
    public static Matrix4x4 GetPerspectiveZDMatrix(Vector3 pos, float d)
    {
        //formula (3.13.5)
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = d / pos.z;
        matrix[1, 1] = d / pos.z;
        matrix[2, 2] = 0;
        matrix[2, 3] = d;
        return matrix;
    }

    /// <summary>
    /// Get the projection matrix
    /// </summary>
    /// <param name="d">projection position</param>
    /// <returns></returns>
    public static Matrix4x4 GetPerspectiveDMatrix(float d)
    {
        //formula (3.13.8)
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[3, 2] = 1 / d;
        matrix[3, 3] = 0;
        return matrix;
    }
}
