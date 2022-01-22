using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    left,
    right,
    up,
    down
}

public class player : MonoBehaviour
{
    private MapController mapController;
    private Controls controls;
    private Vector2Int gridPosition;

    private void Awake()
    {
        mapController = FindObjectOfType<MapController>();
        gridPosition = new Vector2Int(3, 3);
        controls = new Controls();
        controls.Gameplay.Up.performed += _ => Move(Direction.up);
        controls.Gameplay.Down.performed += _ => Move(Direction.down);
        controls.Gameplay.Left.performed += _ => Move(Direction.left);
        controls.Gameplay.Right.performed += _ => Move(Direction.right);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Start()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        transform.position = mapController.GridPositionToWorldPosition(gridPosition);
    }

    private void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.left:
                gridPosition.x += -1;
                break;
            case Direction.right:
                gridPosition.x += 1;
                break;
            case Direction.up:
                gridPosition.y += 1;
                break;
            case Direction.down:
                gridPosition.y += -1;
                break;
        }
        gridPosition = mapController.ReturnToGridBounds(gridPosition);
        UpdatePosition();
    }
}
