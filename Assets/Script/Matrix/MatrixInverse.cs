using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixInverse : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    public float Angle;

    public bool DrawResult;
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

        Gizmos.color = Color.white;
        GizmosExtension.DrawWireTriangle(P1, P2, P3);

        Matrix4x4 rotateMatrix = MatrixUtil.GetRotateYMatrix(Angle);

        Vector3 t1 = rotateMatrix * P1;
        Vector3 t2 = rotateMatrix * P2;
        Vector3 t3 = rotateMatrix * P3;

        Gizmos.color = Color.green;
        GizmosExtension.DrawWireTriangle(t1,t2,t3);

        Matrix4x4 inverseMatrix = rotateMatrix.inverse;
        Vector3 b1 = inverseMatrix * t1;
        Vector3 b2 = inverseMatrix * t2;
        Vector3 b3 = inverseMatrix * t3;
        Gizmos.color = Color.red;
        if (DrawResult)
            GizmosExtension.DrawWireTriangle(b1,b2,b3);
    }
}
