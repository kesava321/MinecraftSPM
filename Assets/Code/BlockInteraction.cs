using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockInteraction : MonoBehaviour {

	public GameObject cam;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            
            //for mouse clicking
            //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
   			//if ( Physics.Raycast (ray,out hit,10)) 
   			//{
            
   			//for cross hairs
            if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 10))
            {
   				Vector3 hitBlock = hit.point - hit.normal/2.0f; 

   				int x = (int) (Mathf.Round(hitBlock.x) - hit.collider.gameObject.transform.position.x);
   				int y = (int) (Mathf.Round(hitBlock.y) - hit.collider.gameObject.transform.position.y);
   				int z = (int) (Mathf.Round(hitBlock.z) - hit.collider.gameObject.transform.position.z);

   		
	   				Chunk c;
				if(World.chunks.TryGetValue(hit.collider.gameObject.name, out c))
					{
						DestroyImmediate(c.chunk.GetComponent<MeshFilter>());
						DestroyImmediate(c.chunk.GetComponent<MeshRenderer>());
						DestroyImmediate(c.chunk.GetComponent<Collider>());
						c.chunkData[x,y,z].SetType(Block.BlockType.AIR);
				   		c.DrawChunk();
			   		}
			   	}
		   	}
   		}
	}

