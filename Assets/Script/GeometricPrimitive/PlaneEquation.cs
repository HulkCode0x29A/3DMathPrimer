using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneEquation : MonoBehaviour
{
    
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    public Vector3 N;

    public float D;

    public GameObject Obj;

    public bool OnPlane;
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
        Gizmos.DrawSphere(P1, 0.1f);
        Gizmos.DrawSphere(P2, 0.1f);
        Gizmos.DrawSphere(P3, 0.1f);
        GizmosExtension.DrawWireTriangle(P1, P2, P3);

        N = Vector3.Cross(P1, P2).normalized;
        Gizmos.color = Color.yellow;
        Vector3 center = (P1 + P2 + P3) / 3;
        Gizmos.DrawLine(center, center + N);
        D = MathUtil.GetPlane(P1, N);

        if (null != Obj)
        {
            OnPlane = MathUtil.OnPlane(Obj.transform.position, N, D,0.001f);
            if (OnPlane)
                Obj.GetComponent<MeshRenderer>().sharedMaterial.color = Color.green;
            else
                Obj.GetComponent<MeshRenderer>().sharedMaterial.color = Color.red;
        }

        
    }

    
}
