using UnityEngine;
using System.Collections.Generic;

public class PatrolPointsBehaviour : IdleBehaviour
{
    private List<PatrolPoint> _patrolPoints;
    private int _currentPointIndex = 0;
    private Movement _movement;
    private Transform _entityTransform;
    private float _stoppingDistance = 1f;

    public override void Initialize(MonoBehaviour controller)
    {
        Entity entity = controller as Entity;
        _patrolPoints = entity != null ? entity.GetPatrolPoints() : new List<PatrolPoint>();
        _movement = entity.GetMovement();
        _entityTransform = controller.transform;
    }

    public override void UpdateBehaviour()
    {
        if (_patrolPoints == null || _patrolPoints.Count == 0)
        {
            Debug.Log("There aren't patrol points .");
            return;
        }

        PatrolPoint targetPoint = _patrolPoints[_currentPointIndex];
        float distanceToTarget = Vector3.Distance(_entityTransform.position, targetPoint.transform.position);

        if (distanceToTarget <= _stoppingDistance)
        {
            _currentPointIndex = (_currentPointIndex + 1) % _patrolPoints.Count;
        }
        else
        {
            Vector3 directionToTarget = (targetPoint.transform.position - _entityTransform.position).normalized;
            float moveDirection = 1;
            float turnDirection = Vector3.SignedAngle(_entityTransform.forward, directionToTarget, Vector3.up) / 180f;
            _movement.Turn(_entityTransform, moveDirection, turnDirection);
            _movement.Move(_entityTransform, moveDirection);
        }
    }
}
