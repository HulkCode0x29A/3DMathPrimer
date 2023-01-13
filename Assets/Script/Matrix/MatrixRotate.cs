using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MatrixRotateAxis
{
    RotateZ,
    RotateX,
    RotateY,
}
public class MatrixRotate : MonoBehaviour
{
    public MatrixRotateAxis Axis;

    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

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
        GizmosExtension.DrawWireTriangle(P1,P2,P3);

        Matrix4x4 rotateMatrix = Matrix4x4.identity;
        switch (Axis)
        {
            case MatrixRotateAxis.RotateZ:
                rotateMatrix = MatrixUtil.GetRotateZMatrix(Angle);
                break;
            case MatrixRotateAxis.RotateX:
                rotateMatrix = MatrixUtil.GetRotateXMatrix(Angle);
                break;
            case MatrixRotateAxis.RotateY:
                rotateMatrix = MatrixUtil.GetRotateYMatrix(Angle);
                break;
            default:
                break;
        }

        //Vector3 t1 = rotateMatrix * new Vector4(P1.x, P1.y, P1.z, 1);

        //MultiplyPoint (x,y,z,1)
        //MultiplyVector (x,y,z,0)

        Vector3 t1 = rotateMatrix.MultiplyPoint(P1);
        Vector3 t2 = rotateMatrix.MultiplyPoint(P2);
        Vector3 t3 = rotateMatrix.MultiplyPoint(P3);

        Gizmos.color = Color.green;
        GizmosExtension.DrawWireTriangle(t1,t2,t3);
        
    }
}
