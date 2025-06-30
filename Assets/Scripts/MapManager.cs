using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField] Cursor cursor;
    [SerializeField] CharactersManager charactersManager;
    [SerializeField] MapGenerator mapGenerator;
    Character selectedCharacter;
    List<TileObject> tileObjects = new List<TileObject>();
    List<TileObject> movableTiles = new List<TileObject>();

    private void Start()
    {
        tileObjects = mapGenerator.Generate();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit2D = Physics2D.Raycast(
                clickPosition,
                Vector2.down
            );
            if (hit2D && hit2D.collider)
            {
                cursor.SetPosition(hit2D.transform);
                TileObject tileObject = hit2D.collider.GetComponent<TileObject>();
                Debug.Log(tileObject.positionInt);
                Character character = charactersManager.GetCharacter(tileObject.positionInt);
                if (character)
                {
                    Debug.Log("found character");
                    ResetMovablePanels();
                    selectedCharacter = character;
                    ShowMovablePanels(selectedCharacter);
                }
                else
                {
                    Debug.Log("No character");
                    if (selectedCharacter)
                    {
                        if (movableTiles.Contains(tileObject))
                        {
                            selectedCharacter.Move(tileObject.positionInt);
                            
                        }
                        ResetMovablePanels();
                        selectedCharacter = null;
                    }

                }
            }
        }

    }

    void ShowMovablePanels(Character character)
    {
        // TileObject centerTile = tileObjects.Find(
        //     tile => tile.positionInt == character.Position
        // );
        // centerTile.ShowMovablePanel(true);

        movableTiles.Add(tileObjects.Find(tile => tile.positionInt == character.Position));
        movableTiles.Add(tileObjects.Find(tile => tile.positionInt == character.Position + Vector2Int.up));
        movableTiles.Add(tileObjects.Find(tile => tile.positionInt == character.Position + Vector2Int.down));
        movableTiles.Add(tileObjects.Find(tile => tile.positionInt == character.Position + Vector2Int.left));
        movableTiles.Add(tileObjects.Find(tile => tile.positionInt == character.Position + Vector2Int.right));

        foreach (var tile in movableTiles)
        {
            tile.ShowMovablePanel(true);
        }

    }

    void ResetMovablePanels()
    {
        foreach (var tile in movableTiles)
        {
            tile.ShowMovablePanel(false);
        }
        movableTiles.Clear();
    }
}
