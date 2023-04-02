using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;


public class ClickPlaceBlock : MonoBehaviour
{
    public static ClickPlaceBlock instance;
    [SerializeField]
    public List<Block> blocks;

    public int selectedBlockIndex = 0;
    public Tilemap tilemap;
    public RuleTile permanentTile;
    [Header("Destructible Tile Settings")] 
    public Tile destructibleTile;
    public float timeTilDestroy = 2;


    private InputControls inputControls;
    private InputAction leftClick;
    private InputAction rightClick;
    private InputAction numKeys;

    private void Awake()
    {
        instance = this;
        inputControls = new InputControls();
    }
    private void OnEnable()
    {
        leftClick = inputControls.Player.LeftClick;
        leftClick.Enable();
        rightClick = inputControls.Player.RightClick;
        rightClick.Enable();
        numKeys = inputControls.Player.NumberKeys;
        numKeys.Enable();
    }

    public void Update()
    {
        var currBlock = blocks[selectedBlockIndex];
        if (numKeys.WasPerformedThisFrame())
        {
            var readValue = (int)numKeys.ReadValue<float>() - 1;
            if (readValue < blocks.Count)
            {
                selectedBlockIndex = readValue;
            }
        }
        if (leftClick.triggered && currBlock && currBlock.availableQuantity > 0)
        {
            currBlock.Place(tilemap);
        }
    }

    public IEnumerator RemoveBlock(Vector3 pos, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        tilemap.SetTile(tilemap.WorldToCell(pos), null);
    }
}
