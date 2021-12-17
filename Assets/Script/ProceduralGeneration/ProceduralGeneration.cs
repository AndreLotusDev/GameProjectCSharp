using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ProceduralGeneration : MonoBehaviour
{
    //Number of blocks
    [SerializeField]
    private int maxX;
    [SerializeField]
    private int minX;
    [SerializeField]
    private int maxZ;
    [SerializeField]
    private int minZ;

    private int cornerSizeMaxX = 100;
    private int cornerSizeMinX = 50;
    private int cornerSizeMaxZ = 100;
    private int cornerSizeMinZ = 50;

    private int cornerSizeXRandom;
    private int cornerSizeYRandom;

    [SerializeField]
    private Tilemap groundToSpaw;

    [SerializeField]
    private TileBase tileToPut;

    private float spaceBetweenTwoGroundsX;
    private float spaceBetweenTwoGroundsZ;

    private int totalObjInScene;

    // Start is called before the first frame update
    void Start()
    {
        var actualSizeXRandom = Random.Range(minX, maxX);
        var actualSizeZRandom = Random.Range(minZ, maxZ);

        cornerSizeXRandom = Random.Range(cornerSizeMinX, cornerSizeMaxX);
        cornerSizeYRandom = Random.Range(cornerSizeMinZ, cornerSizeMaxZ);

        spaceBetweenTwoGroundsX = 4;
        spaceBetweenTwoGroundsZ = 4;

        GenerateArea(actualSizeXRandom, actualSizeZRandom);

        //GenerateCorners(actualSizeXRandom, actualSizeZRandom);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GenerateArea(int sizeX, int sizeZ)
    {
        for(int x = 0; x <= sizeX; x ++)
        {
            for(int z = 0; z <= sizeZ; z++)
            {
                totalObjInScene += 1;

                groundToSpaw.SetTile(new Vector3Int((int)(x * spaceBetweenTwoGroundsX), (int)(z * spaceBetweenTwoGroundsZ), (int)(z * spaceBetweenTwoGroundsZ)), tileToPut);

            }
        }
    }

    void GenerateCorners(int xPositionToStart, int zPositionToStart)
    {
        int xWithOffsetCalculated;
        int zWithOffsetCalculated ;

        for (int x = 0; x <= cornerSizeXRandom; x++)
        {
            xWithOffsetCalculated = x + xPositionToStart;

            for (int z = 0; z <= cornerSizeYRandom; z++)
            {
                zWithOffsetCalculated = z + zPositionToStart;

                totalObjInScene += 1;

                groundToSpaw.SetTile(new Vector3Int((int)(x * spaceBetweenTwoGroundsX), 0, (int)(z * spaceBetweenTwoGroundsZ)), tileToPut);
            }
        }

        Debug.Log($"Total objects: {totalObjInScene}");
    }
}
