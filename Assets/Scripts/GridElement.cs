using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridElement : PoolableObjectBase
{
    [SerializeField] private SpriteRenderer sprite;
    private int height;
    private int width;

    public int Height { get => height; set => height = value; }
    public int Width { get => width; set => width = value; }

    public override void Init(int height, int width)
    {
        this.Height = height;
        this.Width = width;
    }

    public void DeInit()
    {
        sprite.enabled = false;
        height = 0;
        width = 0;
    }
}