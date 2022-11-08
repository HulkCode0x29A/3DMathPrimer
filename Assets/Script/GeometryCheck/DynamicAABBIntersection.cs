using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicAABBIntersection : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    private AABB3 box1 = new AABB3();

    public Vector3 P4;

    public Vector3 P5;

    public Vector3 P6;

    public bool DrawTriangle;

    private AABB3 box2 = new AABB3();

    public Vector3 Direction;

    private IntersectInfo info = new IntersectInfo();

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

        Gizmos.color = Color.green;

        if (DrawTriangle)
            GizmosExtension.DrawWireTriangle(P1, P2, P3);

        box1.SetToEmpety();
        box1.Add(P1);
        box1.Add(P2);
        box1.Add(P3);
        GizmosExtension.DrawBoundingBox(box1.min, box1.max);

        Gizmos.color = Color.cyan;
        if (DrawTriangle)
            GizmosExtension.DrawWireTriangle(P4, P5, P6);

        box2.SetToEmpety();
        box2.Add(P4);
        box2.Add(P5);
        box2.Add(P6);
        GizmosExtension.DrawBoundingBox(box2.min, box2.max);

        Gizmos.color = Color.white;
        Gizmos.DrawLine((box2.min + box2.max)/2, (box2.min + box2.max) / 2 + Direction);

        Gizmos.color = Color.blue;
        GizmosExtension.DrawBoundingBox(box2.min + Direction, box2.max + Direction);

        MathUtil.GetDynamicAABBIntersection(box1,box2, Direction,info);
        if(info.Intersect)
        {
            Gizmos.color = Color.red;
            GizmosExtension.DrawBoundingBox(info.Vector1, info.Vector2);
        }
    }
}
