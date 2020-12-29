using System;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public System.Random random;

    public float cubeSize;
    public float offset;

    public List<Vector3> cubeReferances;
    public Vector3[] surroundingCubePositions;


    public Generator(float cubeSize)
    {
        this.cubeSize = cubeSize;
        offset = cubeSize / 2;
        random = new System.Random();

        InitSurroundingCubesPositions();
        RefreshCubeReferances();
    }

    public float GetRelativeCubePos()
    {
        return offset + cubeSize;
    }


    void RefreshCubeReferances()
    {
        cubeReferances = FindObjectOfType<WorldGenerator>().cubePositions;
    }

    void InitSurroundingCubesPositions()
    {
        //Clockwise, fra kl 12 :)
        Vector3[] coords = new Vector3[8];
        coords[0] = new Vector3(0,0,1);
        coords[1] = new Vector3(1,0,1);
        coords[2] = new Vector3(1,0,0);
        coords[3] = new Vector3(1,0,-1);
        coords[4] = new Vector3(0,0,-1);
        coords[5] = new Vector3(-1,0,-1);
        coords[6] = new Vector3(-1,0,0);
        coords[7] = new Vector3(-1,0,1);
        surroundingCubePositions = coords;
    }

    
}

