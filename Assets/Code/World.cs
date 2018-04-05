using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class World : MonoBehaviour
{
	public GameObject player;
    public Material textureAtlas;
    public static int columnHeight = 16;
    public static int chunkSize = 16;
    public static int worldSize = 4;
	public static int radius = 1; //how many blocks around the player that are to be displayed
    public static Dictionary<string, Chunk> chunks;//holds chunks instead of array
	public Slider loadingStatus; //the value that is shown in the slider 


    //needed for consistent name of chunk
    public static string BuildChunkName(Vector3 v)
    {
        return (int)v.x + "_" +
                     (int)v.y + "_" +
                     (int)v.z;
    }


    IEnumerator BuildChunkColumn()
    {
        for (int i = 0; i < columnHeight; i++)
        {
            Vector3 chunkPosition = new Vector3(this.transform.position.x,
                                               i * chunkSize,
                                                this.transform.position.z);
            Chunk c = new Chunk(chunkPosition, textureAtlas);
            c.chunk.transform.parent = this.transform;
            chunks.Add(c.chunk.name, c);

        }

        foreach(KeyValuePair<string,Chunk>c in chunks)
        {
            c.Value.DrawChunk();
            yield return null;
        }


    }

    IEnumerator BuildWorld()
    {
		//gets the position of the floor in the players world diveded by the chunck size.
		int posx = (int)Mathf.Floor(player.transform.position.x/chunkSize);
		int posz = (int)Mathf.Floor(player.transform.position.z/chunkSize);

		//calculate the number of chunks to be processedin total
		//this is done by multiplying the number of chunks found in the for loop
		//total chunk is float, because if it was an int it cuts of any decimal values.  
		float totalChunks = (Mathf.Pow(radius*2+1,2) * columnHeight) * 2; //multiplying by 2, as we are building chunk and then drawing chunk
			int processCount = 0;

		for(int z = -radius; z <= radius; z++)
			for(int x = -radius; x <= radius; x++)
				for(int y = 0; y < columnHeight; y++)
                {
					Vector3 chunkPosition = new Vector3((x+posx)*chunkSize, 
						y*chunkSize, 
						(posz+z)*chunkSize);
                    Chunk c = new Chunk(chunkPosition, textureAtlas);
                    c.chunk.transform.parent = this.transform;
                    chunks.Add(c.chunk.name, c);
					processCount ++;
					loadingStatus.value = processCount/totalChunks * 100; 
					yield return null;
                }

        foreach (KeyValuePair<string, Chunk> c in chunks)
        {
            c.Value.DrawChunk();
			processCount ++;
			loadingStatus.value = processCount/totalChunks * 100;
            yield return null;
        }
		player.SetActive (true);
    }

	public void StartBuild() //Starts when play button is pressed
	{
		StartCoroutine(BuildWorld());
	}
		

	// Use this for initialization
	void Start () {
		player.SetActive(false); //stops player from falling down the generated world
        chunks = new Dictionary<string, Chunk>();
        this.transform.position = Vector3.zero;
        this.transform.rotation = Quaternion.identity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
