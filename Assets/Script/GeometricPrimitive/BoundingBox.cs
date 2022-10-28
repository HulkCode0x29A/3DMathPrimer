using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AABB3
{
    public Vector3 min;

    public Vector3 max;

    public void SetToEmpety()
    {
        min = new Vector3(float.MaxValue, float.MaxValue, float.MaxValue);
        max = new Vector3(float.MinValue,float.MinValue,float.MinValue);

    }

    public void Add(Vector3 p)
    {
        if (p.x < min.x)
            min.x = p.x;
        if (p.x > max.x)
            max.x = p.x;
        if (p.y < min.y)
            min.y = p.y;
        if (p.y > max.y)
            max.y = p.y;
        if (p.z < min.z)
            min.z = p.z;
        if (p.z > max.z)
            max.z = p.z;
    }
}
public class BoundingBox : MonoBehaviour
{
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
        GizmosExtension.DrawLHCoordinate(Vector3.zero);

        GizmosExtension.DrawWireTriangle(P1,P2,P3);

        box.SetToEmpety();
        box.Add(P1);
        box.Add(P2);
        box.Add(P3);
        Gizmos.color = Color.red;
        GizmosExtension.DrawBoundingBox(box.min,box.max);
    }
}
