using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 Axis;

    public float Angle;

    private Finch.Quaternion quaternion;
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
        quaternion = new Finch.Quaternion(Angle,Axis.normalized);
        P2 = quaternion * P1;

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, P2);
        Gizmos.DrawSphere(P2,0.1f);
    }

}
