using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleOfParallelogram : MonoBehaviour
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
        P3 = P1 + P2;

        GizmosExtension.DrawLHCoordinate(Vector3.zero);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, P1);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, P2);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(P1, P3);
        Gizmos.DrawLine(P2, P3);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(Vector3.zero, P3);
    }
}
