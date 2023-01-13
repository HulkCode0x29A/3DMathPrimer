using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorCrossProduct : MonoBehaviour
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
        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, P1);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, P2);

        Gizmos.color = Color.blue;
        //P3 = Vector3.Cross(P1, P2);

        //formula (2.3.1)
        P3 = new Vector3(P1.y * P2.z - P1.z * P2.y, P1.z * P2.x - P1.x * P2.z, P1.x * P2.y - P1.y * P2.x);
        Gizmos.DrawLine(Vector3.zero, P3);
    }
}
