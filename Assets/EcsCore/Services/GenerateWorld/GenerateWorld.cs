using NavMeshPlus.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

public class GenerateWorld : MonoBehaviour
{
    public event Action EventEndGeneration;

    [SerializeField] private NavMeshSurface Surface2D;
    [SerializeField] private BuildNavMesh buildNavMesh;
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap grassTilemap;
    [SerializeField] private Tilemap treeTilemap;
    [SerializeField] private Tilemap stoneTilemap;
    [SerializeField] private Tilemap collisionTilemap;
    [SerializeField] private TileBase[] groundTiles;
    [SerializeField] private TileBase[] grassTiles;
    [SerializeField] private TileBase[] treeTiles;
    [SerializeField] private TileBase[] stoneTiles;
    [SerializeField] private TileBase colliderTile;
    [Space]
    [SerializeField] private UnityComponent.Unit unitPrefab;

    private GridData gridData;

    public void Initialise(GridData gridData)
    {
        this.gridData = gridData;
    }

    public void StartGenerate()
    {
        GenerateGround();
        GenerateTree();
        //GenerateStone();

        Surface2D.BuildNavMeshAsync().completed += EndBuildNavMesh;
    }

    public void GenerateGround()
    {
        for (int x = 0; x < gridData.GridSize.x; x++)
        {
            for (int y = 0; y < gridData.GridSize.y; y++)
            {
                var rnd = UnityEngine.Random.Range(0, groundTiles.Length);
                var transform = Matrix4x4.Scale(new Vector3(1.6f, 1.6f, 1));
                var changeData = new TileChangeData
                {
                    tile = groundTiles[rnd],
                    position = new Vector3Int(x - gridData.GridSize.x / 2, y - gridData.GridSize.y / 2, 0) * gridData.CellSize,
                    transform = transform
                };

                groundTilemap.SetTile(changeData, false);

                if (UnityEngine.Random.Range(0, 5) == 0) continue;
                rnd = UnityEngine.Random.Range(0, grassTiles.Length);
                transform = Matrix4x4.Scale(Vector3.one);
                var position = new Vector3Int(x - gridData.GridSize.x / 2, y - gridData.GridSize.y / 2, 0) * gridData.CellSize;
                changeData = new TileChangeData
                {
                    tile = grassTiles[rnd],
                    position = position,
                    transform = transform
                };

                grassTilemap.SetTile(changeData, false);
            }
        }
    }

    public void GenerateTree()
    {
        for (int x = 0; x < gridData.GridSize.x; x++)
        {
            for (int y = 0; y < gridData.GridSize.y; y++)
            {
                if (UnityEngine.Random.Range(0, 100) > 40) continue;

                var rnd = UnityEngine.Random.Range(0, treeTiles.Length);
                var transform = Matrix4x4.Scale(new Vector3(3, 3, 1));
                var position = new Vector3Int(x - gridData.GridSize.x / 2, y - gridData.GridSize.y / 2, 0) * gridData.CellSize;
                var changeData = new TileChangeData
                {
                    tile = treeTiles[rnd],
                    position = position,
                    transform = transform
                };

                treeTilemap.SetTile(changeData, false);
                collisionTilemap.SetTile(position, colliderTile);
            }
        }
    }

    public void GenerateStone()
    {
        for (int x = 0; x < gridData.GridSize.x; x++)
        {
            for (int y = 0; y < gridData.GridSize.y; y++)
            {
                if (UnityEngine.Random.Range(0, 100) > 30) continue;

                var rnd = UnityEngine.Random.Range(0, stoneTiles.Length);
                var transform = Matrix4x4.Scale(new Vector3(3, 3, 1));
                var position = new Vector3Int(x - gridData.GridSize.x / 2, y - gridData.GridSize.y / 2, 0) * gridData.CellSize;
                var changeData = new TileChangeData
                {
                    tile = stoneTiles[rnd],
                    position = position,
                    transform = transform
                };

                stoneTilemap.SetTile(changeData, false);
                collisionTilemap.SetTile(position, colliderTile);
            }
        }
    }

    //public void SpawnEnemy()
    //{
        
    //    var iteration = 100;
    //    var unitCount = 0;//5;
    //    while (unitCount > 0)
    //    {
    //        iteration--;
    //        if (RandomPoint(out Vector3 position))
    //        {
    //            var unit = Instantiate(unitPrefab, (Vector3)position, Quaternion.identity);
    //            AiCombat aiCombat = unit.gameObject.AddComponent<AiCombat>();
    //            aiCombat.Initialise(mapsize);
    //            unitCount--;
    //        }

    //        if (iteration < 0)
    //        {
    //            Debug.LogError("Cant find free position for spawn unit");
    //            break;
    //        }
    //    }
    //}

    private bool GenerateEmptyRandomPositions(float radius, out Vector2 position)
    {
        position = new Vector2(UnityEngine.Random.Range(-gridData.GridSize.x/2, gridData.GridSize.x/2), 
                               UnityEngine.Random.Range(-gridData.GridSize.y/2, gridData.GridSize.y/2));
        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, radius);
        if (colliders.Length == 0)
        {
            Debug.Log("Generated position " + position);
            return true;
        }
        else
        {
            return false;
        }
    }

    private void EndBuildNavMesh(AsyncOperation asyncOperation)
    {
        asyncOperation.completed -= EndBuildNavMesh;
        EventEndGeneration?.Invoke();
    }

}
