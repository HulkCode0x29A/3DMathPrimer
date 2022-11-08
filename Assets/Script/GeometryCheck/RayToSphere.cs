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

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(Origin ,0.1f);
        Gizmos.DrawLine(Origin, Origin + T * Direction.normalized);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(Center, R);

        MathUtil.GetRayToSphereIntersection(Origin, Direction.normalized, Center, R, info);

        if(info.Intersect && info.Float1 <= T)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(info.Vector1, 0.1f);
        }
    }
}
