using UnityEngine;

public class AcceleratorItem : Item
{
    [SerializeField] private float _speedPower;

    public override void Activate(GameObject owner)
    {
        owner.GetComponent<Player>().Movement.ChangeMoveSpeed(_speedPower);
        base.Activate(owner);
    }
}
