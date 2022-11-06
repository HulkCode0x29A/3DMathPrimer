using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereToAABB : MonoBehaviour
{
    public Vector3 Center;

    public float R;

    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    private AABB3 box = new AABB3();
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

        Gizmos.color = Color.green;
        GizmosExtension.DrawWireTriangle(P1,P2,P3);

        Gizmos.color = Color.red;
        box.SetToEmpety();
        box.Add(P1);
        box.Add(P2);
        box.Add(P3);
        GizmosExtension.DrawBoundingBox(box.min,box.max);

        bool intersect = MathUtil.GetSphereToAABBIntersect(Center, R, box);
        Gizmos.color = intersect ? Color.green : Color.red;
        Gizmos.DrawSphere(Center,R);
    }
}
