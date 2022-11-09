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
        N = new Vector3(1, 0, 0);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(V, 0.1f);

        VParallel = N * (Vector3.Dot(V, N));
        Gizmos.DrawLine(Vector3.zero, VParallel);

        VVertical = V - VParallel;
        Gizmos.color = Color.red;
        Gizmos.DrawLine(VParallel, VParallel +VVertical);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector3.zero, VParallel + VVertical);

        Gizmos.color = Color.black;
        Gizmos.DrawLine(Vector3.zero, N);

    }
}
