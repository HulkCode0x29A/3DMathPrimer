using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum VectorOperationEnum
{
    VectorInCircle,
    NegativeVector,
    LengthVector,
    ScalarVector,
    NormalizedVector,
    TwoPointsDistance,
}

public class VectorOperation : MonoBehaviour
{
    

    public VectorOperationEnum Operation = VectorOperationEnum.VectorInCircle;

    public Vector3 VectorValue1;

    public Vector3 VectorValue2;

    public float FloatValue1;
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
        switch (Operation)
        {
            case VectorOperationEnum.VectorInCircle:
                VectorInCircle();
                break;
            case VectorOperationEnum.NegativeVector:
                NegativeVector();
                break;
            case VectorOperationEnum.LengthVector:
                LengthVector();
                break;
            case VectorOperationEnum.ScalarVector:
                ScalarVector();
                break;
            case VectorOperationEnum.NormalizedVector:
                NormalizedVector();
                break;
            case VectorOperationEnum.TwoPointsDistance:
                TwoPointsDistance();
                break;
   
            default:
                break;
        }
    }

    private void VectorInCircle()
    {
        Vector3 vector = new Vector3(1,0,0);
        int step = 20;
        int oneStep =  360 / step;

        for (int i = 0; i < 20; i++)
        {
            Matrix4x4 matrix = Matrix4x4.Rotate(Quaternion.Euler(0,0,i * oneStep));
            Vector3 rotateV = matrix.MultiplyPoint(vector);
            Gizmos.DrawLine(Vector3.zero,rotateV);
        }
    }

    private void NegativeVector()
    {
        GizmosExtension.DrawLHCoordinate(Vector3.zero);

        //formula (2.1.1)
        VectorValue2 = -VectorValue1;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, VectorValue1);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, VectorValue2);
        
    }

    private void LengthVector()
    {
        GizmosExtension.DrawLHCoordinate(Vector3.zero);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, VectorValue1);

        //FloatValue1 = VectorValue1.magnitude;
        //formula (2.1.2)
        FloatValue1 = Mathf.Sqrt(VectorValue1.x * VectorValue1.x+VectorValue1.y * VectorValue1.y+ VectorValue1.z * VectorValue1.z);
    }

    private void ScalarVector()
    {
        GizmosExtension.DrawLHCoordinate(Vector3.zero);

        //formula (2.1.3)
        VectorValue2 = VectorValue1 * FloatValue1;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, VectorValue2);
    }

    private void NormalizedVector()
    {
        GizmosExtension.DrawLHCoordinate(Vector3.zero);

        //VectorValue2 = VectorValue1.normalized;

        //formula (2.1.4)
        VectorValue2 = VectorValue1 / VectorValue1.magnitude;

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, VectorValue1);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, VectorValue2);
    }

    private void TwoPointsDistance()
    {
        //p1-p2 or p2-p1 are same result for distance
        GizmosExtension.DrawLHCoordinate(Vector3.zero);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(VectorValue1, 0.1f);

        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(VectorValue2, 0.1f);

        Gizmos.color = Color.white;
        Gizmos.DrawLine(VectorValue1, VectorValue2);

        //Vector3 minusVector = VectorValue1 - VectorValue2;
        //FloatValue1 = minusVector.magnitude;

        //formula (2.1.6)
        Vector3 minusVector = new Vector3 (VectorValue1.x - VectorValue2.x, VectorValue1.y - VectorValue2.y, VectorValue1.z - VectorValue2.z);
        FloatValue1 = Mathf.Sqrt(minusVector.x * minusVector.x + minusVector.y * minusVector.y + minusVector.z + minusVector.z);
    }

  
}
