using System;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    [SerializeField] private SceneObject[] prefabs;
    [SerializeField] private int objectCount = 20;
    [SerializeField] private int fieldSize;

    private List<SceneObject> sceneObjects = new List<SceneObject>();

    public void Generate()
    {
        var count = objectCount;
        Vector2[] positions = new Vector2[objectCount];
        for (int i = 0; i < positions.Length; i++)
        {
            positions[i] = Vector2.zero;
        }

        while (count > 0)
        {
            Vector2 position = new Vector2(Rnd, Rnd);

            int index = Array.IndexOf(positions, position);

            if (index != -1)
            {
                int rnd = UnityEngine.Random.Range(0, prefabs.Length);
                SceneObject sceneObject = Instantiate(prefabs[rnd], new Vector2(Rnd, Rnd), Quaternion.identity, transform);
                sceneObjects.Add(sceneObject);
                count--;
            }
        }
    }

    public List<Item> GetItems()
    {
        List<Item> items = new List<Item>();

        for (int i = 0; i < sceneObjects.Count; i++)
        {
            if(sceneObjects[i] as Item)
            {
                items.Add(sceneObjects[i] as Item);
            }
        }

        return items;
    }

    private int Rnd
    {
        get
        {
            return UnityEngine.Random.Range(-fieldSize, fieldSize);
        }
    }
    
}
