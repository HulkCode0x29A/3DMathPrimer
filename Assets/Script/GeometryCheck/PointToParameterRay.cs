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

    public Vector3 End;

    public Vector3 Direction;

    public float Length;

    [Range(0, 1)]
    public float T;

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



        switch (Define)
        {
            case RayDefine.DefineWithLength:
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(Origin, Origin + Length * Direction.normalized);

                MathUtil.GetNearstPointToLengthRay(Origin, Direction.normalized, Obj.transform.position, info);

                //Length must >= 0
                info.Float1 = Mathf.Clamp(info.Float1, 0, Length);
                Vector3 point1 = Origin + info.Float1 * Direction.normalized;
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(point1, 0.1f);
                Gizmos.DrawLine(Obj.transform.position, point1);

                Gizmos.color = Color.red;
                Gizmos.DrawSphere(info.Vector1, 0.1f);
                break;
            case RayDefine.DefineWithT:
                Gizmos.color = Color.cyan;
                Vector3 endToOrigin = End - Origin;
                Gizmos.DrawLine(Origin, Origin + endToOrigin * T);

                MathUtil.GetNearstPointToTRay(Origin, endToOrigin, Obj.transform.position, info);
                float t = Mathf.Clamp(info.Float1, 0, (endToOrigin * T).magnitude);
                Vector3 point2 = Origin + t * endToOrigin.normalized;

                Gizmos.color = Color.green;
                Gizmos.DrawSphere(point2, 0.1f);
                Gizmos.DrawLine(Obj.transform.position, point2);

                Gizmos.color = Color.red;
                Gizmos.DrawSphere(info.Vector1, 0.1f);
                break;

        }

    }
}
