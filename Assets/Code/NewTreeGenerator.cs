using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewTreeGenerator : MonoBehaviour {
    
    public GameObject voxelTrunk;
    public GameObject voxelLeaf;
    public float positionX;
    //public float positionY;wait till height in map is implemented
    public float positionZ;

    // Use this for initialization
    void Start()
    {
        Vector3 newPosition = new Vector3(positionX, 0 , positionZ);
        //generateTree(new Vector3(1, 0, 1));//retain for automatic position, pass multiple calls with new coords
        generateTree(newPosition);
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Minimum and maximum values of the tree dimensions
    int height_min = 12;//10
    int height_max = 15;//15
    int volume_min = 15;//15
    int volume_max = 20;//20

    void generateTree(Vector3 pos)
    {
        Vector3 lastPos = pos;
        int height = Random.Range(height_min, height_max);
        int volume = Random.Range(volume_min, volume_max);
        volume += volume % 2 == 0 ? 1 : 0;
        for (int i = 0; i < height; i++)
        {
            // Clone
            GameObject clone = Instantiate(voxelTrunk);
            // Place
            clone.transform.position = new Vector3(pos.x, lastPos.y + 1f, pos.z);
            // Rename
            clone.name = "VoxelTrunk@" + clone.transform.position;
            lastPos = clone.transform.position;
        }
        for (int i = 0; i < volume; i++)
        {
            for (int j = 0; j < volume; j++)
            {
                for (int k = 0; k < volume; k++)
                {
                    if (leafSpawn(i, j, k, volume))
                    {
                        //This is where we instantiate the "block prefab and assign the leaf material"
                        GameObject clone = Instantiate(voxelLeaf);
                        clone.transform.position = new Vector3(
                        lastPos.x - volume / 2 + i,
                        lastPos.y - volume / 2 + j,
                        lastPos.z - volume / 2 + k);
                    }
                }
            }
        }
    }
    bool leafSpawn(int x, int y, int z, int vol)
    {
        float a = Mathf.Abs(-vol / 2 + x);
        float b = Mathf.Abs(-vol / 2 + y);
        float c = Mathf.Abs(-vol / 2 + z);
        float distance = Mathf.Sqrt(Mathf.Pow(a, 2) + Mathf.Pow(b, 2) + Mathf.Pow(c, 2));
        return (distance < vol / 2 && Random.Range(0, vol) > distance);
    }
}
