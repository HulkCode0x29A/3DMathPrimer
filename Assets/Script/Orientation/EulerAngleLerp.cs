using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AngleLerpEnum
{
    SingleLerp,
    WrapLerp,
}


public class EulerAngleLerp : MonoBehaviour
{
    public AngleLerpEnum Lerp;

    public GameObject Model;

    public int StartAngle;

    public int EndAngle;

    [Range(0,1)]
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

        float theta;

        float angle;
        switch (Lerp)
        {
            case AngleLerpEnum.SingleLerp:
                theta = EndAngle - StartAngle;
                angle = StartAngle + T * theta;
                Model.transform.localEulerAngles = new Vector3(0, angle, 0);
                break;
            case AngleLerpEnum.WrapLerp:
                theta = EndAngle - StartAngle;
                float delta = (theta - 360) * ((theta + 180) / 360);
                angle = StartAngle + T * delta;
                Model.transform.localEulerAngles = new Vector3(0, angle, 0);
                break;
            default:
                break;
        }

        
    }
}
