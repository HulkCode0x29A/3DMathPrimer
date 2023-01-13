using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TriangleSpecialEnum
{
    Barycenter,
    Heart,
    Circumcenter
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
                Vector3 barycenter = MathUtil.GetTriangleBarycenter(P1,P2,P3); 
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(barycenter, 0.1f);
                break;
            case TriangleSpecialEnum.Heart:
                Vector3 heart = MathUtil.GetTriangleHeart(P1,P2,P3);
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(heart, 0.1f);

                if(DrawIncircle)
                {
                    float r = MathUtil.GetTriangleIncircleRadius(P1,P2,P3);
                    Gizmos.DrawWireSphere(heart,r);
                }
               
                break;
            case TriangleSpecialEnum.Circumcenter:
                Vector3 circumcenter = MathUtil.GetTriangleCircumcenter(P1,P2,P3);
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(circumcenter, 0.1f);

                if (DrawIncircle)
                {
                    float r = MathUtil.GetTriangleCrcumcircleRadius(P1, P2, P3);
                    Gizmos.DrawWireSphere(circumcenter, r);
                }
                break;
            default:
                break;
        }
    }
}
