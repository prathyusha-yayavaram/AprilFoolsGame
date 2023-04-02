using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Blocks/DestructibleBlock")]
public class DestructingBlock : Block
{
    public GameObject particleSystem;
    public float timeTilDestroy;
    protected override void OnPlace()
    {
        Instantiate(particleSystem, new Vector2(pos.x, pos.y), Quaternion.identity);
        ClickPlaceBlock.instance.StartCoroutine(ClickPlaceBlock.instance.RemoveBlock(pos, timeTilDestroy));
    }
}
