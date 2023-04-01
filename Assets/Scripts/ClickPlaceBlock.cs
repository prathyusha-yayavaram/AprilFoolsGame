using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;


public class ClickPlaceBlock : MonoBehaviour
{
    public Tilemap ground;
    public RuleTile tileToPlace;


    private InputControls inputControls;
    private InputAction leftClick;

    private void Awake()
    {
        inputControls = new InputControls();
    }
    private void OnEnable()
    {
        leftClick = inputControls.Player.LeftClick;
        leftClick.Enable();
    }

    public void Update()
    {
        if (leftClick.WasPerformedThisFrame())
        {
            Vector3 mousePosition = Mouse.current.position.ReadValue();
            var pos = Camera.main.ScreenToWorldPoint(mousePosition);
            ground.SetTile(ground.WorldToCell(pos), tileToPlace);
        }
    }
}
