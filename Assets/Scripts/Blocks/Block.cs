using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

[CreateAssetMenu(menuName = "Blocks/BasicBlock")]
public class Block : ScriptableObject
{
    [SerializeField]
    public string blockName;
    [SerializeField]
    public Tile tileToPlace;
    [SerializeField]
    public int availableQuantity;

    protected Vector3 pos;
    protected Tilemap _tilemap;
    public void Place(Tilemap tilemap)
    {
        availableQuantity--;
        _tilemap = tilemap;
        Vector3 mousePosition = Mouse.current.position.ReadValue();
        pos = Camera.main.ScreenToWorldPoint(mousePosition);
        tilemap.SetTile(tilemap.WorldToCell(pos), tileToPlace);
        OnPlace();
    }
    protected virtual void OnPlace()
    {
        
    }
}
