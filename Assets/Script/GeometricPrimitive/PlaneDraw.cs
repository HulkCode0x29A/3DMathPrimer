using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneDraw : MonoBehaviour
{
    public Vector3 P;

    public Vector3 N;
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
        GizmosExtension.DrawWirePlane(P,N,Color.yellow,Color.white, true);
    }

   
}
