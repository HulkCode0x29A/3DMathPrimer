using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToPlane : MonoBehaviour
{
    public Vector3 P;

    public Vector3 N;

    public GameObject Obj;

    private IntersectInfo info = new IntersectInfo();

    public float Debug;
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
        GizmosExtension.DrawWirePlane(P,N, Color.yellow, Color.white, true);

        MathUtil.GetNearstPointToPlane(P,N.normalized,Obj.transform.position, info);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(info.Vector1,0.1f);
        Gizmos.DrawLine(Obj.transform.position, info.Vector1);

        Debug = info.Float1;
    }
}
