using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarycentricCoordinates3D : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    public GameObject Obj;

    public Vector3 Barycentric;

    public bool DrawSphere;
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

        Gizmos.color = Color.cyan;
        GizmosExtension.DrawWireTriangle(P1,P2, P3);

        if(null != Obj)
        {
            Barycentric = MathUtil.GetBarycentric3D(P1, P2, P3, Obj.transform.position, true);
          
            if (DrawSphere)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(Barycentric.x * P1 + Barycentric.y * P2 + Barycentric.z * P3, 0.2f);
            }
                
        }
    }
}
