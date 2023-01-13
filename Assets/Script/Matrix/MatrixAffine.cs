using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixAffine : MonoBehaviour
{
    public Vector3 Center;

    public Vector3 Size;

    public Vector3 RoateAxisStart;

    public Vector3 RoateAxisEnd;

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
        Vector3[] cubePoints = GizmosExtension.GetCubePoints(Center,Size);
        GizmosExtension.DrawWireCube(cubePoints);

        Gizmos.color = Color.cyan;
        Vector3 n = (RoateAxisEnd - RoateAxisStart).normalized;
        Gizmos.DrawLine(RoateAxisStart,RoateAxisEnd);
        Matrix4x4 transOriginalMatrix = MatrixUtil.GetTranslationMatrix(-RoateAxisStart);
        Matrix4x4 transBackMatrix = MatrixUtil.GetTranslationMatrix(RoateAxisStart);
        Matrix4x4 rotateMatrix = MatrixUtil.GetRotateByAxisMatrix(n,Angle);

        Matrix4x4 composeMatrix = Matrix4x4.identity;
        composeMatrix = transBackMatrix* rotateMatrix * transOriginalMatrix;

        Vector3[] newPoints = new Vector3[cubePoints.Length];
        for (int i = 0; i < cubePoints.Length; i++)
        {
            newPoints[i] = composeMatrix.MultiplyPoint(cubePoints[i]);
        }
        
        Gizmos.color = Color.green;
        GizmosExtension.DrawWireCube(newPoints);

    }
}
