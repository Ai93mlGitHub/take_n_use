using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    public void Activate()
    {
        Debug.Log("I'm free!");
        Destroy(gameObject);
    }
}
