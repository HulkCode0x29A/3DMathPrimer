using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TriangleSpecialEnum
{
    Barycenter,
    Heart,
}

public class TriangleSpecialPoint : MonoBehaviour
{
    public TriangleSpecialEnum Special;

    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    public bool DrawIncircle;

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

        switch (Special)
        {
            case TriangleSpecialEnum.Barycenter:
                Vector3 barycenter = (P1 + P2 + P3) / 3;
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(barycenter, 0.1f);
                break;
            case TriangleSpecialEnum.Heart:
                Vector3 e1 = P2 - P3;
                Vector3 e2 = P3 - P1;
                Vector3 e3 = P1 - P2;
                float p = MathUtil.GetTrianglePerimeter(e1,e2,e3);
                Vector3 numerator = e1.magnitude * P1 + e2.magnitude * P2 + e3.magnitude * P3;
                Vector3 heart = numerator / p ;
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(heart, 0.1f);

                if(DrawIncircle)
                {
                    float r = 2 * MathUtil.GetTriangleArea(e1, e2) / p;
                    Gizmos.DrawWireSphere(heart,r);
                }
                
                


                break;
            default:
                break;
        }
    }
}
