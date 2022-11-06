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
        Gizmos.DrawLine(Origin, Origin + T * Direction.normalized);

        Vector3 point= MathUtil.GetRayToPlaneIntersection(Origin, Direction, N, MathUtil.GetPlane(P,Direction.normalized));
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point, 0.1f);
        
    }
}
