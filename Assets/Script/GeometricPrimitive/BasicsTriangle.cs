using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicsTriangle : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    public float Perimeter;

    public float Area;
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
        GizmosExtension.DrawWireTriangle(P1,P2,P3);

        Vector3 e1 = P3 - P2;
        Vector3 e2 = P1 - P3;
        Vector3 e3 = P2 - P1;
        Perimeter = MathUtil.GetTrianglePerimeter(e1, e2,e3);

        //Area = MathUtil.GetTriangleArea(e1,e2,e3);
        Area = MathUtil.GetTriangleArea(e1, e2);

    }
}
