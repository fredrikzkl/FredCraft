using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube
{
    Vector3 position;
    float size;

    public Cube(GameObject cube, Vector3 position)
    {
        size = cube.transform.lossyScale.x;
        
    }


}
