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

    private Matrix4x4 matrix;
    // Start is called before the first frame update
    void Start()
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
        
      

    }

    private void OnEnable()
    {
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
