using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSphereToPlane : MonoBehaviour
{
    public Vector3 P;

    public Vector3 N;

    public Vector3 Center;

    public float R;

    public int Side;

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

        float planeD = MathUtil.GetPlane(P, N.normalized);

        MathUtil.GetSphereToPlaneIntersect(N.normalized, planeD, Center, R, info);

        Gizmos.color = info.Intersect ? Color.green : Color.red;
        Gizmos.DrawSphere(Center, R);

        Side = MathUtil.GetSphereToPlaneSide(N.normalized, planeD, Center, R);

    }
}
