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

    private IntersectInfo info = new IntersectInfo();

    public bool Strict;

    public float Error;
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
        Gizmos.DrawLine(Start1, Start1 + T1 * Direction1.normalized);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Start2, Start2 + T2 * Direction2.normalized);

        MathUtil.GetRayIntersection(Start1, Direction1.normalized, Start2, Direction2.normalized, info);

        if (info.Intersect)
        {
            Gizmos.color = Color.green;
            if (Strict)
            {
                bool float1Valid = info.Float1 >= 0 && info.Float1 <= T1;
                bool float2Valid = info.Float2 >= 0 && info.Float2 <= T2;
                bool errorValid = (info.Vector1 - info.Vector2).magnitude < Error;
                if (float1Valid && float2Valid && errorValid)
                {
                    Gizmos.DrawSphere(info.Vector1, 0.1f);
                    Gizmos.DrawSphere(info.Vector2, 0.1f);
                    Gizmos.color = Color.white;
                    Gizmos.DrawLine(info.Vector1, info.Vector2);
                }
                    
            }
            else
            {

                Gizmos.DrawSphere(info.Vector1, 0.1f);
                Gizmos.DrawSphere(info.Vector2, 0.1f);
                Gizmos.DrawLine(info.Vector1, info.Vector2);
            }
        }

    }
}
