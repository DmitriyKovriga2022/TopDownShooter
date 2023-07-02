using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GenerateBackground : MonoBehaviour
{
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap grassTilemap;
    [SerializeField] private Tilemap treeTilemap;
    [SerializeField] private Tilemap stoneTilemap;
    [SerializeField] private TileBase[] groundTiles;
    [SerializeField] private TileBase[] grassTiles;
    [SerializeField] private TileBase[] treeTiles;
    [SerializeField] private TileBase[] stoneTiles;
    [SerializeField] private Vector2Int mapsize;
    [SerializeField] private int cellSize;

    public void StartGenerate()
    {
        GenerateGround();
        GenerateTree();
        GenerateStone();
    }

    public void GenerateGround()
    {
        for (int x = 0; x < mapsize.x; x++)
        {
            for (int y = 0; y < mapsize.y; y++)
            {
                var rnd = Random.Range(0, groundTiles.Length);
                var transform = Matrix4x4.Scale(new Vector3(1.6f, 1.6f, 1));
                var changeData = new TileChangeData
                {
                    tile = groundTiles[rnd],
                    position = new Vector3Int(x - mapsize.x / 2, y - mapsize.y / 2, 0) * cellSize,
                    transform = transform
                };

                groundTilemap.SetTile(changeData, false);

                if (Random.Range(0, 5) == 0) continue;
                rnd = Random.Range(0, grassTiles.Length);
                //transform = Matrix4x4.Scale(new Vector3(Random.Range(1, 5), Random.Range(1, 10), 1));
                transform = Matrix4x4.Scale(Vector3.one);
                changeData = new TileChangeData
                {
                    tile = grassTiles[rnd],
                    position = new Vector3Int(x - mapsize.x / 2, y - mapsize.y / 2, 0) * cellSize,
                    transform = transform
                };

                grassTilemap.SetTile(changeData, false);
            }
        }
    }

    public void GenerateTree()
    {
        for (int x = 0; x < mapsize.x; x++)
        {
            for (int y = 0; y < mapsize.y; y++)
            {
                if (Random.Range(0, 100) > 20) continue;

                var rnd = Random.Range(0, treeTiles.Length);
                var transform = Matrix4x4.Scale(new Vector3(3, 3, 1));
                var changeData = new TileChangeData
                {

                    tile = treeTiles[rnd],
                    position = new Vector3Int(x - mapsize.x / 2, y - mapsize.y / 2, 0) * cellSize,
                    transform = transform

                };

                treeTilemap.SetTile(changeData, false);
            }
        }
    }

    public void GenerateStone()
    {
        for (int x = 0; x < mapsize.x; x++)
        {
            for (int y = 0; y < mapsize.y; y++)
            {
                if (Random.Range(0, 100) > 30) continue;

                var rnd = Random.Range(0, stoneTiles.Length);
                var transform = Matrix4x4.Scale(new Vector3(3, 3, 1));
                var changeData = new TileChangeData
                {

                    tile = stoneTiles[rnd],
                    position = new Vector3Int(x - mapsize.x / 2, y - mapsize.y / 2, 0) * cellSize,
                    transform = transform

                };

                stoneTilemap.SetTile(changeData, false);
            }
        }
    }
}
