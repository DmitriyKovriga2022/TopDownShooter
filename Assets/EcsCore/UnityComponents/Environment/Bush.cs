using System.Collections;
using UnityEngine;

public class Bush : SceneObject
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private new SpriteRenderer renderer;

    private void Start()
    {
        var rnd = Random.Range(0, sprites.Length);
        renderer.sprite = sprites[rnd];
    }

}