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
            Inside = InsideSphere(Obj.transform.position, Center, Radius);

        Gizmos.color = Inside ? Color.green: Color.red;
        Gizmos.DrawSphere(Center, Radius);

        CircleDiameter = 2 * Radius;
        CirclePerimeter = 2 * Mathf.PI * Radius;
        CircleArea = Mathf.PI * Radius * Radius;

        SphereArea = 4 * Mathf.PI * Radius * Radius;
        SphereVolume = 4.0f / 3.0f * Mathf.PI * Mathf.Pow(Radius, 3);
    }

    public bool InsideSphere(Vector3 pos, Vector3 center,float r)
    {
        float r2 = r * r;

        float value = Mathf.Pow(pos.x - center.x, 2) + Mathf.Pow(pos.y - center.y,2) +Mathf.Pow(pos.z - center.z,2);
        return value <= r2;
    }
}
