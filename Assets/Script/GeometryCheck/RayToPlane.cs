using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayToPlane : MonoBehaviour
{
    public Vector3 P;

    public Vector3 N;

    public Vector3 Origin;

    public Vector3 Direction;

    public float T;

    private IntersectInfo info = new IntersectInfo();
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
        GizmosExtension.DrawWirePlane(P, N, Color.yellow, Color.white, true);

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(Origin, 0.1f);
        Gizmos.DrawLine(Origin, Origin + T * Direction.normalized);

        float planeD = MathUtil.GetPlane(P, Direction.normalized);
        MathUtil.GetRayToPlaneIntersection(Origin, Direction.normalized, N, planeD, info);
        if (info.Intersect && info.Float1 <= T)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(info.Vector1, 0.1f);
        }
    }
}
