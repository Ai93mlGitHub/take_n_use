using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 15f;
    [SerializeField] private float _turnSpeed = 90f;
    [SerializeField] private float _rayDistance = 3f;
    [SerializeField] private Vector3 _rayPositionOffset = new Vector3(0, 1, 0);
    [SerializeField] private Slot _slotInventory;
    [SerializeField] private float _defaultHealth = 100f;
    [SerializeField] private UIController _uiController;
    [SerializeField] private Transform _shootingPoint;

    private InputControl _inputControl = new InputControl();

    public Movement Movement { get; private set; }
    public Health Health { get; private set; }

    public Transform ShootingPoint { get; private set; }

    private void Awake()
    {
        Movement = new Movement(_uiController, _moveSpeed, _turnSpeed, _rayDistance, _rayPositionOffset);
        Health = new Health(_uiController, _defaultHealth);
        _slotInventory.SetOwner(gameObject);
        ShootingPoint = _shootingPoint;
    }

    private void Update()
    {
        PlayerMove();

        if (_inputControl.IsUsing() &&  !_slotInventory.IsEmpty)
            _slotInventory.UseItem();
    }

    private void PlayerMove()
    {
        float moveDirection = Movement.GetMovementDirection(gameObject.transform, _inputControl.GetVerticalInputStatus());
        Movement.Move(gameObject.transform, moveDirection);
        Movement.Turn(gameObject.transform, moveDirection, _inputControl.GetHorizontalInputStatus());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>() && _slotInventory.IsEmpty)
        { 
            _slotInventory.PickUp(other.gameObject);
        }

    }
}
