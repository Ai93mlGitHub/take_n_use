using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 15f;
    [SerializeField] private float _turnSpeed = 90f;
    [SerializeField] private float _rayDistance = 3f;
    [SerializeField] private Vector3 _rayPositionOffset = new Vector3(0, 1, 0);
    [SerializeField] private Slot _slotInventory;

    private Movement _movement;
    private InputControl _inputControl = new InputControl();

    private void Awake()
    {
        _movement = new Movement(_moveSpeed, _turnSpeed, _rayDistance, _rayPositionOffset);
    }

    private void Update()
    {
        PlayerMove();

        if (_inputControl.IsUsing() &&  !_slotInventory.IsEmpty)
            _slotInventory.UseItem();
    }

    private void PlayerMove()
    {
        float moveDirection = _movement.GetMovementDirection(gameObject.transform, _inputControl.GetVerticalInputStatus());
        _movement.Move(gameObject.transform, moveDirection);
        _movement.Turn(gameObject.transform, moveDirection, _inputControl.GetHorizontalInputStatus());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>() && _slotInventory.IsEmpty)
        { 
            Debug.Log("I see Item");
            _slotInventory.PickUp(other.gameObject);
        }

    }

    public void TakeHealth()
    {

    }

    public void TakeAccelerator(float increaseValue)
    {
        _movement.SetSpeed(increaseValue);
    }
}
