using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RayEquation : MonoBehaviour
{
    public RayDefine Define = RayDefine.DefineWithLength;

    public Vector3 P0;

    public Vector3 P1;

    public float Length;

    [Range(0, 1)]
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
        GizmosExtension.DrawLHCoordinate(Vector3.zero);

        Vector3 target;
        switch (Define)
        {
            case RayDefine.DefineWithLength:
                target = P0 + Length * P1.normalized;
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(P0, target);

                Gizmos.color = Color.blue;
                Gizmos.DrawLine(Vector3.zero, P1.normalized);
                break;
            case RayDefine.DefineWithT:
                target = P0 + (P1 - P0) * T;
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(P0, target);
                break;
        }
    }
}
