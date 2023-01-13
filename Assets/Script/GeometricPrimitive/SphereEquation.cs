using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereEquation : MonoBehaviour
{
    public Vector3 Center;

    public float Radius;

    public GameObject Obj;

    public bool Inside;

    public float CircleDiameter;

    public float CirclePerimeter;

    public float CircleArea;

    public float SphereArea;

    public float SphereVolume;
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

        if(null != Obj)
            Inside = MathUtil.InsideSphere(Obj.transform.position, Center, Radius);

        Gizmos.color = Inside ? Color.green: Color.red;
        Gizmos.DrawSphere(Center, Radius);

        //fromula (5.3.3)
        CircleDiameter = 2 * Radius;

        //fromula (5.3.4)
        CirclePerimeter = 2 * Mathf.PI * Radius;

        //fromula (5.3.5)
        CircleArea = Mathf.PI * Radius * Radius;

        //fromula (5.3.6)
        SphereArea = 4 * Mathf.PI * Radius * Radius;

        //fromula (5.3.7)
        SphereVolume = 4.0f / 3.0f * Mathf.PI * Mathf.Pow(Radius, 3);
    }

   
}
