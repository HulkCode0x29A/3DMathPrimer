using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Vector3 P1;

    public Vector3 P2;

    public Vector3 Axis;

    public float Angle;

    // Start is called before the first frame update
    void Start()
    {
        Matrix4x4 matrix = Matrix4x4.identity;
        Quaternion q = Quaternion.identity;
        //matrix.inverse
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
      
    }

}
