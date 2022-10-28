using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGramSchmidt : MonoBehaviour
{
    public Vector3 R1;

    public Vector3 R2;

    public Vector3 R3;
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

        Gizmos.color = Color.white;
        Gizmos.DrawLine(Vector3.zero, R1);
        Gizmos.color = Color.black;
        Gizmos.DrawLine(Vector3.zero, R2);
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, R3);

        Vector3 newR2 = R2 - (Vector3.Dot(R2, R1) / Vector3.Dot(R1, R1)) * R1;
        Vector3 newR3 = R3 - (Vector3.Dot(R3, R1) / Vector3.Dot(R1, R1)) * R1 - (Vector3.Dot(R3, newR2) / Vector3.Dot(newR2, newR2)) * newR2;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero,R1.normalized);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero,newR2.normalized);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector3.zero, newR3.normalized);
    }


}
