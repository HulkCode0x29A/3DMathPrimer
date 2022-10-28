using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixScaleByAxis : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    public Vector3 P4;

    public Vector3 N;

    public float K;

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
        GizmosExtension.DrawQuad(P1, P2, P3, P4);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, N.normalized);

        Matrix4x4 matrix = MatrixUtil.GetScaleByAxisMatrix(N.normalized,K);
        Vector3 t1 = matrix.MultiplyPoint(P1);
        Vector3 t2 = matrix.MultiplyPoint(P2);
        Vector3 t3 = matrix.MultiplyPoint(P3);
        Vector3 t4 = matrix.MultiplyPoint(P4);
        Gizmos.color = Color.blue;
        GizmosExtension.DrawQuad(t1,t2,t3,t4);

    }
}
