using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AABB3
{
    public Vector3 min;

    public Vector3 max;

    public void SetToEmpety()
    {
        min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
        max = new Vector3(float.MinValue, float.MinValue, float.MinValue);

    }

    public void Add(Vector3 p)
    {

        if (p.x < min.x)
            min.x = p.x;
        if (p.x > max.x)
            max.x = p.x;
        if (p.y < min.y)
            min.y = p.y;
        if (p.y > max.y)
            max.y = p.y;
        if (p.z < min.z)
            min.z = p.z;
        if (p.z > max.z)
            max.z = p.z;
    }
}

[Serializable]
public class IntersectInfo
{
    public bool Intersect { get; set; }

    public float Float1 { get; set; }

    public float Float2 { get; set; }

    public Vector3 Vector1 { get; set; }

    public Vector3 Vector2 { get; set; }
}
public class MathUtil
{
    /// <summary>
    /// Gets the normal vector of a vector
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static Vector2 GetVector2Normal(Vector2 v)
    {
        //formula (5.2.6)
        return new Vector2(-v.y, v.x);
    }

    /// <summary>
    /// Gets the implicit definition of a line
    /// </summary>
    /// <param name="normal"></param>
    /// <param name="point"></param>
    /// <returns></returns>
    public static float GetLine(Vector3 point, Vector3 normal)
    {
        //formula (5.2.2)
        return Vector3.Dot(point, normal);
    }

    /// <summary>
    /// To see if the point is on the line
    /// </summary>
    /// <param name="p"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    public static bool OnLine(Vector3 p, Vector3 n, float d, float error)
    {
        float value = Vector3.Dot(p, n);
        return Mathf.Abs(value - d) < error;
    }

    /// <summary>
    /// Determine if the point is inside the sphere
    /// </summary>
    /// <param name="pos"></param>
    /// <param name="sphereCenter"></param>
    /// <param name="sphereRadius"></param>
    /// <returns></returns>
    public static bool InsideSphere(Vector3 pos, Vector3 sphereCenter, float sphereRadius)
    {
        //formula (5.3.2)
        float r2 = sphereRadius * sphereRadius;
        float value = Mathf.Pow(pos.x - sphereCenter.x, 2) + Mathf.Pow(pos.y - sphereCenter.y, 2) + Mathf.Pow(pos.z - sphereCenter.z, 2);
        return value <= r2;
    }

    /// <summary>
    /// Gets the plane implicit definition parameter
    /// </summary>
    /// <param name="planePoint">point on plane</param>
    /// <param name="planeNormal">plane  normal need normalize</param>
    /// <returns></returns>
    public static float GetPlane(Vector3 planePoint, Vector3 planeNormal)
    {
        //formula (5.5.3)
        return Vector3.Dot(planePoint, planeNormal);
    }

    /// <summary>
    /// To see if the point is on the plane
    /// </summary>
    /// <param name="p"></param>
    /// <param name="n"></param>
    /// <param name="d"></param>
    /// <returns></returns>
    public static bool OnPlane(Vector3 p, Vector3 n, float d, float error)
    {
        float value = Vector3.Dot(p, n);
        return Mathf.Abs(value - d) < error;
    }

    /// <summary>
    /// Get the point closest to the plane
    /// </summary>
    /// <param name="p">p is a point on plane</param>
    /// <param name="n">n is normal</param>
    /// <param name="point">any point </param>
    /// <returns></returns>
    public static float GetPlaneToPointDistance(Vector3 p, Vector3 n, Vector3 point)
    {
        float d = GetPlane(p, n.normalized);
        float distance = Vector3.Dot(point, n.normalized) - d;
        return distance;
    }

    /// <summary>
    /// Get the point closest to the plane
    /// </summary>
    /// <param name="p">point on plane</param>
    /// <param name="n">n is normal</param>
    /// <param name="point">any point</param>
    /// <returns></returns>
    public static Vector3 GetPlaneNearestPoint(Vector3 p, Vector3 n, Vector3 point)
    {
        float d = GetPlane(p, n.normalized);
        float a = Vector3.Dot(point, n.normalized) - d;
        Vector3 pointOnPlane = point - a * n.normalized;
        return pointOnPlane;
    }

    /// <summary>
    /// Get triangle center of barycenter
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <returns></returns>
    public static Vector3 GetTriangleBarycenter(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        //formula (5.10.1)
        return (p1 + p2 + p3) / 3;
    }

    /// <summary>
    /// Get triangle center of heart
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <returns></returns>
    public static Vector3 GetTriangleHeart(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        //formula (5.10.2)
        Vector3 e1 = p2 - p3;
        Vector3 e2 = p3 - p1;
        Vector3 e3 = p1 - p2;
        float p = GetTrianglePerimeter(e1, e2, e3);
        Vector3 numerator = e1.magnitude * p1 + e2.magnitude * p2 + e3.magnitude * p3;
        Vector3 heart = numerator / p;

        return heart;
    }

    /// <summary>
    /// Obtain the radius of the triangle incircle
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <returns></returns>
    public static float GetTriangleIncircleRadius(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Vector3 e1 = p2 - p3;
        Vector3 e2 = p3 - p1;
        Vector3 e3 = p1 - p2;
        float p = GetTrianglePerimeter(e1, e2, e3);
        //formula (5.10.3)
        float r = 2 * GetTriangleArea(e1, e2) / p;
        return r;
    }

    /// <summary>
    /// Get the outer center of the triangle
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <returns></returns>
    public static Vector3 GetTriangleCircumcenter(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Vector3 e1 = p2 - p3;
        Vector3 e2 = p3 - p1;
        Vector3 e3 = p1 - p2;

        //formula (5.10.4)
        float d1 = -Vector3.Dot(e2, e3);
        float d2 = -Vector3.Dot(e3, e1);
        float d3 = -Vector3.Dot(e1, e2);

        float c1 = d2 * d3;
        float c2 = d3 * d1;
        float c3 = d1 * d2;
        float c = c1 + c2 + c3;

        //formula (5.10.5)
        Vector3 numerator = (c2 + c3) * p1 + (c3 + c1) * p2 + (c1 + c2) * p3;
        float denominator = 2 * c;
        Vector3 circumcenter = numerator / denominator;
        return circumcenter;
    }

    /// <summary>
    /// Obtain the radius of the triangle's outer circle
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <returns></returns>
    public static float GetTriangleCrcumcircleRadius(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        Vector3 e1 = p2 - p3;
        Vector3 e2 = p3 - p1;
        Vector3 e3 = p1 - p2;

        //formula (5.10.4)
        float d1 = -Vector3.Dot(e2, e3);
        float d2 = -Vector3.Dot(e3, e1);
        float d3 = -Vector3.Dot(e1, e2);

        float c1 = d2 * d3;
        float c2 = d3 * d1;
        float c3 = d1 * d2;
        float c = c1 + c2 + c3;

        //formula (5.10.6)
        float numerator = Mathf.Sqrt(((d1 + d2) * (d2 + d3) * (d3 + d1)) / c);
        float raidus = numerator / 2;
        return raidus;
    }

    /// <summary>
    /// e1,e2,e3 are the side of a triangle
    /// </summary>
    /// <param name="e1"></param>
    /// <param name="e2"></param>
    /// <param name="e3"></param>
    /// <returns></returns>
    public static float GetTrianglePerimeter(Vector3 e1, Vector3 e2, Vector3 e3)
    {
        //formula (5.7.3)
        return e1.magnitude + e2.magnitude + e3.magnitude;
    }

    /// <summary>
    /// e1,e2,e3 are the side of a triangle
    /// </summary>
    /// <param name="e1"></param>
    /// <param name="e2"></param>
    /// <param name="e3"></param>
    /// <returns></returns>
    public static float GetTriangleArea(Vector3 e1, Vector3 e2, Vector3 e3)
    {
        //formula (5.7.5)
        float perimeter = GetTrianglePerimeter(e1, e2, e3);
        float s = perimeter / 2f;
        float l1 = e1.magnitude;
        float l2 = e2.magnitude;
        float l3 = e3.magnitude;
        float area = Mathf.Sqrt(s * (s - l1) * (s - l2) * (s - l3));
        return area;
    }

    /// <summary>
    /// e1,e2,are the side of a triangle
    /// </summary>
    /// <param name="e1"></param>
    /// <param name="e2"></param>
    /// <returns></returns>
    public static float GetTriangleArea(Vector3 e1, Vector3 e2)
    {
        //formula (5.7.10)
        return Vector3.Cross(e1, e2).magnitude * 0.5f;
    }

    /// <summary>
    /// p1,p2,p3 are vertex of triangle
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static Vector3 GetBarycentricByPoints(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p)
    {
        //formula (5.8.3)
        float numerator1 = (p2.y - p3.y) * (p.x - p3.x) + (p3.x - p2.x) * (p.y - p3.y);
        float numerator2 = (p3.y - p1.y) * (p.x - p3.x) + (p1.x - p3.x) * (p.y - p3.y);
        float denominator = (p2.y - p3.y) * (p1.x - p3.x) + (p3.x - p2.x) * (p1.y - p3.y);
        float lambda1 = numerator1 / denominator;
        float lambda2 = numerator2 / denominator;
        float lambda3 = 1 - lambda1 - lambda2;
        Vector3 barycentric = new Vector3(lambda1, lambda2, lambda3);
        return barycentric;
    }

    /// <summary>
    ///  p1,p2,p3 are vertex of triangle
    /// </summary>
    /// <param name="e1"></param>
    /// <param name="e2"></param>
    /// <param name="e3"></param>
    /// <param name="d1"></param>
    /// <param name="d2"></param>
    /// <param name="d3"></param>
    /// <returns></returns>
    public static Vector3 GetBarycentricBySides(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p)
    {
        //formula (5.9.1)
        Vector2 e1 = p3 - p2;
        Vector2 e2 = p1 - p3;
        Vector2 e3 = p2 - p1;
        Vector3 d1 = p - p1;
        Vector3 d2 = p - p2;
        Vector3 d3 = p - p3;

        //formula (5.9.2)
        Vector3 n = Vector3.Cross(e1, e2).normalized;

        //formula (5.9.3)
        float numerator1 = Vector3.Dot(Vector3.Cross(e1, d3), n);
        float numerator2 = Vector3.Dot(Vector3.Cross(e2, d1), n);
        float numerator3 = Vector3.Dot(Vector3.Cross(e3, d2), n);
        float denominator = Vector3.Dot(Vector3.Cross(e1, e2), n);
        float b1 = numerator1 / denominator;
        float b2 = numerator2 / denominator;
        float b3 = numerator3 / denominator;

        return new Vector3(b1, b2, b3);
    }

    /// <summary>
    /// Calculate the 3d barycentric coordinates
    /// </summary>
    /// <param name="v"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    public static Vector3 GetBarycentric3D(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p, bool debugDraw = false)
    {
        Vector3 d1 = p2 - p1;
        Vector3 d2 = p3 - p2;

        Vector3 n = Vector3.Cross(d1, d2);

        bool xMax = Mathf.Abs(n.x) >= Mathf.Abs(n.y) && Mathf.Abs(n.x) >= Mathf.Abs(n.z);
        bool yMax = Mathf.Abs(n.y) >= Mathf.Abs(n.x) && Mathf.Abs(n.y) >= Mathf.Abs(n.z);
        bool zMax = Mathf.Abs(n.z) >= Mathf.Abs(n.x) && Mathf.Abs(n.z) >= Mathf.Abs(n.y);
        if (debugDraw)
        {
            Gizmos.color = xMax ? Color.red : (yMax ? Color.yellow : Color.blue);
            Vector3 center = GetTriangleBarycenter(p1, p2, p3);
            Gizmos.DrawLine(center, center + n);
        }

        float numerator1 = 0;
        float numerator2 = 0;
        float denominator = 0;
        if (xMax)
        {
            //projection to yz plane
            numerator1 = (p2.y - p3.y) * (p.z - p3.z) + (p3.z - p2.z) * (p.y - p3.y);
            numerator2 = (p3.y - p1.y) * (p.z - p3.z) + (p1.z - p3.z) * (p.y - p3.y);
            denominator = (p2.y - p3.y) * (p1.z - p3.z) + (p3.z - p2.z) * (p1.y - p3.y);
            if (debugDraw)
            {
                GizmosExtension.DrawWireTriangle(new Vector3(0, p1.y, p1.z), new Vector3(0, p2.y, p2.z), new Vector3(0, p3.y, p3.z));
            }
        }
        else if (yMax)
        {
            //projection to xz plane
            numerator1 = (p2.z - p3.z) * (p.x - p3.x) + (p3.x - p2.x) * (p.z - p3.z);
            numerator2 = (p3.z - p1.z) * (p.x - p3.x) + (p1.x - p3.x) * (p.z - p3.z);
            denominator = (p2.z - p3.z) * (p1.x - p3.x) + (p3.x - p2.x) * (p1.z - p3.z);

            if (debugDraw)
            {
                GizmosExtension.DrawWireTriangle(new Vector3(p1.x, 0, p1.z), new Vector3(p2.x, 0, p2.z), new Vector3(p3.x, 0, p3.z));
            }
        }
        else
        {
            //formula (5.8.3)
            //projection to xy plane
            numerator1 = (p2.y - p3.y) * (p.x - p3.x) + (p3.x - p2.x) * (p.y - p3.y);
            numerator2 = (p3.y - p1.y) * (p.x - p3.x) + (p1.x - p3.x) * (p.y - p3.y);
            denominator = (p2.y - p3.y) * (p1.x - p3.x) + (p3.x - p2.x) * (p1.y - p3.y);

            if (debugDraw)
            {
                GizmosExtension.DrawWireTriangle(new Vector3(p1.x, p1.y, 0), new Vector3(p2.x, p2.y, 0), new Vector3(p3.x, p3.y, 0));
            }
        }
        if (denominator == 0.0f)
            return Vector3.zero;

        float lambda1 = numerator1 / denominator;
        float lambda2 = numerator2 / denominator;
        float lambda3 = 1 - lambda1 - lambda2;
        Vector3 barycentric = new Vector3(lambda1, lambda2, lambda3);
        return barycentric;
    }

    /// <summary>
    /// Gets the closest distance from the implicit line
    /// </summary>
    /// <param name="q">arbitrary point</param>
    /// <param name="d">line implicit parameter</param>
    /// <param name="n">need normalize</param>
    /// <returns></returns>
    public static float GetNearestDistanceToImplicitLine(Vector3 q, float d, Vector3 n)
    {
        //formula (6.0.1)
        float distance = d - Vector3.Dot(q, n);
        return distance;
    }

    /// <summary>
    /// Gets the closest point of the implicit line
    /// </summary>
    /// <param name="q">arbitrary point</param>
    /// <param name="d">line implicit parameter</param>
    /// <param name="n">need normalize</param>
    /// <returns></returns>
    public static Vector3 GetNearestPointToImplicitLine(Vector3 q, float d, Vector3 n)
    {
        //formula (6.0.1)
        float distance = GetNearestDistanceToImplicitLine(q, d, n);
        Vector3 point = q + distance * n;
        return point;
    }

    /// <summary>
    /// Get the point closest to the ray
    /// </summary>
    /// <param name="start">ray start point</param>
    /// <param name="direction">ray direction need normalize</param>
    /// <param name="fixedpoint">arbitrary point </param>
    /// <param name="info">intersect info </param>
    /// <returns></returns>
    public static void GetNearstPointToLengthRay(Vector3 start, Vector3 direction, Vector3 fixedpoint, IntersectInfo info)
    {
        //formula (6.1.1)
        float t = Vector3.Dot(direction, fixedpoint - start);
        Vector3 point = start + t * direction;

        info.Intersect = true;
        info.Float1 = t;
        info.Vector1 = point;
    }

    /// <summary>
    /// Get the point closest to the ray
    /// </summary>
    /// <param name="start">ray start point</param>
    /// <param name="direction">ray direction</param>
    /// <param name="fixedpoint">arbitrary point</param>
    /// <param name="info">intersect info</param>
    /// <returns></returns>
    public static void GetNearstPointToTRay(Vector3 start, Vector3 direction, Vector3 fixedpoint, IntersectInfo info)
    {
        //formula (6.1.1) (6.1.2)
        float ddot = Vector3.Dot(direction, fixedpoint - start);
        float t = ddot / direction.magnitude;
        Vector3 point = start + t * direction.normalized;

        info.Intersect = true;
        info.Float1 = t;
        info.Vector1 = point;
    }

    /// <summary>
    /// Gets the closest point of the plane
    /// </summary>
    /// <param name="planePoint">a point on the plane</param>
    /// <param name="planeNormal">plane normals need to be normalized</param>
    /// <param name="fixedPoint">arbitrary point</param>
    /// <param name="info">intersect info</param>
    /// <returns></returns>
    public static void GetNearstPointToPlane(Vector3 planePoint, Vector3 planeNormal, Vector3 fixedPoint, IntersectInfo info)
    {
        float d = GetPlane(planePoint, planeNormal);

        //formula (5.6.7)
        float a = (d - Vector3.Dot(fixedPoint, planeNormal));

        Vector3 point = fixedPoint + a * planeNormal;

        info.Intersect = true;
        info.Float1 = a;
        info.Vector1 = point;
    }

    /// <summary>
    /// Get the closest point to the ball
    /// </summary>
    /// <param name="center">centre of sphere</param>
    /// <param name="radius">radius of sphere</param>
    /// <param name="fixedPoint">arbitrary point</param>
    /// <param name="info">intersect info</param>
    /// <returns></returns>
    public static void GetNearstPointToSphere(Vector3 center, float radius, Vector3 fixedPoint, IntersectInfo info)
    {
        // formula (6.3.1)
        Vector3 d = center - fixedPoint;
        float t = (d.magnitude - radius) / d.magnitude;
        Vector3 point = fixedPoint + t * d;

        info.Intersect = true;
        info.Float1 = t;
        info.Vector1 = point;
    }

    /// <summary>
    /// Gets the nearest point of the AABB
    /// </summary>
    /// <param name="box">bounding box</param>
    /// <param name="fixedPoint">arbitrary point</param>
    /// <param name="info">intersect info</param>
    /// <returns></returns>
    public static void GetNearstPointToAABB(AABB3 box, Vector3 fixedPoint, IntersectInfo info)
    {
        Vector3 point = fixedPoint;
        if (point.x < box.min.x)
            point.x = box.min.x;
        else if (point.x > box.max.x)
            point.x = box.max.x;

        if (point.y < box.min.y)
            point.y = box.min.y;
        else if (point.y > box.max.y)
            point.y = box.max.y;

        if (point.z < box.min.z)
            point.z = box.min.z;
        else if (point.z > box.max.z)
            point.z = box.max.z;

        info.Intersect = true;
        info.Vector1 = point;
    }

    /// <summary>
    /// Obtain the intersection of implicit lines
    /// </summary>
    /// <param name="normal1">line 1  normal</param>
    /// <param name="d1">line 1  value</param>
    /// <param name="normal2">line 2  normal</param>
    /// <param name="d2">line 2  value</param>
    /// <returns></returns>
    public static void GetImplicitLineIntersection(Vector2 normal1, float d1, Vector2 normal2, float d2, IntersectInfo info)
    {
        info.Intersect = false;

        //formula (6.5.1)
        float numerator1 = normal2.y * d1 - normal1.y * d2;
        float numerator2 = normal1.x * d2 - normal2.x * d1;
        float denominator = normal1.x * normal2.y - normal2.x * normal1.y;
        if (denominator == 0.0f)
            return;

        float x = numerator1 / denominator;
        float y = numerator2 / denominator;

        info.Intersect = true;
        info.Vector1 = new Vector3(x, y, 0);
    }

    /// <summary>
    /// Get the intersection of the two rays
    /// </summary>
    /// <param name="point1">ray starting point</param>
    /// <param name="direction1">ray direction need normalize</param>
    /// <param name="point2">ray starting point</param>
    /// <param name="direction2">ray direction need normalize</param>
    /// <param name="info">intersect info</param>
    /// <returns></returns>
    public static void GetRayIntersection(Vector3 point1, Vector3 direction1, Vector3 point2, Vector3 direction2, IntersectInfo info)
    {
        info.Intersect = false;

        //formula (6.6.1)
        float numerator1 = Vector3.Dot(Vector3.Cross((point2 - point1), direction2), Vector3.Cross(direction1, direction2));

        //formula (6.6.2)
        float numerator2 = Vector3.Dot(Vector3.Cross((point2 - point1), direction1), Vector3.Cross(direction1, direction2));
        float denominator = Mathf.Pow(Vector3.Cross(direction1, direction2).magnitude, 2);
        if (denominator == 0.0f)
            return;

        float t1 = numerator1 / denominator;
        float t2 = numerator2 / denominator;
        Vector3 p1 = point1 + t1 * direction1;
        Vector3 p2 = point2 + t2 * direction2;
        info.Intersect = true;
        info.Float1 = t1;
        info.Float2 = t2;
        info.Vector1 = p1;
        info.Vector2 = p2;
    }

    /// <summary>
    /// Get rays and plane intersection points
    /// </summary>
    /// <param name="rayStart">ray start point</param>
    /// <param name="rayDirection">ray direction need normalize </param>
    /// <param name="planeNormal">plane normal</param>
    /// <param name="planeD">plane implicit parameter</param>
    /// <param name="info">intersect info</param>
    /// <returns></returns>
    public static void GetRayToPlaneIntersection(Vector3 rayStart, Vector3 rayDirection, Vector3 planeNormal, float planeD, bool reverseIntersect, IntersectInfo info)
    {
        info.Intersect = false;

        //formula (6.7.1)
        float numerator = planeD - Vector3.Dot(rayStart, planeNormal);
        float denominator = Vector3.Dot(rayDirection, planeNormal);
        //the ray is parallel to the plane
        if (denominator == 0.0f)
            return;

        //check allow reverse intersect 
        if (!reverseIntersect && denominator > 0)
            return;

        float t = numerator / denominator;
        Vector3 point = rayStart + t * rayDirection;

        info.Intersect = true;
        info.Float1 = t;
        info.Vector1 = point;
    }

    /// <summary>
    /// Obtain the intersection of three planes
    /// </summary>
    /// <param name="point1">point on plane</param>
    /// <param name="normal1">plane normal</param>
    /// <param name="point2">point on plane</param>
    /// <param name="normal2">plane normal</param>
    /// <param name="point3">point on plane</param>
    /// <param name="normal3">plane normal</param>
    /// <param name="info">intersect info</param>
    /// <returns></returns>
    public static void GetThreePlanesIntersection(Vector3 point1, Vector3 normal1, Vector3 point2, Vector3 normal2, Vector3 point3, Vector3 normal3, IntersectInfo info)
    {
        info.Intersect = false;

        float d1 = GetPlane(point1, normal1);
        float d2 = GetPlane(point2, normal2);
        float d3 = GetPlane(point3, normal3);

        //formula (6.8.1)
        Vector3 numerator = d1 * Vector3.Cross(normal2, normal3) + d2 * Vector3.Cross(normal3, normal1) + d3 * Vector3.Cross(normal1, normal2);
        float denominator = Vector3.Dot(Vector3.Cross(normal1, normal2), normal3);
        if (denominator == 0.0f)
            return;

        Vector3 point = numerator / denominator;

        info.Intersect = true;
        info.Vector1 = point;
    }

    /// <summary>
    /// Get the point at which the ray intersects the sphere
    /// </summary>
    /// <param name="rayStart">ray start point</param>
    /// <param name="rayDirection">ray direction need normalize</param>
    /// <param name="sphereCenter">sphere center</param>
    /// <param name="sphereRadius">sphere radius</param>
    /// <param name="info">intersect info</param>
    /// <returns></returns>
    public static void GetRayToSphereIntersection(Vector3 rayStart, Vector3 rayDirection, Vector3 sphereCenter, float sphereRadius, IntersectInfo info)
    {
        info.Intersect = false;

        //formula (6.9.1)
        Vector3 e = sphereCenter - rayStart;

        //formula (6.9.2)
        float a = Vector3.Dot(e, rayDirection);

        //formula (6.9.3)
        float f = sphereRadius * sphereRadius - e.magnitude * e.magnitude + a * a;
        if (f < 0)
            return;

        //formula (6.9.4)
        float t = a - Mathf.Sqrt(f);
        Vector3 point = rayStart + t * rayDirection;

        info.Intersect = true;
        info.Float1 = t;
        info.Vector1 = point;
    }

    /// <summary>
    /// Determine whether two sphere intersect
    /// </summary>
    /// <param name="center1">sphere center</param>
    /// <param name="radius1">sphere radius</param>
    /// <param name="center2">sphere center</param>
    /// <param name="radius2">sphere radius</param>
    /// <param name="info">intersect info</param>
    /// <returns></returns>
    public static void GetStaticSphereIntersect(Vector3 center1, float radius1, Vector3 center2, float radius2, IntersectInfo info)
    {
        //(6.10.2) 
        float distance = Mathf.Pow((center2.x - center1.x), 2) + Mathf.Pow((center2.y - center1.y), 2) + Mathf.Pow((center2.z - center1.z), 2);

        //float distance = (center2 - center1).magnitude;
        //(6.10.1) 
        if (distance < Mathf.Pow(radius1 + radius2, 2))
            info.Intersect = true;
        else
            info.Intersect = false;
    }

    /// <summary>
    /// Get the dynamic sphere intersection
    /// </summary>
    /// <param name="dynamicCenter">dynamic sphere center</param>
    /// <param name="dynamicRadius">dynamic sphere radius</param>
    /// <param name="moveDirection">move direction need normalize</param>
    /// <param name="moveDistance">move distance</param>
    /// <param name="staticCenter">static sphere center</param>
    /// <param name="staticRadius">static sphere radius</param>
    /// <param name="info">intersect info</param>
    /// <returns></returns>
    public static void GetDynamicSphereIntersect(Vector3 dynamicCenter, float dynamicRadius, Vector3 moveDirection, Vector3 staticCenter, float staticRadius, IntersectInfo info)
    {
        info.Intersect = false;

        //formula (6.11.1)
        Vector3 e = staticCenter - dynamicCenter;

        //formula (6.11.2)
        float r = dynamicRadius + staticRadius;

        Vector3 d = moveDirection;

        //formula (6.11.3)
        float radical = Mathf.Pow(Vector3.Dot(e, d), 2) - (Vector3.Dot(e, e) - r * r);
        if (radical < 0)
            return;

        float t = Vector3.Dot(e, d) - Mathf.Sqrt(radical);

        Vector3 point = dynamicCenter + t * moveDirection;

        info.Intersect = true;
        info.Float1 = t;
        info.Vector1 = point;
    }

    /// <summary>
    /// Determine whether the sphere and the bounding box intersect
    /// </summary>
    /// <param name="center">sphere center</param>
    /// <param name="radius">sphere radius</param>
    /// <param name="box">bounding box</param>
    /// <param name="info">intersect Info</param>
    /// <returns></returns>
    public static void GetSphereToAABBIntersect(Vector3 center, float radius, AABB3 box, IntersectInfo info)
    {
        //formula (6.12.1) (6.12.2)
        bool xcheck = center.x >= (box.min.x - radius) && center.x <= (box.max.x + radius);
        bool ycheck = center.y >= (box.min.y - radius) && center.y <= (box.max.y + radius);
        bool zcheck = center.z >= (box.min.z - radius) && center.z <= (box.max.z + radius);

        if (xcheck && ycheck && zcheck)
            info.Intersect = true;
        else
            info.Intersect = false;
    }

    /// <summary>
    /// Determine whether a ball and a plane intersect
    /// </summary>
    /// <param name="planeNormal">plane normal need normalize</param>
    /// <param name="planeD">plane parameter</param>
    /// <param name="sphereCenter">sphere center</param>
    /// <param name="sphereRadius">sphere radius</param>
    /// <param name="info">intersect info</param>
    /// <returns></returns>
    public static void GetSphereToPlaneIntersect(Vector3 planeNormal, float planeD, Vector3 sphereCenter, float sphereRadius, IntersectInfo info)
    {
        //formula (5.6.6)
        float d = Vector3.Dot(sphereCenter, planeNormal) - planeD;

        if (Mathf.Abs(d) <= sphereRadius)
            info.Intersect = true;
        else
            info.Intersect = false;
    }

    /// <summary>
    /// Determine which side of the plane the sphere is on
    /// < 0 The sphere is under the plane
    /// > 0 The sphere is on the plane
    /// =0 The sphere is in plane
    /// </summary>
    /// <param name="planeNormal">plane normal need normalize</param>
    /// <param name="planeD">plane parameter</param>
    /// <param name="sphereCenter">sphere center</param>
    /// <param name="sphereRadius">sphere radius</param>
    /// <returns></returns>
    public static int GetSphereToPlaneSide(Vector3 planeNormal, float planeD, Vector3 sphereCenter, float sphereRadius)
    {
        float d = Vector3.Dot(sphereCenter, planeNormal) - planeD;

        if (d >= sphereRadius)
            return 1;

        if (d < -sphereRadius)
            return -1;

        return 0;
    }

    /// <summary>
    /// Get the sphere and plane intersection points
    /// </summary>
    /// <param name="sphereCenter">sphere center</param>
    /// <param name="sphereRadius">sphere radius</param>
    /// <param name="sphereDirection">sphere move direction need normalize</param>
    /// <param name="planePoint">point on plane</param>
    /// <param name="planeNormal">plane normal need normalize</param>
    /// <param name="info">intersect info</param>
    /// <returns></returns>
    public static void GetDynamicSphereToPlane(Vector3 sphereCenter, float sphereRadius, Vector3 sphereDirection, Vector3 planePoint, Vector3 planeNormal, IntersectInfo info)
    {
        info.Intersect = false;

        float planeD = GetPlane(planePoint, planeNormal);

        //formula (6.14.1)
        float numerator = planeD - Vector3.Dot(sphereCenter, planeNormal) + sphereRadius;
        float denominator = Vector3.Dot(sphereDirection, planeNormal);

        //the ray is parallel to the plane
        if (denominator == 0.0f)
            return;

        float t = numerator / denominator;
        Vector3 point = sphereCenter + t * sphereDirection;

        info.Intersect = true;
        info.Float1 = t;
        info.Vector1 = point;
    }

    /// <summary>
    /// Determine that the ray intersects the triangle
    /// </summary>
    /// <param name="rayStart">ray start</param>
    /// <param name="rayDirection">ray direction need normalize</param>
    /// <param name="p0">triangle point</param>
    /// <param name="p1">triangle point</param>
    /// <param name="p2">triangle point</param>
    /// <param name="info">intersect info</param>
    /// <returns></returns>
    public static void GetRayToTriangleIntersection(Vector3 rayStart, Vector3 rayDirection, Vector3 p0, Vector3 p1, Vector3 p2, IntersectInfo info)
    {
        info.Intersect = false;
        Vector3 e1 = p1 - p0;
        Vector3 e2 = p2 - p1;

        Vector3 n = Vector3.Cross(e1, e2);

        //debug
        //Gizmos.color = Color.yellow;
        //Vector3 barycenter = GetTriangleBarycenter(p0,p1,p2);
        //Gizmos.DrawLine(barycenter,barycenter + n);

        float denominator = Vector3.Dot(n, rayDirection);
        //In almost the same direction
        if (denominator >= 0.0f)
            return;

        //formula (6.7.1)
        //obtaining plane parameters
        float d = Vector3.Dot(n, p0);
        //get the t value at the intersection of the plane
        float numerator = d - Vector3.Dot(n, rayStart);
        //ray origin on the backside of the ploygon
        if (numerator > 0.0f)
            return;

        float t = numerator / denominator;
        Vector3 point = rayStart + t * rayDirection;
        Vector3 barycentric = GetBarycentric3D(p0, p1, p2, point);
        if (barycentric.x < 0 || barycentric.y < 0 || barycentric.z < 0)
            return;

        info.Intersect = true;
        info.Float1 = t;
        info.Vector1 = point;
    }

    /// <summary>
    /// Get the intersection of the ray and the cube
    /// </summary>
    /// <param name="rayStart">ray start</param>
    /// <param name="rayDelta">ray direction and length</param>
    /// <param name="box">cube</param>
    /// <param name="info">result info</param>
    public static void GetRayToAABBIntersection(Vector3 rayStart, Vector3 rayDelta, AABB3 box, IntersectInfo info)
    {
        info.Intersect = false;

        bool inside = true;
        float xt = 0;
        float xn = 0;
        if (rayStart.x < box.min.x)
        {
            xt = box.min.x - rayStart.x;
            if (xt > rayDelta.x)
                return;
            xt = xt / rayDelta.x;
            inside = false;
            xn = -1.0f;
        }
        else if (rayStart.x > box.max.x)
        {
            xt = box.max.x - rayStart.x;
            if (xt < rayDelta.x)
                return;
            xt = xt / rayDelta.x;
            inside = false;
            xn = 1.0f;
        }
        else
        {
            xt = -1.0f;
        }

        float yt = 0;
        float yn = 0;
        if (rayStart.y < box.min.y)
        {
            yt = box.min.y - rayStart.y;
            if (yt > rayDelta.y)
                return;
            yt = yt / rayDelta.y;
            inside = false;
            yn = -1.0f;
        }
        else if (rayStart.y > box.max.y)
        {
            yt = box.max.y - rayStart.y;
            if (yt < rayDelta.y)
                return;
            yt = yt / rayDelta.y;
            inside = false;
            yn = 1.0f;
        }
        else
        {
            yt = -1.0f;
        }

        float zt = 0;
        float zn = 0;
        if (rayStart.z < box.min.z)
        {
            zt = box.min.z - rayStart.z;
            if (zt > rayDelta.z)
                return;
            zt = zt / rayDelta.z;
            inside = false;
            zn = -1.0f;
        }
        else if (rayStart.z > box.max.z)
        {
            zt = box.max.z - rayStart.z;
            if (zt < rayDelta.z)
                return;
            zt = zt / rayDelta.z;
            inside = false;
            zn = 1.0f;
        }
        else
        {
            zt = -1.0f;
        }

        if (inside)
        {
            return;
        }

        int which = 0;
        float t = xt;
        if (yt > t)
        {
            which = 1;
            t = yt;
        }

        if (zt > t)
        {
            which = 2;
            t = zt;
        }

        float x, y, z;
        switch (which)
        {
            case 0:
                //it intersects the yz plane
                y = rayStart.y + t * rayDelta.y;
                if (y < box.min.y || y > box.max.y)
                    return;
                z = rayStart.z + t * rayDelta.z;
                if (z < box.min.z || z > box.max.z)
                    return;
                break;
            case 1:
                //it intersects the xz plane
                x = rayStart.x + t * rayDelta.x;
                if (x < box.min.x || x > box.max.x)
                    return;
                z = rayStart.z + t * rayDelta.z;
                if (z < box.min.z || z > box.max.z)
                    return;
                break;
            case 2:
                //it intersects the xy plane
                x = rayStart.x + t * rayDelta.x;
                if (x < box.min.x || x > box.max.x)
                    return;
                y = rayStart.y + t * rayDelta.y;
                if (y < box.min.y || y > box.max.y)
                    return;
                break;
            default:
                break;
        }

        info.Intersect = true;
        info.Float1 = t;
        info.Vector1 = rayStart + t * rayDelta;
    }

    /// <summary>
    /// Gets the intersection of two bounding boxes
    /// </summary>
    /// <param name="box1"></param>
    /// <param name="box2"></param>
    /// <param name="info"></param>
    public static void GetStaticAABBIntersection(AABB3 box1, AABB3 box2, IntersectInfo info)
    {
        info.Intersect = false;
        if (box1.min.x > box2.max.x)
            return;
        if (box1.max.x < box2.min.x)
            return;
        if (box1.min.y > box2.max.y)
            return;
        if (box1.max.y < box2.min.y)
            return;
        if (box1.min.z > box2.max.z)
            return;
        if (box1.max.z < box2.min.z)
            return;

        info.Intersect = true;
        info.Vector1 = new Vector3(Mathf.Max(box1.min.x, box2.min.x), Mathf.Max(box1.min.y, box2.min.y), Mathf.Max(box1.min.z, box2.min.z));
        info.Vector2 = new Vector3(Mathf.Min(box1.max.x, box2.max.x), Mathf.Min(box1.max.y, box2.max.y), Mathf.Min(box1.max.z, box2.max.z));
    }

    /// <summary>
    /// Gets the time when the enclosing boxes intersect
    /// </summary>
    /// <param name="stationaryBox">stationary box</param>
    /// <param name="movingBox">moving box</param>
    /// <param name="direction">move direction</param>
    /// <param name="info">intersect info</param>
    public static void GetDynamicAABBIntersection(AABB3 stationaryBox, AABB3 movingBox, Vector3 direction, IntersectInfo info)
    {
        info.Intersect = false;

        float tEnter = 0.0f;
        float tLeave = 1.0f;

        //check x axis
        if (direction.x == 0.0f)
        {
            if (stationaryBox.min.x >= movingBox.max.x || stationaryBox.max.x <= movingBox.min.x)
                return;
        }
        else
        { 
            float oneOverD = 1.0f / direction.x;
            //formula (6.18.1)
            float xEnter = (stationaryBox.min.x - movingBox.max.x) * oneOverD;

            //formula (6.18.2)
            float xLeave = (stationaryBox.max.x - movingBox.min.x) * oneOverD;

            if (xEnter > xLeave)
                Swap(ref xEnter, ref xLeave);

            if (xEnter > tEnter)
                tEnter = xEnter;
            if (xLeave < tLeave)
                tLeave = xLeave;

            //overlap is empty
            if (tEnter > tLeave)
                return;
        }

        //check y axis
        if (direction.y == 0.0f)
        {
            if (stationaryBox.min.y >= movingBox.max.y || stationaryBox.max.y <= movingBox.min.y)
                return;
        }
        else
        {
            float oneOverD = 1.0f / direction.y;

            float yEnter = (stationaryBox.min.y - movingBox.max.y) * oneOverD;
            float yLeave = (stationaryBox.max.y - movingBox.min.y) * oneOverD;

            if (yEnter > yLeave)
                Swap(ref yEnter, ref yLeave);

            if (yEnter > tEnter)
                tEnter = yEnter;
            if (yLeave < tLeave)
                tLeave = yLeave;

            if (tEnter > tLeave)
                return;
        }

        //check z axis
        if (direction.z == 0.0f)
        {
            if (stationaryBox.min.z >= movingBox.max.z || stationaryBox.max.z <= movingBox.min.z)
                return;
        }
        else
        {
            float oneOverD = 1.0f / direction.z;

            float zEnter = (stationaryBox.min.z - movingBox.max.z) * oneOverD;
            float zLeave = (stationaryBox.max.z - movingBox.min.z) * oneOverD;

            if (zEnter > zLeave)
                Swap(ref zEnter, ref zLeave);

            if (zEnter > tEnter)
                tEnter = zEnter;
            if (zLeave < tLeave)
                tLeave = zLeave;

            if (tEnter > tLeave)
                return;
        }

        info.Intersect = true;
        info.Float1 = tEnter;
        info.Vector1 = movingBox.min + tEnter * direction;
        info.Vector2 = movingBox.max + tEnter * direction;
    }

    public static void Swap(ref float a, ref float b)
    {
        float temp = a;
        a = b;
        b = temp;
    }
}
