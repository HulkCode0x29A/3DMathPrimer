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

        Gizmos.color = Color.black;
        Gizmos.DrawLine(Vector3.zero, P1);
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
        
        P2 = rotateMatrix.MultiplyPoint(P1);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(Vector3.zero, P2);
    }
}
