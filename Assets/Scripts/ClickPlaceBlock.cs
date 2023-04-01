using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ClickPlaceBlock : MonoBehaviour
{
    public Tilemap ground;
    public RuleTile tileToPlace;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            ground.SetTile(ground.WorldToCell(pos), tileToPlace);
        }
    }
}
