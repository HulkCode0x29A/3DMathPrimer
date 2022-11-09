using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorSubtraction : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

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

        P3 = P1 - P2;

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(P1, 0.1f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(P2, 0.1f);

        GizmosExtension.DrawLineWithArrow(P2, P1);

        Gizmos.color = Color.red;
        GizmosExtension.DrawLineWithArrow(Vector3.zero, P3);
    }
}
