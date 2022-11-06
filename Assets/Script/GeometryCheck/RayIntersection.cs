using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayIntersection : MonoBehaviour
{
    public Vector3 Start1;

    public Vector3 Direction1;

    public float T1;

    public Vector3 Start2;

    public Vector3 Direction2;

    public float T2;

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

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Start1, Start1+ T1 * Direction1.normalized);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Start2,Start2 + T2 * Direction2.normalized);

        Vector3[] points =  MathUtil.GetRayIntersection(Start1, Direction1, Start2, Direction2);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(points[0],0.1f);
        Gizmos.DrawSphere(points[1], 0.1f);
        Gizmos.DrawLine(points[0],points[1]);
    }
}
