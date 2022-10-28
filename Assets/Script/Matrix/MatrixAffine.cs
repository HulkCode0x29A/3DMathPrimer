using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixAffine : MonoBehaviour
{
    public Vector3 RoateAxisStart;

    public Vector3 RoateAxisEnd;

    public float Angle;

    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    public Vector3 P4;


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
        GizmosExtension.DrawQuad(P1,P2,P3,P4);

        Gizmos.color = Color.cyan;
        Vector3 n = (RoateAxisEnd - RoateAxisStart).normalized;
        Gizmos.DrawLine(RoateAxisStart,RoateAxisEnd);
        Matrix4x4 transOriginalMatrix = MatrixUtil.GetTranslationMatrix(-RoateAxisStart);
        Matrix4x4 transBackMatrix = MatrixUtil.GetTranslationMatrix(RoateAxisStart);
        Matrix4x4 rotateMatrix = MatrixUtil.GetRotateByAxisMatrix(n,Angle);

        Matrix4x4 composeMatrix = Matrix4x4.identity;
        composeMatrix = transBackMatrix* rotateMatrix * transOriginalMatrix;
        Vector3 t1 = composeMatrix.MultiplyPoint(P1);
        Vector3 t2 = composeMatrix.MultiplyPoint(P2);
        Vector3 t3 = composeMatrix.MultiplyPoint(P3);
        Vector3 t4 = composeMatrix.MultiplyPoint(P4);
        Gizmos.color = Color.blue;
        GizmosExtension.DrawQuad(t1, t2, t3, t4);

    }
}
