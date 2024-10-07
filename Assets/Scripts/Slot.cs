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

    public void PutInSlot(Item item)
    {
        _item = item;

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
        _item = null;
    }
}
