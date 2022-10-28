using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorDotProduct : MonoBehaviour
{
    public Vector3 VectorValue1;

    public Vector3 VectorValue2;

    public float FloatValue1;

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

        GizmosExtension.DrawLHCoordinate(Vector3.zero);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, VectorValue1);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, VectorValue2);

        FloatValue1 = Vector3.Dot(VectorValue1, VectorValue2);
    }
}
