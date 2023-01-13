using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorProjection : MonoBehaviour
{
    public Vector3 V;

    //assumption n is 1,0,0
    public Vector3 N = new Vector3(1,0,0);

    public Vector3 VParallel;

    public Vector3 VVertical;
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
        Vector3 normalN = N.normalized;
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(V, 0.1f);

        //formula (2.2.6)
        VParallel = normalN * (Vector3.Dot(V, normalN));
        Gizmos.DrawLine(Vector3.zero, VParallel);

        //formula (2.2.7)
        VVertical = V - VParallel;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(VParallel, VParallel +VVertical);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, VParallel + VVertical);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(Vector3.zero, normalN);

    }
}
