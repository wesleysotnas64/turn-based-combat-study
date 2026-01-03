using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    [SerializeField] public List<Sprite> sprites;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        RandomSprite();
    }

    private void RandomSprite()
    {
        spriteRenderer.sprite = sprites[Random.Range(0,sprites.Count)];
    }
}
