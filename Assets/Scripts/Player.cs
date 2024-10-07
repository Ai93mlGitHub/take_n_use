using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 15f;
    [SerializeField] private float _turnSpeed = 90f;
    [SerializeField] private float _rayDistance = 3f;
    [SerializeField] private Vector3 _rayPositionOffset = new Vector3(0, 1, 0);
    [SerializeField] private Slot _slotInventory;
    [SerializeField] private Transform _shootingPoint;
    [SerializeField] private float _defaultHealth = 100f;
    [SerializeField] private UIController _uiController;
    [SerializeField] private ParticleSystem[] _chasisSmoke;

    private InputControl _inputControl = new InputControl();

    public Movement Movement { get; private set; } = new Movement();
    public Health Health { get; private set; } = new Health();
    public Transform ShootingPoint { get; private set; }

    private void Awake()
    {
        Health.InitializeHealth(_uiController, _defaultHealth);
        Movement.InitializeMovement(_uiController, _moveSpeed, _turnSpeed, _rayDistance, _rayPositionOffset);
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

        if (moveDirection != 0)
            ChasisSmokePlay();
        else
            ChasisSmokeStop();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>() && _slotInventory.IsEmpty)
        { 
            _slotInventory.PutInSlot(other.gameObject.GetComponent<Item>());
        }
    }

    private void ChasisSmokePlay()
    {
        foreach (ParticleSystem smoke in _chasisSmoke)
            smoke.Play();
    }

    private void ChasisSmokeStop()
    {
        foreach (ParticleSystem smoke in _chasisSmoke)
            smoke.Stop();
    }
}
