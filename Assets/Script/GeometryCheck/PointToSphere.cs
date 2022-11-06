using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToSphere : MonoBehaviour
{
    public Vector3 Center;

    public float R;

    public GameObject Obj;
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
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(Center,R);

        Vector3 point= MathUtil.GetNearstPointToSphere(Center, Obj.transform.position, R);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point, 0.1f);
        Gizmos.DrawLine(Obj.transform.position, point);
    }
}
