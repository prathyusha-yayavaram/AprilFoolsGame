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

    [HideInInspector] public List<int> blockAmounts;

    public int selectedBlockIndex = 0;
    public Tilemap tilemap;

    private InputControls inputControls;
    private InputAction leftClick;
    private InputAction rightClick;
    private InputAction numKeys;

    private void Awake()
    {
        blockAmounts = new List<int>(blocks.Count);
        SetBlockAmounts();
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
            var readValue = (int)numKeys.ReadValue<float>()-1;
            if (readValue < blocks.Count && readValue >= 0)
            {
                selectedBlockIndex = readValue;
            }
        }
        if (leftClick.triggered && currBlock && blockAmounts[selectedBlockIndex]-- > 0)
        {
            currBlock.Place(tilemap);
        }
    }

    public IEnumerator RemoveBlock(Vector3 pos, float seconds)
    {
        yield return new WaitForSeconds(seconds);
        tilemap.SetTile(tilemap.WorldToCell(pos), null);
    }

    private void SetBlockAmounts()
    {
        foreach (var block in blocks)
        {
            blockAmounts.Add(block.availableQuantity);
        }
    }
}
