using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToAABB : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    private AABB3 box = new AABB3();

    public GameObject Obj;

    public bool DrawTriangle;

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

        if (DrawTriangle)
            GizmosExtension.DrawWireTriangle(P1, P2, P3);

        box.SetToEmpety();
        box.Add(P1);
        box.Add(P2);
        box.Add(P3);
        Gizmos.color = Color.cyan;
        GizmosExtension.DrawBoundingBox(box.min, box.max);

        MathUtil.GetNearstPointToAABB(box, Obj.transform.position, info);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(info.Vector1, 0.1f);
        Gizmos.DrawLine(Obj.transform.position, info.Vector1);
    }
}
