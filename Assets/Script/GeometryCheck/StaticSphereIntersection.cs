using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticSphereIntersection : MonoBehaviour
{

    public Vector3 Center1;

    public float R1;

    public Vector3 Center2;

    public float R2;

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

        MathUtil.GetStaticSphereIntersect(Center1, R1, Center2, R2, info);
        Gizmos.color = info.Intersect ? Color.green : Color.red;

        Gizmos.DrawSphere(Center1, R1);
        Gizmos.DrawSphere(Center2, R2);

    }
}
