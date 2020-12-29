using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfaceGen : Generator
{
    public SurfaceGen(float cubeSize) : base(cubeSize)
    {
    }

    public List<Vector3> Create(int count)
    {
        List<Vector3> positions = new List<Vector3>();
        Vector3 temp_pos = Vector3.zero;
        Debug.Log("CubeSize: " + cubeSize);
        for (int i = 0 - count; i < count; i++)
        {
            for (int j = 0 - count; j < count; j++)
            {
                positions.Add(new Vector3(cubeSize * j + offset, offset, temp_pos.z + offset));
                temp_pos.x += cubeSize;
            }
            temp_pos.z += cubeSize;
        }

        return positions;
    }


    //Prøver at det er 50% sjangse for at cuben muterer i Y retning
    void CityMutation(GameObject c)
    {
        var rng = random.Next(0, 2);
        if(rng == 1)
        {
            Vector3 newCubePosition = c.transform.position;
            newCubePosition.y += c.transform.lossyScale.y;
            //AddCube(newCubePosition);
        }
    }

}
