using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour {

	public Material cubeMaterial;

	IEnumerator BuildChunk(int sizeX, int sizeY, int sizeZ)
	{
		for(int z = 0; z < sizeZ; z++)
			for(int y = 0; y < sizeY; y++)
				for(int x = 0; x < sizeX; x++)
				{
					Vector3 pos = new Vector3(x,y,z);
					Block b = new Block(Block.BlockType.DIRT, pos, 
						this.gameObject, cubeMaterial);
					b.Draw();
					yield return null;
				}
		CombineQuads();
	}

	// Use this for initialization
	void Start () {
		StartCoroutine(BuildChunk(4,4,4));
	}

	// Update is called once per frame
	void Update () {

	}