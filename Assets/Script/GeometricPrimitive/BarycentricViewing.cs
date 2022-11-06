using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarycentricViewing : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    [Range(0, 1)]
    public float Alpha;

    [Range(0, 1)]
    public float Beta;

    [Range(0, 1)]
    public float Gamma;
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
        GizmosExtension.DrawWireTriangle(P1, P2, P3);

        Vector3 pos = Alpha * P1 + Beta * P2 + Gamma * P3;
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(pos, 0.1f);
    }
}
