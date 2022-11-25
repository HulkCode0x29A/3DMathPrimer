using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = Finch.Quaternion;

public enum QuaternionTestEnum
{
    QuaternionMultiplication
}
public class QuaternionTest : MonoBehaviour
{
    public QuaternionTestEnum Test = QuaternionTestEnum.QuaternionMultiplication;

    public Vector4 Quaternion1;

    public Vector4 Quaternion2;

    // Start is called before the first frame update
    void Start()
    {
        switch (Test)
        {
            case QuaternionTestEnum.QuaternionMultiplication:
                Quaternion result = new Quaternion(Quaternion1) * new Quaternion(Quaternion2);
                Debug.Log(result);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
