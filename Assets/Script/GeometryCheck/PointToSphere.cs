using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToSphere : MonoBehaviour
{
    public Vector3 Center;

    public float R;

    public GameObject Obj;

    private IntersectInfo info = new IntersectInfo();
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

        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(Center, R);

        MathUtil.GetNearstPointToSphere(Center, R, Obj.transform.position, info);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(info.Vector1, 0.1f);
        Gizmos.DrawLine(Obj.transform.position, info.Vector1);
    }
}
