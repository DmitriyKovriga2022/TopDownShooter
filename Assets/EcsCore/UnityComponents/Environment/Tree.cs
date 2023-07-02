using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : SceneObject
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private new SpriteRenderer renderer;

    private void Start()
    {
        var rnd = Random.Range(0, sprites.Length);
        renderer.sprite = sprites[rnd];
        rnd = Random.Range(0, 1);
        if (rnd == 0)
        {
            renderer.flipX = true;
        }
    }
}
