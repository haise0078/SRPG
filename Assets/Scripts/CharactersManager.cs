using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;

public class CharactersManager : MonoBehaviour
{
    public List<Character> characters = new List<Character>();
    void Start()
    {
        GetComponentsInChildren(characters);
    }
    public Character GetCharacter(Vector2Int pos)
    {
        foreach (var character in characters)
        {
            if (character.Position == pos)
            {
                return character;
            }

        }
        return null;
    }
}
