using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = Finch.Quaternion;

public enum QuaternionTestEnum
{
    Multiplication,
    Adding,
    Subtracting,
    ScalarMultiply,
    Conjugate,
    Magnitude,
    Normalize,
    Inverse,
    Division,
    Rotation,
    MultipleRotations,
    Angle,
    Slerp,
    MatrixToQuaternion,
}
public class QuaternionTest : MonoBehaviour
{
    public QuaternionTestEnum Test = QuaternionTestEnum.Multiplication;

    public Vector4 Quaternion1;

    public Vector4 Quaternion2;

    public Vector3 P1;

    public Vector3 P2;

    public Vector3 P3;

    public Vector3 P4;

    public Vector3 InputAxis1;

    public Vector3 InputAxis2;

    public float InputFloat1;

    public float InputFloat2;

    public float OutFloat1;

    [Range(0, 1)]
    public float T1;


    // Start is called before the first frame update
    void Start()
    {


        Quaternion result;
        Quaternion q1;
        Quaternion q2;
        switch (Test)
        {
            case QuaternionTestEnum.Multiplication:
                result = new Quaternion(Quaternion1) * new Quaternion(Quaternion2);
                Debug.Log(result);
                break;
            case QuaternionTestEnum.Adding:
                result = new Quaternion(Quaternion1) + new Quaternion(Quaternion2);
                Debug.Log(result);
                break;
            case QuaternionTestEnum.Subtracting:
                result = new Quaternion(Quaternion1) - new Quaternion(Quaternion2);
                Debug.Log(result);
                break;
            case QuaternionTestEnum.ScalarMultiply:
                result = new Quaternion(Quaternion1) * InputFloat1;
                Debug.Log(result);
                break;
            case QuaternionTestEnum.Conjugate:
                QuaternionConjugate();
                break;
            case QuaternionTestEnum.Magnitude:
                result = new Quaternion(Quaternion1);
                Debug.Log("magnitude:" + result.magnitude);
                break;
            case QuaternionTestEnum.Normalize:
                result = new Quaternion(Quaternion1);
                Debug.Log("normalize:" + result.normalized);
                result.Normalize();
                Debug.Log("magnitude:" + result.magnitude);
                break;
            case QuaternionTestEnum.Inverse:
                q1 = new Quaternion(Quaternion1);
                q2 = q1.inverse;
                Debug.Log("inverse:" + q2);
                Debug.Log("inverse product:" + q1 * q2);
                break;
            case QuaternionTestEnum.Division:
                q1 = new Quaternion(Quaternion1);
                Debug.Log("division:" + q1 / q1);
                break;
            case QuaternionTestEnum.MatrixToQuaternion:
                q1 = new Quaternion(Quaternion1);
                Matrix4x4 matrix = Quaternion.GetRotationMatrix(q1);
                result = Quaternion.GetQuaternion(matrix);
                Debug.Log("MatrixToQuaternion:" + result);
                break;


        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void QuaternionConjugate()
    {
        Debug.Log("------------------using quaternion1----------------");
        Quaternion q1 = new Quaternion(Quaternion1);
        Quaternion q2 = new Quaternion(Quaternion1);
        Debug.Log(Quaternion.Conjugate(q2));
        Debug.Log(q2.conjugated);
        q2.Conjugate();
        Debug.Log(q2);

        Debug.Log("qq*:" + q1 * q2);
        Debug.Log("q*q:" + q2 * q1);

        Debug.Log("----------using quaternion1 and quaternion2--------");
        q1 = new Quaternion(Quaternion1);
        q2 = new Quaternion(Quaternion2);
        Debug.Log("(q_a q_b)*:" + (q1 * q2).conjugated);
        Debug.Log("q_b* q_a*:" + q2.conjugated * q1.conjugated);
    }

    private void OnDrawGizmos()
    {
        switch (Test)
        {
            case QuaternionTestEnum.Rotation:
                QuaternionRotation();
                break;
            case QuaternionTestEnum.MultipleRotations:
                QuaternionMultipleRotation();
                break;
            case QuaternionTestEnum.Angle:
                QuaternionAngle();
                break;
            case QuaternionTestEnum.Slerp:
                QuaternionSlerp();
                break;
            default:
                break;
        }
    }

    private void QuaternionRotation()
    {
        GizmosExtension.DrawLHCoordinate(Vector3.zero);
        Quaternion quaternion = new Quaternion(InputFloat1, InputAxis1.normalized);
        P2 = quaternion * P1;

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, P2);
        Gizmos.DrawSphere(P2, 0.1f);
    }

    private void QuaternionMultipleRotation()
    {
        GizmosExtension.DrawLHCoordinate(Vector3.zero);
        Quaternion q1 = new Quaternion(InputFloat1, InputAxis1.normalized);
        Quaternion q2 = new Quaternion(InputFloat2, InputAxis2.normalized);
        P2 = (q1 * q2) * P1;

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, P2);
        Gizmos.DrawSphere(P2, 0.1f);
    }

    private void QuaternionAngle()
    {
        GizmosExtension.DrawLHCoordinate(Vector3.zero);
        Quaternion q1 = new Quaternion(InputFloat1, InputAxis1.normalized);
        Quaternion q2 = new Quaternion(InputFloat2, InputAxis2.normalized);

        P2 = q1 * P1;
        P3 = q2 * P1;

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, P1);
        Gizmos.DrawSphere(P1, 0.1f);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(Vector3.zero, P2);
        Gizmos.DrawSphere(P2, 0.1f);

        Gizmos.color = Color.red;
        Gizmos.DrawLine(Vector3.zero, P3);
        Gizmos.DrawSphere(P3, 0.1f);

        OutFloat1 = Quaternion.Angle(q1, q2) * Mathf.Rad2Deg;
    }

    private void QuaternionSlerp()
    {
        GizmosExtension.DrawLHCoordinate(Vector3.zero);
        Quaternion q1 = new Quaternion(InputFloat1, InputAxis1.normalized);
        Quaternion q2 = new Quaternion(InputFloat2, InputAxis2.normalized);
        Quaternion q = Quaternion.Slerp(q1, q2, T1);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Vector3.zero, P1);
        Gizmos.DrawSphere(P1, 0.1f);

        Gizmos.color = Color.blue;
        P2 = q1 * P1;
        Gizmos.DrawLine(Vector3.zero, P2);
        Gizmos.DrawSphere(P2, 0.1f);

        Gizmos.color = Color.red;
        P3 = q2 * P1;
        Gizmos.DrawLine(Vector3.zero, P3);
        Gizmos.DrawSphere(P3, 0.1f);

        P4 = q * P1;

        Gizmos.color = Color.green;
        Gizmos.DrawLine(Vector3.zero, P4);
        Gizmos.DrawSphere(P4, 0.1f);
    }
}
