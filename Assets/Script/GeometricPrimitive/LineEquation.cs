using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEquation : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public float Slope;
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
        Slope = (P1.y - P2.y) / (P1.x - P2.x);

        GizmosExtension.DrawLHCoordinate(Vector3.zero);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(P1,P2);
    }
}
