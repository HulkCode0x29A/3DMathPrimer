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
public class MathUtil
{
    /// <summary>
    /// Gets the normal vector of a vector
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    public static Vector2 GetVector2Normal(Vector2 v)
    {
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
    /// Gets the plane implicit definition parameter
    /// </summary>
    /// <param name="planePoint">point on plane</param>
    /// <param name="planeNormal">plane  normal</param>
    /// <returns></returns>
    public static float GetPlane(Vector3 planePoint, Vector3 planeNormal)
    {
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
    /// Get triangle center of gravity
    /// </summary>
    /// <param name="p1"></param>
    /// <param name="p2"></param>
    /// <param name="p3"></param>
    /// <returns></returns>
    public static Vector3 GetTriangleBarycenter(Vector3 p1, Vector3 p2, Vector3 p3)
    {
        return (p1 + p2 + p3) / 3;
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
        Vector2 e1 = p3 - p2;
        Vector2 e2 = p1 - p3;
        Vector2 e3 = p2 - p1;
        Vector3 d1 = p - p1;
        Vector3 d2 = p - p2;
        Vector3 d3 = p - p3;
        Vector3 n = Vector3.Cross(e1, e2).normalized;
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
    /// <param name="q"></param>
    /// <param name="d"></param>
    /// <param name="n"></param>
    /// <returns></returns>
    public static float GetNearestDistanceToImplicitLine(Vector3 q, float d, Vector3 n)
    {
        float distance = d - Vector3.Dot(q, n);
        return distance;
    }

    /// <summary>
    /// Gets the closest point of the implicit line
    /// </summary>
    /// <returns></returns>
    public static Vector3 GetNearestPointToImplicitLine(Vector3 q, float d, Vector3 n)
    {
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
    /// <returns></returns>
    public static Vector3 GetNearstPointToLengthRay(Vector3 start, Vector3 direction, Vector3 fixedpoint)
    {
        Vector3 point = start + (Vector3.Dot(direction, fixedpoint - start)) * direction;
        return point;
    }

    /// <summary>
    /// Get the point closest to the ray
    /// </summary>
    /// <param name="start">ray start point</param>
    /// <param name="direction">ray direction</param>
    /// <param name="fixedpoint">arbitrary point</param>
    /// <returns></returns>
    public static Vector3 GetNearstPointToTRay(Vector3 start, Vector3 direction, Vector3 fixedpoint)
    {
        Vector3 point = start + (Vector3.Dot(direction, fixedpoint - start) / direction.magnitude) * direction.normalized;
        return point;
    }

    /// <summary>
    /// Gets the closest point of the plane
    /// </summary>
    /// <param name="planePoint">a point on the plane</param>
    /// <param name="planeNormal">plane normals need to be normalized</param>
    /// <param name="fixedPoint">arbitrary point</param>
    /// <returns></returns>
    public static Vector3 GetNearstPointToPlane(Vector3 planePoint, Vector3 planeNormal, Vector3 fixedPoint)
    {
        float d = GetPlane(planePoint, planeNormal);
        Vector3 point = fixedPoint + (d - Vector3.Dot(fixedPoint, planeNormal)) * planeNormal;
        return point;
    }

    /// <summary>
    /// Get the closest point to the ball
    /// </summary>
    /// <param name="center">centre of sphere</param>
    /// <param name="fixedPoint">arbitrary point</param>
    /// <param name="radius">radius of sphere</param>
    /// <returns></returns>
    public static Vector3 GetNearstPointToSphere(Vector3 center, Vector3 fixedPoint, float radius)
    {
        Vector3 d = center - fixedPoint;
        Vector3 point = fixedPoint + ((d.magnitude - radius) / d.magnitude) * d;
        return point;
    }

    /// <summary>
    /// Gets the nearest point of the AABB
    /// </summary>
    /// <param name="box">bounding box</param>
    /// <param name="fixedPoint">arbitrary point</param>
    /// <returns></returns>
    public static Vector3 GetNearstPointToAABB(AABB3 box, Vector3 fixedPoint)
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

        return point;
    }

    /// <summary>
    /// Obtain the intersection of implicit lines
    /// </summary>
    /// <param name="normal1">line 1  normal</param>
    /// <param name="d1">line 1  value</param>
    /// <param name="normal2">line 2  normal</param>
    /// <param name="d2">line 2  value</param>
    /// <returns></returns>
    public static Vector2 GetImplicitLineIntersection(Vector2 normal1, float d1, Vector2 normal2, float d2)
    {
        float numerator1 = normal2.y * d1 - normal1.y * d2;
        float numerator2 = normal1.x * d2 - normal2.x * d1;
        float denominator = normal1.x * normal2.y - normal2.x * normal1.y;
        if (denominator == 0.0f)
            return Vector2.zero;

        float x = numerator1 / denominator;
        float y = numerator2 / denominator;
        Vector2 point = new Vector3(x, y);
        return point;
    }

    /// <summary>
    /// Get the intersection of the two rays
    /// </summary>
    /// <param name="point1">ray starting point</param>
    /// <param name="direction1">ray direction</param>
    /// <param name="point2">ray starting point</param>
    /// <param name="direction2">ray direction</param>
    /// <returns></returns>
    public static Vector3[] GetRayIntersection(Vector3 point1, Vector3 direction1, Vector3 point2, Vector3 direction2)
    {
        float numerator1 = Vector3.Dot(Vector3.Cross((point2 - point1), direction2), Vector3.Cross(direction1, direction2));
        float numerator2 = Vector3.Dot(Vector3.Cross((point2 - point1), direction1), Vector3.Cross(direction1, direction2));
        float denominator = Mathf.Pow(Vector3.Cross(direction1, direction2).magnitude, 2);
        if (denominator == 0.0f)
            return new Vector3[] { Vector3.zero, Vector3.zero };

        float t1 = numerator1 / denominator;
        float t2 = numerator2 / denominator;
        Vector3 p1 = point1 + t1 * direction1;
        Vector3 p2 = point2 + t2 * direction2;
        return new Vector3[] { p1, p2 };
    }

    /// <summary>
    /// Get rays and plane intersection points
    /// </summary>
    /// <param name="rayStart">ray start point</param>
    /// <param name="rayDirection">ray direction </param>
    /// <param name="planeNormal">plane normal</param>
    /// <param name="planeD">plane implicit parameter</param>
    /// <returns></returns>
    public static Vector3 GetRayToPlaneIntersection(Vector3 rayStart, Vector3 rayDirection, Vector3 planeNormal, float planeD)
    {
        float numerator = planeD - Vector3.Dot(rayStart, planeNormal);
        float denominator = Vector3.Dot(rayDirection, planeNormal);
        if (denominator == 0.0f)
            return Vector3.zero;

        float t = numerator / denominator;
        Vector3 point = rayStart + t * rayDirection;
        return point;
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
    /// <returns></returns>
    public static Vector3 GetThreePlanesIntersection(Vector3 point1, Vector3 normal1, Vector3 point2, Vector3 normal2, Vector3 point3, Vector3 normal3)
    {
        float d1 = GetPlane(point1, normal1);
        float d2 = GetPlane(point2, normal2);
        float d3 = GetPlane(point3, normal3);
        Vector3 numerator = d1 * Vector3.Cross(normal2, normal3) + d2 * Vector3.Cross(normal3, normal1) + d3 * Vector3.Cross(normal1, normal2);
        float denominator = Vector3.Dot(Vector3.Cross(normal1, normal2), normal3);
        Vector3 point = numerator / denominator;
        return point;
    }

    /// <summary>
    /// Get the point at which the ray intersects the sphere
    /// </summary>
    /// <param name="rayStart">ray start point</param>
    /// <param name="rayDirection">ray direction need normalize</param>
    /// <param name="sphereCenter">sphere center</param>
    /// <param name="sphereRadius">sphere radius</param>
    /// <returns></returns>
    public static Vector3 GetRayToSphereIntersection(Vector3 rayStart, Vector3 rayDirection, Vector3 sphereCenter, float sphereRadius)
    {
        Vector3 e = sphereCenter - rayStart;
        float a = Vector3.Dot(e, rayDirection);
        float f = sphereRadius * sphereRadius - e.magnitude * e.magnitude + a * a;
        if (f < 0)
            return Vector3.zero;

        float t = a - Mathf.Sqrt(f);
        Vector3 point = rayStart + t * rayDirection;
        return point;
    }

    /// <summary>
    /// Determine whether two sphere intersect
    /// </summary>
    /// <param name="center1">sphere center</param>
    /// <param name="radius1">sphere radius</param>
    /// <param name="center2">sphere center</param>
    /// <param name="radius2">sphere radius</param>
    /// <returns></returns>
    public static bool GetStaticSphereIntersect(Vector3 center1, float radius1, Vector3 center2, float radius2)
    {
        float distance = (center2 - center1).magnitude;
        if (distance * distance < Mathf.Pow(radius1 + radius2, 2))
            return true;
        else
            return false;
    }

    /// <summary>
    /// Get the dynamic sphere intersection
    /// </summary>
    /// <param name="dynamicCenter">dynamic sphere center</param>
    /// <param name="dynamicRadius">dynamic sphere radius</param>
    /// <param name="moveDirection">move direction</param>
    /// <param name="moveDistance">move distance</param>
    /// <param name="staticCenter">static sphere center</param>
    /// <param name="staticRadius">static sphere radius</param>
    /// <returns></returns>
    public static Vector3 GetDynamicSphereIntersect(Vector3 dynamicCenter, float dynamicRadius, Vector3 moveDirection, float moveDistance, Vector3 staticCenter, float staticRadius)
    {
        Vector3 e = staticCenter - dynamicCenter;
        float r = dynamicRadius + staticRadius;
        Vector3 d = moveDirection;
        float radical = Mathf.Pow(Vector3.Dot(e, d), 2) - Vector3.Dot(e, e) + r * r;
        if (radical < 0)
            return Vector3.zero;

        float t = Vector3.Dot(e, d) - Mathf.Sqrt(radical);
        Vector3 point = dynamicCenter + t * moveDirection;
        return point;
    }

    public static bool GetSphereToAABBIntersect(Vector3 center, float radius, AABB3 box)
    {
        Vector3 boxCenter = (box.min + box.max) / 2;
        Vector3 boxSize = new Vector3(box.max.x - box.min.x, box.max.y - box.min.y, box.max.z - box.min.z);
        Vector3[] points = GizmosExtension.GetCubePoints(boxCenter, boxSize);

        bool xcheck = center.x > (box.min.x - radius) && center.x < (box.max.x + radius);
        bool ycheck = center.y > (box.min.y - radius) && center.y < (box.max.y + radius);
        bool zcheck = center.z > (box.min.z - radius) && center.z < (box.max.z + radius);
        if (xcheck && ycheck && zcheck)
            return true;

        //for (int i = 0; i < points.Length; i++)
        //{
        //    if (Mathf.Pow((points[i] - center).magnitude, 2) <= radius * radius)
        //        return true;
        //}

        return false;
    }
}
