using UnityEngine;

public class RepairKitItem : Item
{
    [SerializeField] private float _repairPower;
    public override void Activate(GameObject owner)
    {
        owner.GetComponent<Player>().Health.IncreaseHealthValue(_repairPower);
        base.Activate(owner);
    }
}