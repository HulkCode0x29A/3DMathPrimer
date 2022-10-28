using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PerspectiveEnum
{
    ZDPerspective,
    OneOverDPerspective,
}
public class MatrixPerspective : MonoBehaviour
{
    public PerspectiveEnum Perspective;
    public Vector4 P1;

    public Vector4 P2;

    public Vector4 P3;

    public float D;
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
        GizmosExtension.DrawWireTriangle(P1, P2, P3);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(new Vector3(0, -2, D), new Vector3(0, 2, D));

        Vector4[] points = new Vector4[] { P1, P2, P3 };
        Vector4[] transPoints = new Vector4[points.Length];
        switch (Perspective)
        {
            case PerspectiveEnum.ZDPerspective:
                for (int i = 0; i < points.Length; i++)
                {
                    Matrix4x4 matrix = MatrixUtil.GetPerspectiveZDMatrix(points[i], D);
                    transPoints[i] = matrix.MultiplyPoint(points[i]);
                }
                break;
            case PerspectiveEnum.OneOverDPerspective:
                for (int i = 0; i < points.Length; i++)
                {
                    Matrix4x4 matrix = MatrixUtil.GetPerspectiveDMatrix(D);
                    Vector4 temp = matrix * points[i];
                    transPoints[i] = new Vector3(temp.x / temp.w, temp.y / temp.w, temp.z / temp.w);
                }
                break;
        }


        Gizmos.color = Color.blue;
        GizmosExtension.DrawWireTriangle(transPoints[0], transPoints[1], transPoints[2]);
    }
}
