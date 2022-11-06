using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneToPoint : MonoBehaviour
{
    public Vector3 P;

    public Vector3 N;

    public Vector3 Point;

    public Vector3 PointOnPlane;

    public float Distance;
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
        Gizmos.DrawSphere(Point, 0.1f);

        GizmosExtension.DrawWirePlane(P,N, Color.yellow, Color.white,true);

        Distance = MathUtil.GetPlaneToPointDistance(P,N,Point);

        PointOnPlane = MathUtil.GetPlaneNearestPoint(P,N,Point);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(PointOnPlane, 0.1f);
        Gizmos.DrawLine(Point, PointOnPlane);

    }
}
