using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FrustumData
{
    public Vector3 NearRightTop { get; set; }

    public Vector3 NearLeftTop { get; set; }

    public Vector3 NearLeftBottom { get; set; }

    public Vector3 NearRightBottom { get; set; }

    public Vector3 FarRightTop { get; set; }

    public Vector3 FarLeftTop { get; set; }

    public Vector3 FarLeftBottom { get; set; }

    public Vector3 FarRightBottom { get; set; }

    public Vector3 ReferencePoint { get; set; }

    public void Transformation(Matrix4x4 matrix)
    {
        NearRightTop = matrix.MultiplyPoint(NearRightTop);
        NearLeftTop = matrix.MultiplyPoint(NearLeftTop);
        NearLeftBottom = matrix.MultiplyPoint(NearLeftBottom);
        NearRightBottom = matrix.MultiplyPoint(NearRightBottom);

        FarRightTop = matrix.MultiplyPoint(FarRightTop);
        FarLeftTop = matrix.MultiplyPoint(FarLeftTop);
        FarLeftBottom = matrix.MultiplyPoint(FarLeftBottom);
        FarRightBottom = matrix.MultiplyPoint(FarRightBottom);

        ReferencePoint = matrix.MultiplyPoint(ReferencePoint);
    }
}
public class GizmosExtension
{
    public static void DrawFrustum(float fov, float aspect, float zNear, float zFar)
    {
        float radians = (fov / 2) * Mathf.Deg2Rad;
        float halfTan = Mathf.Tan(radians);
        float top = (2 * (zNear) * halfTan) * 0.5f;
        float right = aspect * top;
        float bottom = -top;
        float left = -right;
        DrawFrustum(left, right, bottom, top, zNear, zFar);
    }


    public static void DrawFrustum(float left, float right, float bottom, float top, float zNear, float zFar)
    {
        //use right hand so  negation z
        zNear = -zNear;
        zFar = -zFar;

        FrustumData data = GetFrustumData(left, right, bottom, top, zNear, zFar);
        DrawFrustum(data);
    }

    public static void DrawFrustum(FrustumData data)
    {
        DrawQuad(data.NearRightTop, data.NearLeftTop, data.NearLeftBottom, data.NearRightBottom);

        DrawQuad(data.FarRightTop, data.FarLeftTop, data.FarLeftBottom, data.FarRightBottom);

        Gizmos.DrawLine(data.ReferencePoint, data.FarRightTop);
        Gizmos.DrawLine(data.ReferencePoint, data.FarLeftTop);
        Gizmos.DrawLine(data.ReferencePoint, data.FarLeftBottom);
        Gizmos.DrawLine(data.ReferencePoint, data.FarRightBottom);
    }

    public static FrustumData GetFrustumData(float left, float right, float bottom, float top, float zNear, float zFar)
    {
        FrustumData data = new FrustumData();

        data.NearRightTop = new Vector3(right, top, zNear);
        data.NearLeftTop = new Vector3(left, top, zNear);
        data.NearLeftBottom = new Vector3(left, bottom, zNear);
        data.NearRightBottom = new Vector3(right, bottom, zNear);

        float topFar = top * zFar / zNear;
        float bottomFar = bottom * zFar / zNear;
        float leftFar = left * zFar / zNear;
        float rightFar = right * zFar / zNear;
        data.FarRightTop = new Vector3(rightFar, topFar, zFar);
        data.FarLeftTop = new Vector3(leftFar, topFar, zFar);
        data.FarLeftBottom = new Vector3(leftFar, bottomFar, zFar);
        data.FarRightBottom = new Vector3(rightFar, bottomFar, zFar);

        return data;
    }

    public static void DrawQuad(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
    {
        Gizmos.DrawLine(p1, p2);
        Gizmos.DrawLine(p2, p3);
        Gizmos.DrawLine(p3, p4);
        Gizmos.DrawLine(p4, p1);
    }

    public static void DrawQuad(Vector3 center, float left, float right, float bottom, float top)
    {
        DrawQuad(center + new Vector3(right, top, 0), center + new Vector3(left, top, 0),
            center + new Vector3(left, bottom, 0), center + new Vector3(right, bottom, 0));
    }

    public static void DrawQuad(Vector3 leftBottom, Vector3 rightTop)
    {
        Vector3 center = new Vector3(leftBottom.x + (rightTop.x - leftBottom.x) / 2,
            leftBottom.y + (rightTop.y - leftBottom.y) / 2,
            leftBottom.z + (rightTop.z - leftBottom.z) / 2);
        DrawQuad(center, leftBottom.x, rightTop.x, leftBottom.y, rightTop.y);
    }


    public static void DrawOrthoCube(float left, float right, float bottom, float top, float zNear, float zFar)
    {
        //use right hand so  negation z
        zNear = -zNear;
        zFar = -zFar;

        float scalex = right - left;
        float scaley = top - bottom;
        float scalez = zFar - zNear;
        float centerx = left + (scalex) * 0.5f;
        float centery = bottom + (scaley) * 0.5f;
        float centerz = zNear + (scalez) * 0.5f;
        DrawWireCube(new Vector3(centerx, centery, centerz), new Vector3(scalex, scaley, scalez));

    }
    public static void DrawNormalizedCube()
    {
        DrawWireCube(Vector3.zero, new Vector3(2, 2, 2));
    }

    public static void DrawNormalizedQuad(Vector3 center)
    {
        DrawQuad(center + new Vector3(1, 1, 0), center + new Vector3(-1, 1, 0),
            center + new Vector3(-1, -1, 0), center + new Vector3(1, -1, 0));
    }
    public static void DrawLineWithSphere(Vector3 start, Vector3 end, float radius)
    {
        Gizmos.DrawLine(start, end);
        Gizmos.DrawSphere(start, radius);
        Gizmos.DrawSphere(end, radius);
    }
    public static void DrawWireTriangle(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Gizmos.DrawLine(p1, p2);
        Gizmos.DrawLine(p2, p3);
        Gizmos.DrawLine(p3, p1);
    }



    public static void DrawWirePolygon(Vector2[] points)
    {
        if (points.Length < 2)
            return;

        for (int i = 0; i < points.Length - 1; i++)
        {
            Gizmos.DrawLine(points[i], points[i + 1]);
        }

        if (points.Length > 2)
            Gizmos.DrawLine(points[points.Length - 1], points[0]);
    }


    public static void DrawWireCube(Vector3[] points)
    {
        Gizmos.DrawLine(points[0], points[1]);
        Gizmos.DrawLine(points[1], points[2]);
        Gizmos.DrawLine(points[2], points[3]);
        Gizmos.DrawLine(points[3], points[0]);

        Gizmos.DrawLine(points[4], points[5]);
        Gizmos.DrawLine(points[5], points[6]);
        Gizmos.DrawLine(points[6], points[7]);
        Gizmos.DrawLine(points[7], points[4]);

        Gizmos.DrawLine(points[0], points[4]);
        Gizmos.DrawLine(points[1], points[5]);
        Gizmos.DrawLine(points[2], points[6]);
        Gizmos.DrawLine(points[3], points[7]);
    }

    public static void DrawWireCube(Vector3 center, Vector3 size)
    {
        Vector3[] points = GetCubePoints(center, size);

        DrawWireCube(points);
    }


    public static Vector3[] GetCubePoints(Vector3 center, Vector3 size)
    {
        Vector3[] points = new Vector3[8];
        float halfx = size.x / 2;
        float halfy = size.y / 2;
        float halfz = size.z / 2;
        points[0] = new Vector3(center.x + halfx, center.y + halfy, center.z + halfz);
        points[1] = new Vector3(center.x - halfx, center.y + halfy, center.z + halfz);
        points[2] = new Vector3(center.x - halfx, center.y - halfy, center.z + halfz);
        points[3] = new Vector3(center.x + halfx, center.y - halfy, center.z + halfz);
        points[4] = new Vector3(center.x + halfx, center.y + halfy, center.z - halfz);
        points[5] = new Vector3(center.x - halfx, center.y + halfy, center.z - halfz);
        points[6] = new Vector3(center.x - halfx, center.y - halfy, center.z - halfz);
        points[7] = new Vector3(center.x + halfx, center.y - halfy, center.z - halfz);

        return points;
    }

    public static void DrawLHCoordinate(Vector3 center)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(center, center + new Vector3(1, 0, 0));
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(center, center + new Vector3(0, 0, 1));
        Gizmos.color = Color.green;
        Gizmos.DrawLine(center, center + new Vector3(0, 1, 0));
    }

    public static void DrawLHCoordinate(Vector3 center, float scale)
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(center, center + new Vector3(1, 0, 0) * scale);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(center, center + new Vector3(0, 0, 1) * scale);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(center, center + new Vector3(0, 1, 0) * scale);
    }

    public static void DrawLineWithArrow(Vector3 start, Vector3 end, float arrowLength = 1f)
    {
        Gizmos.DrawLine(start, end);
        Vector3 arrow1 = (start - end).normalized * arrowLength;

        arrow1 = Matrix4x4.Rotate(Quaternion.Euler(0, 0, 30)).MultiplyPoint(arrow1);
        Vector3 arrow2 = (start - end).normalized * arrowLength;
        arrow2 = Matrix4x4.Rotate(Quaternion.Euler(0, 0, -30)).MultiplyPoint(arrow2);
        Gizmos.DrawLine(end, end + arrow1);
        Gizmos.DrawLine(end, end + arrow2);
    }


    public static void DrawBoundingBox(Vector3 min, Vector3 max)
    {
        Vector3 center = (min + max) / 2;
        Vector3 size = new Vector3(max.x - min.x, max.y - min.y, max.z - min.z);
        DrawWireCube(center, size);
    }



    /// <summary>
    /// Draw the plane
    /// </summary>
    /// <param name="p">a point on the plane</param>
    /// <param name="n">surface normals</param>
    /// <param name="drawNormal"></param>
    public static void DrawWirePlane(Vector3 p, Vector3 n, Color nomralColor, Color planeColor, bool drawNormal = false)
    {

        Vector3 v3;
        if (n.normalized != Vector3.forward)
        {
            v3 = Vector3.Cross(n, Vector3.forward).normalized * n.magnitude;

            //debug
            //Gizmos.color = Color.white;
            //Gizmos.DrawSphere(p, 0.1f);
            //Gizmos.DrawLine(p, p + Vector3.forward);
        }
        else
        {
            v3 = Vector3.Cross(n, Vector3.up).normalized * n.magnitude;

            //debug
            //Gizmos.color = Color.white;
            //Gizmos.DrawSphere(p, 0.1f);
            //Gizmos.DrawLine(p, p + Vector3.up);
        }

        if (drawNormal)
        {
            Gizmos.color = nomralColor;
            Gizmos.DrawLine(p, p + n);
        }

        //debug
        //Gizmos.color = Color.blue;
        //Gizmos.DrawLine(Vector3.zero, v3);

        Vector3 corner0 = p + v3;
        Vector3 corner2 = p - v3;
        var q = Quaternion.AngleAxis(90.0f, n);
        v3 = q * v3;

        //debug
        //Gizmos.color = Color.green;
        //Gizmos.DrawLine(Vector3.zero, v3);

        Vector3 corner1 = p + v3;
        Vector3 corner3 = p - v3;

        Gizmos.color = planeColor;
        Gizmos.DrawLine(corner0, corner2);
        Gizmos.DrawLine(corner1, corner3);
        Gizmos.DrawLine(corner0, corner1);
        Gizmos.DrawLine(corner1, corner2);
        Gizmos.DrawLine(corner2, corner3);
        Gizmos.DrawLine(corner3, corner0);
    }

}
