using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleOfTriangles : MonoBehaviour
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
        GizmosExtension.DrawLineWithArrow(Vector3.zero, P1);

        Gizmos.color = Color.red;
        GizmosExtension.DrawLineWithArrow(P1, P3);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(Vector3.zero, P3);

   
    }
}
