using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixRotateByAxis : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    public Vector3 Axis;

    public float Angle;
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

        Gizmos.color = Color.red;
        GizmosExtension.DrawWireTriangle(P1, P2, P3);

        Gizmos.color = Color.white;
        Matrix4x4 matrix = MatrixUtil.GetRotateByAxisMatrix(Axis.normalized, Angle);

        Vector3 t1 = matrix.MultiplyPoint(P1);
        Vector3 t2 = matrix.MultiplyPoint(P2);
        Vector3 t3 = matrix.MultiplyPoint(P3);

        Gizmos.color = Color.green;
        GizmosExtension.DrawWireTriangle(t1, t2, t3);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, Axis);
    }
}
