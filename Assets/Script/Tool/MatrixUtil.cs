using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixUtil 
{
   public static Matrix4x4 GetRotateZMatrix(float theta)
    {
        float radian = Mathf.Deg2Rad * theta;
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = Mathf.Cos(radian);
        matrix[0, 1] = -Mathf.Sin(radian);
        matrix[1, 0] = Mathf.Sin(radian);
        matrix[1, 1] = Mathf.Cos(radian);
        return matrix;
    }

    public static Matrix4x4 GetRotateXMatrix(float theta)
    {
        float radian = Mathf.Deg2Rad * theta;
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[1, 1] = Mathf.Cos(radian);
        matrix[1, 2] = -Mathf.Sin(radian);
        matrix[2, 1] = Mathf.Sin(radian);
        matrix[2, 2] = Mathf.Cos(radian);
        return matrix;
    }

    public static Matrix4x4 GetRotateYMatrix(float theta)
    {
        float radian = Mathf.Deg2Rad * theta;
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = Mathf.Cos(radian);
        matrix[0, 2] = Mathf.Sin(radian);
        matrix[2, 0] = -Mathf.Sin(radian);
        matrix[2, 2] = Mathf.Cos(radian);
        return matrix;
    }

    public static Matrix4x4 GetRotateByAxisMatrix(Vector3 n, float theta)
    {
        Matrix4x4 matrix = Matrix4x4.identity;
        float radian = Mathf.Deg2Rad * theta;
        matrix[0, 0] = n.x * n.x * (1 - Mathf.Cos(radian)) + Mathf.Cos(radian);
        matrix[0, 1] = n.x * n.y * (1 - Mathf.Cos(radian)) - n.z * Mathf.Sin(radian);
        matrix[0, 2] = n.x * n.z * (1 - Mathf.Cos(radian)) + n.y * Mathf.Sin(radian);
        matrix[1, 0] = n.x * n.y * (1 - Mathf.Cos(radian)) + n.z * Mathf.Sin(radian);
        matrix[1, 1] = n.y * n.y * (1 - Mathf.Cos(radian)) + Mathf.Cos(radian);
        matrix[1, 2] = n.y * n.z * (1 - Mathf.Cos(radian)) - n.x * Mathf.Sin(radian);
        matrix[2, 0] = n.x * n.z * (1 - Mathf.Cos(radian)) - n.y * Mathf.Sin(radian);
        matrix[2, 1] = n.y * n.z * (1 - Mathf.Cos(radian)) + n.x * Mathf.Sin(radian);
        matrix[2, 2] = n.z * n.z * (1 - Mathf.Cos(radian)) + Mathf.Cos(radian);
        return matrix;
    }

    public static Matrix4x4 GetScaleMatrix(Vector3  scale)
    {
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = scale.x;
        matrix[1, 1] = scale.y;
        matrix[2, 2] = scale.z;
        return matrix;
    }

    public static Matrix4x4 GetScaleByAxisMatrix(Vector3 n, float k)
    {
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

    public static Matrix4x4 GetProjectionXYMatrix()
    {
        Matrix4x4 matrix = Matrix4x4.zero;
        matrix[0, 0] = 1;
        matrix[1, 1] = 1;
        return matrix;
    }

    public static Matrix4x4 GetProjectionXZMatrix()
    {
        Matrix4x4 matrix = Matrix4x4.zero;
        matrix[0, 0] = 1;
        matrix[2, 2] = 1;
        return matrix;
    }

    public static Matrix4x4 GetProjectionYZMatrix()
    {
        Matrix4x4 matrix = Matrix4x4.zero;
        matrix[1, 1] = 1;
        matrix[2, 2] = 1;
        return matrix;
    }

    public static Matrix4x4 GetProjectionByAxisMatrix(Vector3 n)
    {
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

    public static Matrix4x4 GetReflectByAxisMatrix(Vector3 n)
    {
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

    public static Matrix4x4 GetShearXYMatrix(float s, float t)
    {
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 2] = s;
        matrix[1, 2] = t;
        return matrix;
    }

    public static Matrix4x4 GetShearXZMatrix(float s, float t)
    {
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 1] = s;
        matrix[2, 1] = t;
        return matrix;
    }

    public static Matrix4x4 GetShearYZMatrix(float s, float t)
    {
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[1, 0] = s;
        matrix[2, 0] = t;
        return matrix;
    }

    public static Matrix4x4 GetTranslationMatrix(Vector3 trans)
    {
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 3] = trans.x;
        matrix[1, 3] = trans.y;
        matrix[2, 3] = trans.z;
        return matrix;
    }

    public static Matrix4x4 GetPerspectiveZDMatrix(Vector3 pos, float d)
    {
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[0, 0] = d / pos.z;
        matrix[1, 1] = d / pos.z;
        matrix[2, 2] = 0;
        matrix[2, 3] = d;
        return matrix;
    }

    public static Matrix4x4 GetPerspectiveDMatrix(float d)
    {
        Matrix4x4 matrix = Matrix4x4.identity;
        matrix[3, 2] = 1 / d;
        matrix[3, 3] = 0;
        return matrix;
    }
}
