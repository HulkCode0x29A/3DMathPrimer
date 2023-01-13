using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MatrixOperationEnum
{
    IdentityMatrix,
    TransposeMatrix,
    MultiplicationMatrix,
    InverseMatrix
}
public class MatrixOperation : MonoBehaviour
{
    public MatrixOperationEnum Operation;

    //m00 m01 m02 m03
    //m10 m11 m12 m13
    //m20 m21 m22 m23
    //m30 m31 m32 m33
    private Matrix4x4 matrix;
   
    private void OnEnable()
    {
        matrix = Matrix4x4.identity;
        int i = 0;
        for (int row = 0; row < 4; row++)
        {
            for (int column = 0; column < 4; column++)
            {
                matrix[row, column] = ++i;
            }
        }

        switch (Operation)
        {
            case MatrixOperationEnum.IdentityMatrix:
                DebugMatrix("Origianl", matrix);
                DebugMatrix("Identity", Matrix4x4.identity);
                break;
            case MatrixOperationEnum.TransposeMatrix:
                DebugMatrix("Origianl", matrix);
                DebugMatrix("Transpose", matrix.transpose);
                break;
            case MatrixOperationEnum.MultiplicationMatrix:
                DebugMatrix("Origianl", matrix);
                DebugMatrix("Multiplication", matrix * matrix);
                break;
            case MatrixOperationEnum.InverseMatrix:
                Matrix4x4 scaleMatrix = Matrix4x4.Scale(new Vector3(3, 3, 3));
                DebugMatrix("ScaleMatrix", scaleMatrix);
                DebugMatrix("InverseMatrix", scaleMatrix.inverse);
                break;
            default:
                break;
        }
    }

    private void DebugMatrix(string text,Matrix4x4 matrix)
    {
        Debug.Log($"-----------------------{text}----------------------------");
        Debug.Log(matrix);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
