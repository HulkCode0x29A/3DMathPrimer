using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixRotateYXZ : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    public float Heading;

    public float Pitch;

    public float Bank;

    public float OutHeading;

    public float OutPitch;

    public float OutBank;

    public bool Reverse;

    Matrix4x4 matrix = Matrix4x4.identity;

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


        if (Reverse)
        {
            matrix = MatrixUtil.GetReverseRotateYXZMatrix(Heading, Pitch, Bank);
            //get eulerangle from matrix
            Vector3 angle = MatrixUtil.GetEulerAngleFromReverseRotateYXZ(matrix);
            OutHeading = angle.y;
            OutPitch = angle.x;
            OutBank = angle.z;
        }
        else
            matrix = MatrixUtil.GetRotateYXZMatrix(Heading, Pitch, Bank);
        Gizmos.color = Color.cyan;
        Vector3 t1 = matrix.MultiplyPoint(P1);
        Vector3 t2 = matrix.MultiplyPoint(P2);
        Vector3 t3 = matrix.MultiplyPoint(P3);
        GizmosExtension.DrawWireTriangle(t1,t2,t3);
        Gizmos.DrawSphere(t1,0.1f);
        Gizmos.DrawSphere(t2, 0.1f);
        Gizmos.DrawSphere(t3, 0.1f);
    }


}
