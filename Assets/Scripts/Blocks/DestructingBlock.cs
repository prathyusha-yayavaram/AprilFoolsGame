using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Blocks/DestructibleBlock")]
public class DestructingBlock : Block
{
    public float timeTilDestroy;
    protected override void OnPlace()
    {
        ClickPlaceBlock.instance.StartCoroutine(ClickPlaceBlock.instance.RemoveBlock(pos, timeTilDestroy));
    }
}
