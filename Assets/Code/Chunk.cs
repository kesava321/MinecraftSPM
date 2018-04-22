﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk {

	public Material cubeMaterial;
	public Block[,,] chunkData;
    public GameObject chunk;
	public enum ChunkStatus {DRAW,DONE,KEEP}; //Various states of chunks
	public ChunkStatus status; //status of current chunks
    bool treesCreated = false;

    void BuildChunk()
    {
        chunkData = new Block[World.chunkSize, World.chunkSize, World.chunkSize];

        //create blocks
        for (int z = 0; z < World.chunkSize; z++)
            for (int y = 0; y < World.chunkSize; y++)
                for (int x = 0; x < World.chunkSize; x++)
                {
                    Vector3 pos = new Vector3(x, y, z);
                    int worldX = (int)(x + chunk.transform.position.x);
                    int worldY = (int)(y + chunk.transform.position.y);
                    int worldZ = (int)(z + chunk.transform.position.z);

                    //start with lowest to top layers
                    if (Utils.fBM3D(worldX, worldY, worldZ, 0.1f, 3) < 0.42f)
                        chunkData[x, y, z] = new Block(Block.BlockType.AIR, pos,
                            chunk.gameObject, this);
                    else if (worldY == 0)
                        chunkData[x, y, z] = new Block(Block.BlockType.BEDROCK, pos,
                            chunk.gameObject, this);
                    else if (worldY <= Utils.GenerateStoneHeight(worldX, worldZ))
                    {
                        if (Utils.fBM3D(worldX, worldY, worldZ, 0.1f, 2) < 0.35f && worldY < 45)
                            chunkData[x, y, z] = new Block(Block.BlockType.DIAMOND, pos,
                                chunk.gameObject, this);
                        else if (Utils.fBM3D(worldX, worldY, worldZ, 0.003f, 3) < 0.41f && worldY < 20)
                            chunkData[x, y, z] = new Block(Block.BlockType.REDSTONE, pos,
                                chunk.gameObject, this);
                        else
                            chunkData[x, y, z] = new Block(Block.BlockType.STONE, pos,
                                chunk.gameObject, this);
                    }
                    else if (worldY == Utils.GenerateHeight(worldX, worldZ))
                    {
                        if (Utils.fBM3D(worldX, worldY, worldZ, 0.3f, 2) < 0.3f)//adjust values for how many trees
                            chunkData[x, y, z] = new Block(Block.BlockType.WOODBASE, pos,
                                      chunk.gameObject, this);
                        else
                            chunkData[x, y, z] = new Block(Block.BlockType.GRASS, pos,
                                      chunk.gameObject, this);
                    }
                    else if(worldY < Utils.GenerateHeight(worldX, worldZ))
                        chunkData[x, y, z] = new Block(Block.BlockType.DIRT, pos,
                            chunk.gameObject, this);
                    else
                        chunkData[x, y, z] = new Block(Block.BlockType.AIR, pos,
                            chunk.gameObject, this);
					status = ChunkStatus.DRAW; //Block has just been created and is ready to be drawn.
                }
    }

	public void DrawChunk()	
    {  

        if(!treesCreated)
        {
            for (int z = 0; z < World.chunkSize; z++)
                for (int y = 0; y < World.chunkSize; y++)
                    for (int x = 0; x < World.chunkSize; x++)
                {
                        BuildTrees(chunkData[x, y, z], x, y, z);
                }
            treesCreated = true;
        }
        //draw chunks of blocks
		for(int z = 0; z < World.chunkSize; z++)
			for(int y = 0; y < World.chunkSize; y++)
            for(int x = 0; x < World.chunkSize; x++)
				{
					chunkData[x,y,z].Draw();

				}
		CombineQuads();
		MeshCollider collider = chunk.gameObject.AddComponent (typeof(MeshCollider)) as MeshCollider;
		collider.sharedMesh = chunk.transform.GetComponent<MeshFilter> ().mesh;
	}

    void BuildTrees(Block trunk, int x, int y, int z)
    {
        if (trunk.bType != Block.BlockType.WOODBASE) return;

            Block t = trunk.GetBlock(x, y + 1, z);
            if (t != null)
            {
                t.SetType(Block.BlockType.WOOD);
                Block t1 = t.GetBlock(x, y + 2, z);
                if (t1 != null)
                {
                    t1.SetType(Block.BlockType.WOOD);

                    for (int i = -1; i <= 1; i++)
                        for (int j = -1; j <= 1; j++)
                            for (int k = 3; k <= 4; k++)
                            {
                                Block t2 = trunk.GetBlock(x + i, y + k, z + j);

                                if (t2 != null)
                                {
                                    t2.SetType(Block.BlockType.LEAVES);
                                }
                                else return;
                            }
                    Block t3 = t1.GetBlock(x, y + 5, z);
                    if (t3 != null)
                    {
                        t3.SetType(Block.BlockType.LEAVES);
                    }
                }
            }
       }


	// Use this for initialization
    public Chunk (Vector3 position, Material c) {

        chunk = new GameObject(World.BuildChunkName(position));
        chunk.transform.position = position;
        cubeMaterial = c;
        BuildChunk();
    }

	void CombineQuads()
	{
		//1. Combine all children meshes
		MeshFilter[] meshFilters = chunk.GetComponentsInChildren<MeshFilter>();
		CombineInstance[] combine = new CombineInstance[meshFilters.Length];
		int i = 0;
		while (i < meshFilters.Length) {
			combine[i].mesh = meshFilters[i].sharedMesh;
			combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
			i++;
		}

		//2. Create a new mesh on the parent object
		MeshFilter mf = (MeshFilter) chunk.gameObject.AddComponent(typeof(MeshFilter));
		mf.mesh = new Mesh();

		//3. Add combined meshes on children as the parent's mesh
		mf.mesh.CombineMeshes(combine);

		//4. Create a renderer for the parent
		MeshRenderer renderer = chunk.gameObject.AddComponent(typeof(MeshRenderer)) as MeshRenderer;
		renderer.material = cubeMaterial;

		//5. Delete all uncombined children
		foreach (Transform quad in chunk.transform) {
			GameObject.Destroy(quad.gameObject);
		}

	}

}