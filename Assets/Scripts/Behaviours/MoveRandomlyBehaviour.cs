using UnityEngine;

public class MoveRandomlyBehaviour : IdleBehaviour
{
    private Movement _movement;
    private Transform _entityTransform;
    private float _changeDirectionInterval = 1f;
    private float _timer = 0f;
    private float _turnDirection = 0f;
    private float _moveDirection = 1f;

    public override void Initialize(MonoBehaviour controller)
    {
        Entity entity = controller as Entity;

        if (entity != null)
            _movement = entity.GetMovement();
        
        _entityTransform = controller.transform;
        ChangeRandomTurnDirection();
    }

    public override void UpdateBehaviour()
    {
        _timer += Time.deltaTime;

        if (_timer >= _changeDirectionInterval)
        {
            ChangeRandomTurnDirection();
            ChangeRandomMoveDirection();
            _timer = 0f;
        }

        if (_moveDirection > 0)
            if (_movement.RaycastObstacleCheck(_entityTransform, _moveDirection))
                ChangeMoveDirection();
            else
            if (_movement.RaycastObstacleCheck(_entityTransform, _moveDirection))
                ChangeMoveDirection();

        _movement.Turn(_entityTransform, _moveDirection, _turnDirection);
        _movement.Move(_entityTransform, _moveDirection);
    }

    private void ChangeRandomTurnDirection()
    {
        int direction = Random.Range(0, 3);

        switch (direction)
        {
            case 0:
                _turnDirection = -1;
                break;
            case 1:
                _turnDirection = 0;
                break;
            case 2:
                _turnDirection = 1;
                break;
            default:
                _turnDirection = 0;
                break;
        }
    }

    private void ChangeRandomMoveDirection()
    {
        int direction = Random.Range(0, 2);

        switch (direction)
        {
            case 0:
                _moveDirection = -1;
                break;
            case 1:
                _moveDirection = 1;
                break;
            default:
                _moveDirection = 0;
                break;
        }
    }

    private void ChangeMoveDirection() => _moveDirection = -_moveDirection;
}
