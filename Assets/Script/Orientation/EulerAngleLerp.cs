using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AngleLerpEnum
{
    SingleLerp,
    WrapLerp,
    LerpAngle,
}


public class EulerAngleLerp : MonoBehaviour
{
    public AngleLerpEnum Lerp;

    public GameObject Model;

    public int StartAngle;

    public int EndAngle;

    [Range(0, 1)]
    public float T;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (null == Model)
            return;


        switch (Lerp)
        {
            case AngleLerpEnum.SingleLerp:
                SingleLerp();
                break;
            case AngleLerpEnum.WrapLerp:
                //Just a demonstration Interpolation is still going to call Mathf.LerpAngle
                float theta = EndAngle - StartAngle;
                float delta = (theta - 360) * ((theta + 180) / 360);
                float angle = StartAngle + T * delta;
                Model.transform.localEulerAngles = new Vector3(0, angle, 0);
                break;
            case AngleLerpEnum.LerpAngle:
                //float lerpAngle = Mathf.LerpAngle(StartAngle, EndAngle,T);
                float lerpAngle = LerpAngle(StartAngle, EndAngle, T);
                Model.transform.localEulerAngles = new Vector3(0, lerpAngle, 0);
                break;
            default:
                break;
        }


    }

    public float LerpAngle(float a, float b, float t)
    {
        float delta = Repeat((b - a), 360);
        if (delta > 180)
            delta -= 360;

        return a + delta * Mathf.Clamp01(t);
    }

    public float Repeat(float t, float length)
    {
        return Mathf.Clamp(t - Mathf.Floor(t / length) * length, 0.0f, length);
    }

    private void SingleLerp()
    {
        //formula (4.0.2)
        float theta = EndAngle - StartAngle;
        float angle = StartAngle + T * theta;
        Model.transform.localEulerAngles = new Vector3(0, angle, 0);
    }
}
