using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreePlanesIntersection : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 N1;

    public Vector3 P2;

    public Vector3 N2;

    public Vector3 P3;

    public Vector3 N3;

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

        GizmosExtension.DrawWirePlane(P1, N1,Color.red, Color.red);
        GizmosExtension.DrawWirePlane(P2, N2,Color.green, Color.green);
        GizmosExtension.DrawWirePlane(P3, N3,Color.blue, Color.blue);
        MathUtil.GetThreePlanesIntersection(P1,N1,P2,N2,P3,N3, info);

        if (info.Intersect)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(info.Vector1, 0.2f);
        }
        
    }
}
