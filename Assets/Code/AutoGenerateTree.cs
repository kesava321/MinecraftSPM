using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGenerateTree : MonoBehaviour {

    public GameObject VoxelTrunk;
    public GameObject VoxelTreeTop;

    public int positionX;
    public int positionZ;
    public int positionY;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SimpleGenerator());
        StartCoroutine(SimpleGeneratorTreeTop());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void CloneAndPlace(Vector3 newPosition, GameObject originalGameobject)
    {
        // Clone
        GameObject clone = (GameObject)Instantiate(originalGameobject, newPosition, Quaternion.identity);
        // Place
        clone.transform.position = newPosition;
        // Rename
        clone.name = "VoxelTrunk@" + clone.transform.position;
    }

    IEnumerator SimpleGenerator()
    {
        //in this frame we will instantiate 50 voxels per frame
        uint numberOfInstances = 0;
        uint instancesPerFrame = 50;
        int height = 3;

        // Compute height
        for (int positionY = -1; positionY <= height; positionY++)
          {
           // Compute the position for every voxel
           Vector3 newPosition = new Vector3(positionX, positionY, positionZ);
           // Call the method giving the new position and a Voxel instance as parameters
           CloneAndPlace(newPosition, VoxelTrunk);
           // Increment numberOfInstances
           numberOfInstances++;

           // If the number of instances per frame was met
              if (numberOfInstances == instancesPerFrame)
                {
                    // Reset numberOfInstances
                    numberOfInstances = 0;
                    // Wait for next frame
                    yield return new WaitForEndOfFrame();
                 }
           }//end for
    }

    //Tree top
    public static void CloneAndPlaceTreeTop(Vector3 newPosition, GameObject originalGameobject)
    {
        // Clone
        GameObject clone = (GameObject)Instantiate(originalGameobject, newPosition, Quaternion.identity);
        // Place
        clone.transform.position = newPosition;
        // Rename
        clone.name = "VoxelTreeTop@" + clone.transform.position;
    }

    IEnumerator SimpleGeneratorTreeTop()
    {
        //in this frame we will instantiate 50 voxels per frame
        uint numberOfInstances = 0;
        uint instancesPerFrame = 50;

        int TreeSizeX = positionX -2;
        int TreeSizeZ = positionZ -2;

        for (int x = TreeSizeX; x <= positionX+2; x++)
        {
            for (int z = TreeSizeZ; z <= positionZ+2; z++)
            {
                // Compute height
                int height = 7;
                for (int y = 4; y <= height; y++)
                {
                    // Compute the position for every voxel

                    Vector3 newPosition = new Vector3(x, y, z);

                    // Call the method giving the new position and a Voxel instance as parameters
                    CloneAndPlace(newPosition, VoxelTreeTop);
                    // Increment numberOfInstances
                    numberOfInstances++;

                    // If the number of instances per frame was met
                    if (numberOfInstances == instancesPerFrame)
                    {
                        // Reset numberOfInstances
                        numberOfInstances = 0;
                        // Wait for next frame
                        yield return new WaitForEndOfFrame();
                    }
                }//end for
            }//end for
        }
    }
}
