using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public bool IsEmpty {get; private set;} = true;
    private Item _item;

    internal void PickUp(GameObject item)
    {
        IsEmpty = false;
        _item = item.GetComponent<Item>();
        item.transform.SetParent(gameObject.transform);
        item.transform.localPosition = Vector3.zero;
        item.transform.localRotation = Quaternion.identity;

        Debug.Log("Item is picked up");
    }

    internal void UseItem()
    {
        Debug.Log("I use item!");
        _item.Activate();

        IsEmpty = true;
    }
}
