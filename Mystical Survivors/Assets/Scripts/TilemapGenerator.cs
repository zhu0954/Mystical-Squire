using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase[] tiles;    // Array of tiles for variation
    public int chunkSize = 10;
    public int renderDistance = 3;

    private Vector3Int playerChunkPosition;
    private Vector3Int previousPlayerChunkPosition;

    void Start()
    {
        if (tilemap == null)
        {
            Debug.LogError("Tilemap not assigned in TilemapGenerator script.");
            return;
        }

        playerChunkPosition = GetPlayerChunkPosition();
        previousPlayerChunkPosition = playerChunkPosition;

        GenerateInitialChunks();
    }

    void Update()
    {
        playerChunkPosition = GetPlayerChunkPosition();
        if (playerChunkPosition != previousPlayerChunkPosition)
        {
            GenerateChunksAroundPlayer();
            previousPlayerChunkPosition = playerChunkPosition;
        }
    }

    Vector3Int GetPlayerChunkPosition()
    {
        Vector3 playerPosition = Camera.main.transform.position;
        int chunkX = Mathf.FloorToInt(playerPosition.x / chunkSize);
        int chunkY = Mathf.FloorToInt(playerPosition.y / chunkSize);
        return new Vector3Int(chunkX, chunkY, 0);
    }

    void GenerateInitialChunks()
    {
        for (int x = -renderDistance; x <= renderDistance; x++)
        {
            for (int y = -renderDistance; y <= renderDistance; y++)
            {
                GenerateChunk(playerChunkPosition + new Vector3Int(x, y, 0));
            }
        }
    }

    void GenerateChunksAroundPlayer()
    {
        for (int x = -renderDistance; x <= renderDistance; x++)
        {
            for (int y = -renderDistance; y <= renderDistance; y++)
            {
                Vector3Int chunkPosition = playerChunkPosition + new Vector3Int(x, y, 0);
                if (!IsChunkGenerated(chunkPosition))
                {
                    GenerateChunk(chunkPosition);
                }
            }
        }
    }

    void GenerateChunk(Vector3Int chunkPosition)
    {
        for (int x = 0; x < chunkSize; x++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                Vector3Int tilePosition = new Vector3Int(chunkPosition.x * chunkSize + x, chunkPosition.y * chunkSize + y, 0);
                TileBase randomTile = tiles[Random.Range(0, tiles.Length)];
                tilemap.SetTile(tilePosition, randomTile);
            }
        }
    }

    bool IsChunkGenerated(Vector3Int chunkPosition)
    {
        for (int x = 0; x < chunkSize; x++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                Vector3Int tilePosition = new Vector3Int(chunkPosition.x * chunkSize + x, chunkPosition.y * chunkSize + y, 0);
                if (tilemap.HasTile(tilePosition))
                {
                    return true;
                }
            }
        }
        return false;
    }
}
