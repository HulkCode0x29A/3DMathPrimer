using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplicitLineIntersection : MonoBehaviour
{
    public Vector2 Start1;

    public Vector2 End1;

    public Vector2 Start2;

    public Vector2 End2;

    public float D1;

    public float D2;
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

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Start1, End1);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(Start2, End2);

        Vector2 normal1 = MathUtil.GetVector2Normal((End1 - Start1));
        Vector2 normal2 = MathUtil.GetVector2Normal((End2 - Start2));

        D1 = MathUtil.GetLine(Start1, normal1.normalized);
        D2 = MathUtil.GetLine(Start2, normal2.normalized);

        Vector2 point = MathUtil.GetImplicitLineIntersection(normal1.normalized, D1, normal2.normalized, D2);
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(point, 0.1f);
    }
}
