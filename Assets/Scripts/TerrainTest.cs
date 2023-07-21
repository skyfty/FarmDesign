using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTest : MonoBehaviour
{
    public Terrain terrain;

    public float heightScale = 1f;
    public float detailScale = 1f;
    void Start()
    {
        TerrainData terrainData = terrain.terrainData;

        int heightmapWidth = terrainData.heightmapResolution;
        int heightmapHeight = terrainData.heightmapResolution;
        float[,] heights = new float[heightmapWidth, heightmapHeight];

        //for (int x = 0; x < heightmapWidth; x++)
        //{
        //    for (int y = 0; y < heightmapHeight; y++)
        //    {
        //        float height = Mathf.PerlinNoise(x * detailScale, y * detailScale) * heightScale;
        //        heights[x, y] = height;
        //    }
        //}
        //heights[11,11]=20;


        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                heights[i, j] = 1 * 0.05f;
            }
        }
        //heights[1, 1] = 0.5f;
        //heights[2, 2] = 1.5f;
        //heights[3, 3] = 0.5f;
        //heights[4, 4] = 1.5f;
        //heights[5, 5] = 0f;
        //heights[6, 6] = 0.5f;
        //heights[8, 8] = 1.5f;
        terrainData.SetHeights(0, 0, heights);
    }
    //public int Test;
    //private void OnValidate()
    //{
    //    TerrainData terrainData = terrain.terrainData;

    //    int heightmapWidth = terrainData.heightmapResolution;
    //    int heightmapHeight = terrainData.heightmapResolution;
    //    float[,] heights = new float[heightmapWidth, heightmapHeight];

    //    //for (int x = 0; x < heightmapWidth; x++)
    //    //{
    //    //    for (int y = 0; y < heightmapHeight; y++)
    //    //    {
    //    //        float height = Mathf.PerlinNoise(x * detailScale, y * detailScale) * heightScale;
    //    //        heights[x, y] = height;
    //    //    }
    //    //}
    //    //heights[11,11]=20;


    //    for (int i = 0; i < 10; i++)
    //    {
    //        for (int j = 0; j < 10; j++)
    //        {
    //            heights[i, j] = i * 1;
    //        }
    //    }
    //    terrainData.SetHeights(0, 0, heights);
    //}


}
