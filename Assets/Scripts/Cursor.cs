using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Cursor : MonoBehaviour
{
    public void SetPosition(Transform target)
    {
        transform.position = target.position;
    }

   
}
