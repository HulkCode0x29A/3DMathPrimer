using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarycentricCoordinates : MonoBehaviour
{
    public PixelScreen Screen;

    public Vector2 P1;

    public Vector2 P2;

    public Vector2 P3;

    public Color Color1;

    public Color Color2;

    public Color Color3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Screen.Clear();

        Vector2[] points = new Vector2[] { P1, P2, P3 };
        Vector2 boxMin = new Vector2(float.MaxValue, float.MaxValue);
        Vector2 boxMax = new Vector2(-float.MaxValue, -float.MaxValue);
        Vector2 clamp = new Vector2(Screen.WidthCount - 1, Screen.HeightCount - 1);
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                //bottom-left
                boxMin[j] = Mathf.Max(0, Mathf.Min(boxMin[j], points[i][j]));
                //top-right
                boxMax[j] = Mathf.Min(clamp[j], Mathf.Max(boxMax[j], points[i][j]));
            }
        }

        Vector3 p = Vector3.zero;
        for (p.x = boxMin.x; p.x < boxMax.x; p.x++)
        {
            for (p.y = boxMin.y; p.y < boxMax.y; p.y++)
            {
                //Vector3 barycentric = MathUtil.GetBarycentricByPoints(P1, P2, P3, p);
                Vector3 barycentric = MathUtil.GetBarycentricBySides(P1, P2, P3,p);

                //determine if the pixel is in a triangle
                if (barycentric.x >= 0 && barycentric.y >= 0 && barycentric.x + barycentric.y <= 1)
                {
                    //formula (5.8.1)
                    Color lerpColor = barycentric.x * Color1 + barycentric.y * Color2 + barycentric.z * Color3;
                    Screen.SetPixel((int)p.x,(int)p.y,lerpColor);
                }
            }
        }


    }
}
