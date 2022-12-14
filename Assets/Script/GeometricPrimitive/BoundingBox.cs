using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
