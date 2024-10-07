using UnityEngine;

public class MoveRandomlyBehaviour : IdleBehaviour
{
    private Movement _movement;
    private Transform _entityTransform;
    private float _changeDirectionInterval = 1f;
    private float _timer = 0f;
    private float _randomMoveDirection = 1f;
    private float _randomTurnDirection = 0f;

    public override void Initialize(MonoBehaviour controller)
    {
        Entity entity = controller as Entity;

        if (entity != null)
            _movement = entity.GetMovement();
        
        _entityTransform = controller.transform;
        ChangeDirection();
    }

    public override void UpdateBehaviour()
    {
        _timer += Time.deltaTime;

        if (_timer >= _changeDirectionInterval)
        {
            ChangeDirection();
            _timer = 0f;
        }

        if (_movement.RaycastObstacleCheck(_entityTransform, _randomMoveDirection))
            ChangeDirection();
        
        _movement.Turn(_entityTransform, _randomMoveDirection, _randomTurnDirection);
        _movement.Move(_entityTransform, _randomMoveDirection);
    }

    private void ChangeDirection()
    {
        _randomMoveDirection = Random.Range(0, 2) == 0 ? 1f : -1f;
        _randomTurnDirection = Random.Range(-1f, 1f);
    }
}
