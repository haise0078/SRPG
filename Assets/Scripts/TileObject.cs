using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour
{
    public Vector2Int positionInt;

    [SerializeField] GameObject movablePanel;

    public void ShowMovablePanel(bool isActive)
    {
        movablePanel.SetActive(isActive);
    }
}
