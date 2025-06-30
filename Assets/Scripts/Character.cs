using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] Vector2Int positionInt;
    public Vector2Int Position { get => positionInt; }

    // Start is called before the first frame update
    void Start()
    {
        transform.position = (Vector2)positionInt;
    }

    public void Move(Vector2Int pos)
    {
        positionInt = pos;
        transform.position = (Vector2)positionInt;
    }
}
