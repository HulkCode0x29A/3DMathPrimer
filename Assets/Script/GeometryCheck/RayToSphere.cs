using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayToSphere : MonoBehaviour
{
    public Vector3 Origin;

    public Vector3 Direction;

    public float T;

    public Vector3 Center;

    public float R;
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
        Gizmos.DrawLine(Origin, Origin + T * Direction);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(Center, R);

        Vector3 point = MathUtil.GetRayToSphereIntersection(Origin, Direction.normalized, Center, R);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point,0.1f);
    }
}
