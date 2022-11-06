using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointToImplicitLine : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public float D;

    public GameObject Obj;

    public float Distance;

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
        Gizmos.DrawLine(P1, P2);

        Vector3 n = MathUtil.GetVector2Normal(P2 - P1).normalized;
        Gizmos.color = Color.yellow;
        Vector3 middle = (P2 - P1) * 0.5f;
        Gizmos.DrawLine(P1+middle, P1+middle + n);

        D = MathUtil.GetLine(P1,n);

        Distance = MathUtil.GetNearestDistanceToImplicitLine(Obj.transform.position, D, n);

        Vector3 point = MathUtil.GetNearestPointToImplicitLine(Obj.transform.position,D,n);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point, 0.1f);

        Gizmos.DrawLine(Obj.transform.position, point);
    }
}
