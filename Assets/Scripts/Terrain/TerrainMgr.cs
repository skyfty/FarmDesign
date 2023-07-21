using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class TerrainMgr : MonoBehaviour
{
    public Terrain terrain;
    private float[,] heights;
    private TerrainData terrainData;
    private int terrainHeight;
    private void Start()
    {
        terrainData = terrain.terrainData;

        int heightmapWidth = terrainData.heightmapResolution;
        int heightmapHeight = terrainData.heightmapResolution;
        //heights = new float[heightmapWidth, heightmapHeight];
        heights = terrainData.GetHeights(0, 0, heightmapWidth, heightmapHeight);
        terrainHeight = terrainData.heightmapResolution;
        Alphamaps();
        //CalcRoad(1, 1, 2, 6);
        Road(10,1,0,10);
    }

    public void Set(int i, int j, float h)
    {
        heights[i, j] = h / terrainHeight + 0.5f;

    }

    public void Render()
    {
        //terrainData.SetHeights(0, 0, heights);
        terrainData.SetHeightsDelayLOD(0, 0, heights);
    }

    //public Texture2D texture;
    private float[,,] alpha;
    public void Alphamaps()
    {
        alpha = terrainData.GetAlphamaps(0, 0, terrainData.alphamapWidth, terrainData.alphamapHeight);
        //alpha = new float[terrainData.alphamapWidth, terrainData.alphamapHeight, 3];
        #region All
        //for (int y = 0; y < terrainData.alphamapHeight; y++)
        //{
        //    for (int x = 0; x < terrainData.alphamapWidth; x++)
        //    {
        //        // Get the normalized terrain coordinate that
        //        // corresponds to the point.
        //        //float normX = x * 1.0f / (terrainData.alphamapWidth - 1);
        //        //float normY = y * 1.0f / (terrainData.alphamapHeight - 1);

        //        // Get the steepness value at the normalized coordinate.
        //        //var angle = terrainData.GetSteepness(normX, normY);

        //        // Steepness is given as an angle, 0..90 degrees. Divide
        //        // by 90 to get an alpha blending value in the range 0..1.
        //        //var frac = angle / 90.0;
        //        alpha[x, y, 0] = 1;//(float)frac;
        //        alpha[x, y, 1] = 0.5f;//(float)(1 - frac);
        //        alpha[x, y, 2] = 0.1f;
        //    }
        //}
        #endregion
        #region Range
        //for (int i = 0; i < terrainData.alphamapWidth; i++)
        //{
        //    alpha[63, i, 0] = 0f;
        //    alpha[63, i, 1] = 0f;
        //    alpha[67, i, 2] = 1f;
        //    alpha[63, i, 3] = 0f;
        //}


        #endregion

        //for (int i = 0; i < 10; i++)
        //{
        //    alpha[0, i, 0] = 1f;
        //}
        //for (int i = 0; i < 10; i++)
        //{
        //    alpha[i, 0, 0] = 1f;
        //}
        terrainData.SetAlphamaps(0, 0, alpha);
        
        //terrainData.SetAlphamaps(10, 10, alpha);
    }


    public void Road(int startX,int startZ,int dir,int distance) {
        alpha = terrainData.GetAlphamaps(0, 0, terrainData.alphamapWidth, terrainData.alphamapHeight);
        for (int i = 0; i < distance; i++)
        {
            if (dir == 0)
            {
                alpha[startX + i, startZ, 2] = 1;
                alpha[startX + i, startZ, 1] = 0;
                alpha[startX + i, startZ, 0] = 0;
            }
            if (dir == 1)
            {
                alpha[startX, startZ + i, 2] = 1;
                alpha[startX, startZ + i, 1] = 0;
                alpha[startX, startZ + i, 0] = 0;
            }
        }
        terrainData.SetAlphamaps(0, 0, alpha);
    }

    //public void CalcRoad(int startX,int startZ,int endX,int endZ) {
    //    alpha = terrainData.GetAlphamaps(0, 0, terrainData.alphamapWidth, terrainData.alphamapHeight);
    //    List<int> listY = new List<int>();
    //    for (int i = 0; i < 7; i++)
    //    {
    //        int y = (i - startX) / (endX - startX) * (endZ - startZ) + endZ;
    //        listY.Add(y);
    //        alpha[i, y, 2] = 1;
    //    }
    //    terrainData.SetAlphamaps(0, 0, alpha);
    //}


}
