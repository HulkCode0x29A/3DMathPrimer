using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicSphereIntersection : MonoBehaviour
{
    public Vector3 Center1;

    public float R1;

    public Vector3 Direction;

    public float T;

    public Vector3 Center2;

    public float R2;
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

        Gizmos.color =  Color.red;

        Gizmos.DrawSphere(Center1, R1);
        Gizmos.DrawSphere(Center2, R2);

        Gizmos.DrawLine(Center1, Center1 + T * Direction.normalized);

        Vector3 point = MathUtil.GetDynamicSphereIntersect(Center1,R1,Direction.normalized,T,Center2,R2);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(point, R1);
    }
}
