using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixProjectionByAxis : MonoBehaviour
{
    public Vector3 Center;

    public Vector3 Size;

    public Vector3 N;

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
        Vector3[] points = GizmosExtension.GetCubePoints(Center, Size);
        GizmosExtension.DrawWireCube(points);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(Vector3.zero, N.normalized);

        Matrix4x4 matrix = MatrixUtil.GetProjectionByAxisMatrix(N.normalized);
        Vector3[] transPoints = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            transPoints[i] = matrix.MultiplyPoint(points[i]);
        }

        Gizmos.color = Color.cyan;
        GizmosExtension.DrawWireCube(transPoints);
    }
}
