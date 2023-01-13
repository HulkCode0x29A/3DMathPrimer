using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixTranslation : MonoBehaviour
{
    public Vector3 Center;

    public Vector3 Size;

    public Vector3 Translation;
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

        Matrix4x4 matrix = MatrixUtil.GetTranslationMatrix(Translation);
        Vector3[] transPoints = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            transPoints[i] = matrix.MultiplyPoint(points[i]);
        }

        Gizmos.color = Color.green;
        GizmosExtension.DrawWireCube(transPoints);

    }
}
