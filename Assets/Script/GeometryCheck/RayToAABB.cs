using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayToAABB : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    private AABB3 box = new AABB3();

    public Vector3 RayStart;

    public Vector3 Direction;

    public float T;

    public Vector3 Debug;

    private IntersectInfo info = new IntersectInfo();

    public bool drawTriangle;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDrawGizmos()
    {
        GizmosExtension.DrawLHCoordinate(Vector3.zero);

        if (drawTriangle)
            GizmosExtension.DrawWireTriangle(P1, P2, P3);

        box.SetToEmpety();
        box.Add(P1);
        box.Add(P2);
        box.Add(P3);
        Gizmos.color = Color.cyan;
        GizmosExtension.DrawBoundingBox(box.min, box.max);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(RayStart, 0.1f);
        Vector3 rayEnd = RayStart + T * Direction.normalized;
        Vector3 rayDelta = rayEnd - RayStart;
        Gizmos.DrawLine(RayStart, rayEnd);

        Debug = rayDelta;

        MathUtil.GetRayToAABBIntersection(RayStart, rayDelta, box, info);
        if (info.Intersect)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(info.Vector1, 0.1f);
        }
    }
}
