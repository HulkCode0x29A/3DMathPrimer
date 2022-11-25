using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum QuaternionOperationEnum
{
    Identity,
    Angle,
    AngleAxis,
    Euler,
    FromToRotation,
    Inverse,
    Lerp,
    LookRotation,
    RotateTowards,
    SLerp,

}
public class QuaternionOperation : MonoBehaviour
{
    public QuaternionOperationEnum Operation = QuaternionOperationEnum.Angle;

    public Transform Cube;

    public Transform Point1;

    public Transform Point2;

    public Vector3 InputVector1;

    public float InputFloat1;

    [Range(0,1)]
    public float T;

    public float OutFloat1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (Operation)
        {
            case QuaternionOperationEnum.Identity:
                QuaternionIdentity();
                break;
            case QuaternionOperationEnum.Angle:
                QuaternionAngle();
                break;
            case QuaternionOperationEnum.AngleAxis:
                QuaternionAngleAxis();
                break;
            case QuaternionOperationEnum.Euler:
                QuaternionEuler();
                break;
            case QuaternionOperationEnum.FromToRotation:
                QuaternionFromToRotation();
                break;
            case QuaternionOperationEnum.Inverse:
                QuaternionInverse();
                break;
            case QuaternionOperationEnum.Lerp:
                QuaternionLerp();
                break;
            case QuaternionOperationEnum.LookRotation:
                QuaternionLookRotation();
                break;
            case QuaternionOperationEnum.RotateTowards:
                QuaternionRotateTowards();
                break;
            case QuaternionOperationEnum.SLerp:
                QuaternionSLerp();
                break;
        }

        
    }

    private void QuaternionIdentity()
    {
        Cube.transform.rotation = Quaternion.identity;
    }

    private void QuaternionAngle()
    {
        Debug.DrawLine(Cube.position,Point1.position);
        Debug.DrawLine(Cube.position, Point2.position);

        Quaternion rotationStart = Quaternion.LookRotation(Point1.position - Cube.position);
        Quaternion rotationEnd = Quaternion.LookRotation(Point2.position - Cube.position);
        OutFloat1 = Quaternion.Angle(rotationStart, rotationEnd);
    }

    private void QuaternionAngleAxis()
    {
     
        Cube.transform.rotation = Quaternion.AngleAxis(InputFloat1,InputVector1);
    }

    private void QuaternionEuler()
    {
        Cube.transform.rotation = Quaternion.Euler(InputVector1);
    }

    private void QuaternionFromToRotation()
    {
        Debug.DrawLine(Cube.transform.position, Point1.position);
        Vector3 direction = Point1.position - Cube.transform.position;
        Cube.transform.rotation = Quaternion.FromToRotation(Cube.transform.forward, direction) * Cube.transform.rotation;
    }

    private void QuaternionInverse()
    {
        Debug.DrawLine(Cube.transform.position, Point1.position);
     
        Cube.transform.rotation = Quaternion.Inverse( Point1.rotation);
    }

    private void QuaternionLerp()
    {
        Debug.DrawLine(Cube.position, Point1.position);
        Debug.DrawLine(Cube.position, Point2.position);

        Quaternion rotationStart = Quaternion.LookRotation(Point1.position - Cube.position);
        Quaternion rotationEnd = Quaternion.LookRotation(Point2.position - Cube.position);
        Cube.transform.rotation = Quaternion.Lerp(rotationStart, rotationEnd,T);
    }

    private void QuaternionLookRotation()
    {
        Debug.DrawLine(Cube.position, Point2.position);
        Vector3 direction = Point2.position - Cube.position;
        Cube.transform.rotation = Quaternion.LookRotation(direction);
    }

    private void QuaternionRotateTowards()
    {
        Debug.DrawLine(Cube.position, Point1.position);

        Quaternion rotationEnd = Quaternion.LookRotation(Point1.position - Cube.position);

        var step = InputFloat1 * Time.deltaTime;

        Cube.rotation = Quaternion.RotateTowards(Cube.rotation, rotationEnd, step);
    }

    private void QuaternionSLerp()
    {
        Debug.DrawLine(Cube.position, Point1.position);
        Debug.DrawLine(Cube.position, Point2.position);

        Quaternion rotationStart = Quaternion.LookRotation(Point1.position - Cube.position);
        Quaternion rotationEnd = Quaternion.LookRotation(Point2.position - Cube.position);

        Cube.rotation = Quaternion.Slerp(rotationStart, rotationEnd,T);
    }
}
