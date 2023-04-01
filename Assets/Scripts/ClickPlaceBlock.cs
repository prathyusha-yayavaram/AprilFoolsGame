using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;


public class ClickPlaceBlock : MonoBehaviour
{
    public Tilemap tilemap;
    public RuleTile permanentTile;
    [Header("Destructible Tile Settings")] 
    public Tile destructibleTile;
    public float timeTilDestroy = 2;


    private InputControls inputControls;
    private InputAction leftClick;
    private InputAction rightClick;

    private void Awake()
    {
        inputControls = new InputControls();
    }
    private void OnEnable()
    {
        leftClick = inputControls.Player.LeftClick;
        leftClick.Enable();
        rightClick = inputControls.Player.RightClick;
        rightClick.Enable();
    }

    public void Update()
    {
        if (leftClick.triggered)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            var pos = Camera.main.ScreenToWorldPoint(mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(pos), permanentTile);
        } else if (rightClick.triggered)
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            var pos = Camera.main.ScreenToWorldPoint(mousePosition);
            tilemap.SetTile(tilemap.WorldToCell(pos), destructibleTile);
            StartCoroutine(RemoveBlock(pos, timeTilDestroy));
        }
    }

    private IEnumerator RemoveBlock(Vector3 pos, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        tilemap.SetTile(tilemap.WorldToCell(pos), null);
    }
}
