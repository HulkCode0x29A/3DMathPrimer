using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParameterEquation : MonoBehaviour
{
    [Range(0, 1)]
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

        //formula (5.0.2)
        float x = Mathf.Cos(Mathf.Deg2Rad * 360 * T);
        float y = Mathf.Sin(Mathf.Deg2Rad * 360 * T);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, new Vector3(x,y,0));
        Gizmos.DrawSphere(new Vector3(x, y, 0), 0.1f);
    }
}
