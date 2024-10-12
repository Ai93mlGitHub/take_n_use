using UnityEngine;

public class AggroBehaviour : Behaviour
{
    private Movement _movement;
    private Transform _entityTransform;
    private Transform _playerTransform;
    private float _stoppingDistance = 1.5f;
    private Player _player;

    private const float _directionForward = 1f;
    private const float _directionNone = 0f;

    public override void Initialize(MonoBehaviour controller)
    {
        Entity entity = controller as Entity;

        if (entity != null)
        {
            _movement = entity.GetMovement();
            _player = entity.GetPlayer();

            if (_player != null)
                _playerTransform = _player.transform;
            else
                Debug.Log("Player not found.");
        }

        _entityTransform = controller.transform;
    }

    public override void Update()
    {
        if (_playerTransform == null)
        {
            Debug.Log("Player transform is null");
            return;
        }

        float distanceToPlayer = Vector3.Distance(_entityTransform.position, _playerTransform.position);

        if (distanceToPlayer <= _stoppingDistance)
            return;

        if (_movement.RaycastObstacleCheck(_entityTransform, _directionForward))
            _movement.Move(_entityTransform, _directionNone);
        else
            _movement.Move(_entityTransform, _directionForward);

        Vector3 directionToPlayer = (_playerTransform.position - _entityTransform.position).normalized;
        float turnDirection = Vector3.SignedAngle(_entityTransform.forward, directionToPlayer, Vector3.up) / 180f;
        _movement.Turn(_entityTransform, _directionForward, turnDirection);
    }
}
