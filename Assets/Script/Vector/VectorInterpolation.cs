using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorInterpolation : MonoBehaviour
{
    public Vector3 P1;

    
    public Vector3 P2;

    [Range(0,1)]
    public float U;
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
        Gizmos.DrawSphere(P1, 0.1f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(P2, 0.1f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(P1,P2);

        Vector3 value = Interpolation(P1, P2, U);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(value,0.1f);
             
    }

    public Vector3 Interpolation(Vector3 start, Vector3 end, float value)
    {
        Vector3 returnValue = start + value*(end - start);
        return returnValue;
    }
}
