using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MatrixShearEnum
{
    ShearXY,
    ShearXZ,
    ShearYZ,
}
public class MatrixShear : MonoBehaviour
{
    public Vector3 Center;

    public Vector3 Size;

    public MatrixShearEnum Shear;

    public float S;

    public float T;

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
        Vector3[] points = GizmosExtension.GetCubePoints(Center,Size);
        GizmosExtension.DrawWireCube(points);

        Matrix4x4 matrix = Matrix4x4.identity;
        switch (Shear)
        {
            case MatrixShearEnum.ShearXY:
                matrix = MatrixUtil.GetShearXYMatrix(S, T);
                break;
            case MatrixShearEnum.ShearXZ:
                matrix = MatrixUtil.GetShearXZMatrix(S,T);
                break;
            case MatrixShearEnum.ShearYZ:
                matrix = MatrixUtil.GetShearYZMatrix(S,T);
                break;
            default:
                break;
        }

        Vector3[] transPoints = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            transPoints[i] = matrix.MultiplyPoint(points[i]);
        }

        Gizmos.color = Color.blue;
        GizmosExtension.DrawWireCube(transPoints);
    }
}
