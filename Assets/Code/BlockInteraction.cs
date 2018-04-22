using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInteraction : MonoBehaviour {

	public GameObject cam;

	// Use this for initialization
	void Start () {

	}

	//when you click on a mesh, you will be given a coordinate that represents the chunk 
	//loacation and block location  
	//to get the blocks postion we take away the chunks postion

	//raycast determine which block has been it from the first persion view.

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) //get left mouse button when its clicked
		{
			RaycastHit hit; //where the ray hit


			//for cross hairs and postion/direction of ray
			if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10))
				//length of raycast is 10, so you can only remove up to 10 block distance away
			{
				Vector3 hitBlock = hit.point - hit.normal/2.0f; 
				//calculate x,y,z of chunck data
				int x = (int) (Mathf.Round(hitBlock.x) - hit.collider.gameObject.transform.position.x);
				int y = (int) (Mathf.Round(hitBlock.y) - hit.collider.gameObject.transform.position.y);
				int z = (int) (Mathf.Round(hitBlock.z) - hit.collider.gameObject.transform.position.z);

				//key values for chunks that need to be updated 
				List<string> updates = new List<string>();
				float thisChunkx = hit.collider.gameObject.transform.position.x;
				float thisChunky = hit.collider.gameObject.transform.position.y;
				float thisChunkz = hit.collider.gameObject.transform.position.z;

				updates.Add(hit.collider.gameObject.name);

				//update neighbours, where there is an intersections of two chunks
				if(x == 0) 
					updates.Add(World.BuildChunkName(new Vector3(thisChunkx-World.chunkSize,thisChunky,thisChunkz)));
				if(x == World.chunkSize - 1) 
					updates.Add(World.BuildChunkName(new Vector3(thisChunkx+World.chunkSize,thisChunky,thisChunkz)));
				if(y == 0) 
					updates.Add(World.BuildChunkName(new Vector3(thisChunkx,thisChunky-World.chunkSize,thisChunkz)));
				if(y == World.chunkSize - 1) 
					updates.Add(World.BuildChunkName(new Vector3(thisChunkx,thisChunky+World.chunkSize,thisChunkz)));
				if(z == 0) 
					updates.Add(World.BuildChunkName(new Vector3(thisChunkx,thisChunky,thisChunkz-World.chunkSize)));
				if(z == World.chunkSize - 1) 
					updates.Add(World.BuildChunkName(new Vector3(thisChunkx,thisChunky,thisChunkz+World.chunkSize)));

				foreach(string cname in updates)
				{
					Chunk c; //trys to finds chunk from dictionary
					if(World.chunks.TryGetValue(cname, out c))
					{
						//delete all information about that drawn chunk
						DestroyImmediate(c.chunk.GetComponent<MeshFilter>());
						DestroyImmediate(c.chunk.GetComponent<MeshRenderer>());
						DestroyImmediate(c.chunk.GetComponent<Collider>());
						//sets the chunk data to be air
						//then redraws entire chunk
						c.chunkData[x,y,z].SetType(Block.BlockType.AIR);
						c.DrawChunk();
					}
				}
			}
		}
	}
}

