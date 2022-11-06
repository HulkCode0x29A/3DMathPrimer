using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RayDefine
{
    DefineWithLength,
    DefineWithT,
}
public class PointToParameterRay : MonoBehaviour
{
    public RayDefine Define;

    public Vector3 Origin;

    public Vector3 Direction;

    public float Length;

    public Vector3 End;
    [Range(0, 1)]
    public float T;

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
        GizmosExtension.DrawLHCoordinate(Vector3.zero);



        switch (Define)
        {
            case RayDefine.DefineWithLength:
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(Origin, Origin + Length * Direction.normalized);

                Vector3 point1 = MathUtil.GetNearstPointToLengthRay(Origin, Direction.normalized, Obj.transform.position);
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(point1, 0.1f);
                Gizmos.DrawLine(Obj.transform.position, point1);
                break;
            case RayDefine.DefineWithT:
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(Origin, (End - Origin) * T);

                Vector3 point2 = MathUtil.GetNearstPointToTRay(Origin, Direction, Obj.transform.position);
                Gizmos.color = Color.red;
                Gizmos.DrawSphere(point2, 0.1f);
                Gizmos.DrawLine(Obj.transform.position, point2);
                break;

        }

    }
}
