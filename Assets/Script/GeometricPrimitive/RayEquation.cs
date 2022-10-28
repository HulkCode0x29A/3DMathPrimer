using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayEquation : MonoBehaviour
{
    public Vector3 P0;

    public Vector3 PD;

    [Range(0,1)]
    public float T;


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

        Vector3 target = P0 + T * PD;
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(P0, target);
    }
}
