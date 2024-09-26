using UnityEngine;

public class Missile : MonoBehaviour
{
    protected Slot _slot;

    protected bool _onPlace = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Contact!");

        _slot = collision.gameObject.GetComponentInChildren<Slot>();

        transform.SetParent(_slot.transform);
    }
}
