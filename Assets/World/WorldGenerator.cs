using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGenerator : MonoBehaviour
{

    public GameObject cube;
    float cubeSize;

    public int surfaceSize;
    public int hillCount;
    public int hillMaxHeight;
    
    

    public List<Vector3> cubePositions { get; set; }


    void Start()
    {
        if(cube == null)
        {
            Debug.LogWarning("Cube not assigned a prefab - World generator");
            return;
        }
        

        cubePositions = new List<Vector3>();
        cubeSize = cube.transform.lossyScale.x;


        //Surface
        SurfaceGen sg = new SurfaceGen(cubeSize);
        sg.Create(surfaceSize).ForEach(c => cubePositions.Add(c));

        //Hills
        HillGen hillGenerator = new HillGen(cubeSize);
        hillGenerator.Create(hillCount, hillMaxHeight).ForEach(c => cubePositions.Add(c));


        //Create the cubes
        cubePositions.ForEach(c => AddCube(c));
    }

    GameObject AddCube(Vector3 position)
    {
        var c = Instantiate(cube, position, Quaternion.identity);
        c.transform.SetParent(gameObject.transform.root);
        return c;
    }


}
