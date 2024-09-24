using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _turnTorque = 10f;

    private InputControl _inputControl;
    private Rigidbody _rigidBody;

    private void Awake()
    {
        _inputControl = GetComponent<InputControl>();
        _rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // �������� ������ ��������
        Vector3 movementVector = _inputControl.GetMovementVector();

        // ������� � ������������ ������
        Move(movementVector);
        Turn(movementVector.x); // ���������� �������������� ��� ��� ��������
    }

    private void Move(Vector3 direction)
    {
        Vector3 moveForce = direction * _moveSpeed;
        _rigidBody.AddForce(moveForce, ForceMode.Force);
    }

    private void Turn(float horizontalInput)
    {
        // ������� ������ ��� ���������� ������� �� ��� Y, ��������� �������������� ����
        Vector3 torque = Vector3.up * horizontalInput * _turnTorque;
        _rigidBody.AddTorque(torque, ForceMode.Force);
    }
}
