using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixCompose : MonoBehaviour
{
    public Vector3 Center;

    public Vector3 Size;

    public Vector3 Translation;

    public float RotateX;
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

        Vector3[] points = GizmosExtension.GetCubePoints(Center, Size);
        Gizmos.color = Color.red;
        GizmosExtension.DrawWireCube(points);

        Matrix4x4 composeMatrix = Matrix4x4.identity;
        Matrix4x4 rotatexMatrix = MatrixUtil.GetRotateXMatrix(RotateX);
        Matrix4x4 transMatrix = MatrixUtil.GetTranslationMatrix(Translation);

        composeMatrix = transMatrix * rotatexMatrix;
        Vector3[] transPoints = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            transPoints[i] = composeMatrix.MultiplyPoint(points[i]);
        }

        Gizmos.color = Color.green;
        GizmosExtension.DrawWireCube(transPoints);
    }
}
