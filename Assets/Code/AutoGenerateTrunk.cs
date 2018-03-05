using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGenerateTrunk : MonoBehaviour {

    public GameObject Voxel;

    public float SizeX;
    public float SizeZ;
    public float SizeY;


    // Use this for initialization
    void Start()
    {
        StartCoroutine(SimpleGenerator());
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
                // Compute a random height
                float height = 3;//Random.Range(0, SizeY);
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
}
