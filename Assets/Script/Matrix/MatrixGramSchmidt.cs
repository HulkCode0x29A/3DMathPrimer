using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixGramSchmidt : MonoBehaviour
{
    public Vector3 X1;

    public Vector3 X2;

    public Vector3 X3;
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
        Gizmos.DrawLine(Vector3.zero, X1);
        Gizmos.color = Color.black;
        Gizmos.DrawLine(Vector3.zero, X2);
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, X3);

        //formula (3.11.1)
        Vector3 v1 = X1;
        Vector3 v2 = X2 - (Vector3.Dot(X2, v1) / Vector3.Dot(v1, v1)) * v1;
        Vector3 v3 = X3 - (Vector3.Dot(X3, v1) / Vector3.Dot(v1, v1)) * v1 - (Vector3.Dot(X3, v2) / Vector3.Dot(v2, v2)) * v2;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero,X1.normalized);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero,v2.normalized);
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector3.zero, v3.normalized);
    }


}
