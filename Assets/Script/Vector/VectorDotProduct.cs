using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDotProduct : MonoBehaviour
{
    public Vector3 VectorValue1;

    public Vector3 VectorValue2;

    public string StringValue1;

    [Range(0, 360)]
    public float SliderValueCircle;

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
        DotVector();
    }
    private void DotVector()
    {
        VectorValue1 = new Vector3(1, 0, 0);
        VectorValue2 = new Vector3(1, 0, 0);
        Matrix4x4 matrix = Matrix4x4.Rotate(Quaternion.Euler(0, 0, SliderValueCircle));
        VectorValue2 = matrix.MultiplyPoint(VectorValue2);

        //GizmosExtension.DrawLHCoordinate(Vector3.zero);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, VectorValue1);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, VectorValue2);

        //float value = Vector3.Dot(VectorValue1, VectorValue2);

        //formula (2.2.2)
        float value = VectorValue1.x * VectorValue2.x + VectorValue1.y * VectorValue2.y + VectorValue1.z * VectorValue2.z;
        StringValue1 = value.ToString("0.000");
    }
}
