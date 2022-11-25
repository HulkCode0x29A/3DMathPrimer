using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixRotateXYZ : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 RotateVector;

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

        matrix = Matrix4x4.identity;
        matrix = MatrixUtil.GetRotateXYZMatrix(RotateVector.x, RotateVector.y, RotateVector.z);

        P2 = matrix.MultiplyPoint(P1);
        Gizmos.color = Color.cyan;
        GizmosExtension.DrawLineWithSphere(Vector3.zero,P2,0.1f);
    }

}
