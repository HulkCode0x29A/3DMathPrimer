using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ProjectionFace
{
    ProjectionXY,
    ProjectionXZ,
    ProjectionYZ,
}
public class MatrixProjection : MonoBehaviour
{
    public ProjectionFace Face;

    public Vector3 Center;

    public Vector3 Size;

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
        Gizmos.color = Color.green;
        GizmosExtension.DrawWireCube(points);

        Matrix4x4 matrix = Matrix4x4.identity;
        switch (Face)
        {
            case ProjectionFace.ProjectionXY:
                matrix = MatrixUtil.GetProjectionXYMatrix();
                break;
            case ProjectionFace.ProjectionXZ:
                matrix = MatrixUtil.GetProjectionXZMatrix();
                break;
            case ProjectionFace.ProjectionYZ:
                matrix = MatrixUtil.GetProjectionYZMatrix();
                break;
            default:
                break;
        }
        Vector3[] transPoints = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            transPoints[i] = matrix * points[i];
        }

        Gizmos.color = Color.red;
        GizmosExtension.DrawWireCube(transPoints);
    }
}
