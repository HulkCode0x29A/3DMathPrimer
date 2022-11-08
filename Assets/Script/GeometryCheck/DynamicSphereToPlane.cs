using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSphereToPlane : MonoBehaviour
{
    public Vector3 P;

    public Vector3 N;

    public Vector3 Center;

    public float R;

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

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Center, R);
        Gizmos.DrawLine(Center, Center + T * Direction.normalized);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(Center + T * Direction.normalized, R);

        MathUtil.GetDynamicSphereToPlane(Center, R, Direction.normalized, P, N.normalized, info);
        if (info.Intersect && info.Float1 <= T)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(info.Vector1, R);
        }

    }
}
