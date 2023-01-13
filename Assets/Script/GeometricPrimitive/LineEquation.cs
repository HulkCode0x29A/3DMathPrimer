using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineEquation : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public float Slope;

    public float D;

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

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(P1,P2);

        Vector3 n = MathUtil.GetVector2Normal(P2-P1).normalized;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(P1 + (P2 - P1) * 0.5f, P1 + (P2 - P1) * 0.5f + n);

        D = MathUtil.GetLine(P1,n);
        if(null != Obj)
        {
            bool onLine = MathUtil.OnLine(Obj.transform.position, n,D,0.001f);
            if (onLine)
                Obj.GetComponent<MeshRenderer>().sharedMaterial.color = Color.green;
            else
                Obj.GetComponent<MeshRenderer>().sharedMaterial.color = Color.red;
        }
        
    }


}
