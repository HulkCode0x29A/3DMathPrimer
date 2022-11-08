using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayToTriangle : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

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
        GizmosExtension.DrawLHCoordinate(Vector3.zero);

        GizmosExtension.DrawWireTriangle(P1, P2, P3);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Origin, 0.1f);
        Gizmos.DrawLine(Origin, Origin + T * Direction.normalized);

        MathUtil.GetRayToTriangleIntersection(Origin, Direction.normalized, P1, P2, P3, info);
        if(info.Intersect && info.Float1 <= T)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(info.Vector1, 0.1f);
        }
        


    }
}
