using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEquation : MonoBehaviour
{
    public Vector3 FixedPoint;
    
    public Vector3 P;

    public Vector3 N;

    public float PlaneD;

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
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(FixedPoint, 0.1f);

        GizmosExtension.DrawWirePlane(P,N,Color.yellow,Color.white,true);

        MathUtil.GetNearstPointToPlane(P,N.normalized, FixedPoint,info);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(info.Vector1, 0.1f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(FixedPoint,info.Vector1);

        PlaneD = MathUtil.GetPlane(P,N.normalized);
    }

    
}
