using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDistance : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public float F;
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

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(P1, 0.1f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(P2, 0.1f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(P1,P2);

        Vector3 d = P2 - P1;
        F = Mathf.Sqrt(d.x * d.x + d.y * d.y + d.z * d.z);
    }
}
