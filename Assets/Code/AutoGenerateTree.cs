using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGenerateTree : MonoBehaviour {

    public GameObject Voxel;

    public float SizeX;
    public float SizeZ;
    public float SizeY;

    public GameObject VoxelTreeTop;

    public float TreeSizeX;
    public float TreeSizeZ;
    public float TreeSizeY;
    public float positionX;//to implement once function is written
    public float positionZ;
    public float positionY;

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
        clone.name = "Voxel@" + clone.transform.position;
    }

    IEnumerator SimpleGenerator()
    {
        //in this frame we will instantiate 50 voxels per frame
        uint numberOfInstances = 0;
        uint instancesPerFrame = 50;


        for (int x = 1; x <= SizeX; x++)
        {
            for (int z = 1; z <= SizeZ; z++)
            {
                // Compute height
                float height = SizeY;
                for (int y = -1; y <= height; y++)
                {
                    // Compute the position for every voxel
                    Vector3 newPosition = new Vector3(x, y, z);
                    // Call the method giving the new position and a Voxel instance as parameters
                    CloneAndPlace(newPosition, Voxel);
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


        for (int x = -1; x <= TreeSizeX; x++)
        {
            for (int z = -1; z <= TreeSizeZ; z++)//added the z
            {
                // Compute a random height
                float height = 7;
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
        }//end for
    }
}
