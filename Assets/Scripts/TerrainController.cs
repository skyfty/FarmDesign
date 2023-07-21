using UnityEngine;

public class TerrainController : MonoBehaviour
{
    public Terrain terrain;
    public float heightScale = 1f;
    public float detailScale = 1f;

    private void Start()
    {
        TerrainData terrainData = terrain.terrainData;

        int heightmapWidth = terrainData.heightmapResolution;
        int heightmapHeight = terrainData.heightmapResolution;
        float[,] heights = new float[heightmapWidth, heightmapHeight];

        for (int x = 0; x < heightmapWidth; x++)
        {
            for (int y = 0; y < heightmapHeight; y++)
            {
                float height = Mathf.PerlinNoise(x * detailScale, y * detailScale) * heightScale;
                heights[x, y] = height;
            }
        }

        terrainData.SetHeights(0, 0, heights);
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, terrain.transform.position);
        int detailLevel = Mathf.RoundToInt(distance / 10f);

        TerrainData terrainData = terrain.terrainData;
        terrainData.wavingGrassSpeed = detailLevel * 0.1f;
        terrainData.wavingGrassAmount = detailLevel * 0.1f;
        terrainData.wavingGrassStrength = detailLevel * 0.1f;
    }
}