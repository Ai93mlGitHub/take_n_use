using UnityEngine;

public class Slot : MonoBehaviour
{
    private Item _item;
    private GameObject _owner;

    public bool IsEmpty {get; private set;} = true;

    public void SetOwner(GameObject owner)
    {
        _owner = owner;
    }

    public void PickUp(GameObject item)
    {
        _item = item.GetComponent<Item>();

        if (_item.IsUsed == false)
        {
            IsEmpty = false;
            _item.SetUseSize();
            item.transform.SetParent(gameObject.transform);
            item.transform.localPosition = Vector3.zero;
            item.transform.localRotation = Quaternion.identity;
        }

    }

    public void UseItem()
    {
        _item.Activate(_owner);
        IsEmpty = true;
    }
}
