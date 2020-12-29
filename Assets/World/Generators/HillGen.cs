using System;
using System.Collections.Generic;
using UnityEngine;

public class HillGen : Generator
{

    private List<Vector3> hillCubes;

    public HillGen(float cubeSize) : base(cubeSize)
    {

    }

    public List<Vector3> Create(int hillCount, int maxHeight)
    {
        if (hillCount == 0)
            Debug.LogWarning("Hill Count not assigned");
        if (maxHeight == 0)
            Debug.LogWarning("Hill Max Height not assigned");


        hillCubes = new List<Vector3>();
        Vector3[] points = HillPoints(hillCount);

        foreach(var p in points)
        {
            var heightRng = random.Next(1, maxHeight);
            Vector3 newHillTop = new Vector3(p.x, heightRng * cubeSize+offset, p.z);

            CreatePillar(newHillTop);
        }


        return hillCubes;
    }

    
    void CreatePillar(Vector3 origin)
    {
        Vector3 temp = new Vector3(origin.x, origin.y - cubeSize, origin.z);
        while (!CubeExists(temp) && temp.y > 0)
        {
            hillCubes.Add(temp);
            foreach (var adj in CreateAdjacentCubes(temp))
            {
                CreatePillar(adj);
            }
            //Next
            temp = new Vector3(temp.x, temp.y - cubeSize, temp.z);
        }
    }

    Vector3[] CreateAdjacentCubes(Vector3 origin)
    {
        List<Vector3> adjCubes = new List<Vector3>();
        foreach(var coord in surroundingCubePositions)
        {
            var adjacent = origin + coord;
            if (!CubeExists(adjacent))
            {
                adjCubes.Add(adjacent);
                hillCubes.Add(adjacent);
            }
        }
        return adjCubes.ToArray();
    }


    bool CubeExists(Vector3 temp)
    {
        if (cubeReferances.Contains(temp) || hillCubes.Contains(temp)){
            return true;
        }
        return false;
    }

    Vector3[] HillPoints(int count)
    {
        List<Vector3> points = new List<Vector3>();
        int counter = count*3; // Dersom loopen kjører 3 ganger mer en count, så stopper vi
        while (points.Count != count)
        {
            if (counter == 0) break;
            int r = random.Next(0, cubeReferances.Count);
            Vector3 temp = cubeReferances[r];
            if (!points.Contains(temp))
            {
                points.Add(temp);
                continue;
            }
            counter--;
        }
        return points.ToArray();
    }

}
