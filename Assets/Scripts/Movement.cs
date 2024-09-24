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
        // Получаем вектор движения
        Vector3 movementVector = _inputControl.GetMovementVector();

        // Двигаем и поворачиваем объект
        Move(movementVector);
        Turn(movementVector.x); // Используем горизонтальную ось для вращения
    }

    private void Move(Vector3 direction)
    {
        Vector3 moveForce = direction * _moveSpeed;
        _rigidBody.AddForce(moveForce, ForceMode.Force);
    }

    private void Turn(float horizontalInput)
    {
        // Создаем вектор для вращающего момента по оси Y, используя горизонтальный вход
        Vector3 torque = Vector3.up * horizontalInput * _turnTorque;
        _rigidBody.AddTorque(torque, ForceMode.Force);
    }
}
