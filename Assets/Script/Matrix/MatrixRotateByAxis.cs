using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixRotateByAxis : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

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

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, Axis.normalized);

        Gizmos.color = Color.black;
        Gizmos.DrawLine(Vector3.zero, P1);

        Gizmos.color = Color.white;
        Matrix4x4 matrix = MatrixUtil.GetRotateByAxisMatrix(Axis.normalized, Angle);
        P2 = matrix.MultiplyPoint(P1);
        Gizmos.DrawLine(Vector3.zero, P2);

    }
}
