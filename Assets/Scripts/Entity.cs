using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 15f;
    [SerializeField] private float _turnSpeed = 90f;
    [SerializeField] private float _rayDistance = 3f;
    [SerializeField] private Vector3 _rayPositionOffset = new Vector3(0, 1, 0);
    [SerializeField] private ParticleSystem _deathVfx;

    private IdleBehaviorEnum _idleBehaviourEnum;
    private ReactionBehaviorEnum _reactionBehaviourEnum;
    private Movement _movement = new Movement();
    private bool _isIdle = true;
    private Behaviour _currentIdleBehaviour;
    private Behaviour _currentReactionBehaviour;
    private List<PatrolPoint> _patrolPoints;

    public Player Player { get; private set; }

    private void Awake()
    {
        _movement.InitializeMovement(_moveSpeed, _turnSpeed, _rayDistance, _rayPositionOffset);
        Player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (_isIdle)
        {
            if (_currentIdleBehaviour != null)
                _currentIdleBehaviour.Update();
        }
        else
        {
            if (_currentReactionBehaviour != null)
                _currentReactionBehaviour.Update();
        }
    }

    public List<PatrolPoint> GetPatrolPoints() => _patrolPoints;

    public Movement GetMovement() => _movement;

    public ParticleSystem GetDeathVFX() => _deathVfx;

    public Player GetPlayer() => Player;

    public void InializeEntity(IdleBehaviorEnum idleBehaviorEnum, ReactionBehaviorEnum reactionBehaviorEnum)
    {
        _patrolPoints = FindObjectsOfType<PatrolPoint>().ToList();
        _idleBehaviourEnum = idleBehaviorEnum;
        _reactionBehaviourEnum = reactionBehaviorEnum;
        _isIdle = true;
        InitializeBehaviours();
    }

    private void InitializeBehaviours()
    {
        switch (_idleBehaviourEnum)
        {
            case IdleBehaviorEnum.StandStill:
                _currentIdleBehaviour = new StandStillBehaviour();
                break;
            case IdleBehaviorEnum.PatrolPoints:
                _currentIdleBehaviour = new PatrolPointsBehaviour();
                break;
            case IdleBehaviorEnum.MoveRandomly:
                _currentIdleBehaviour = new MoveRandomlyBehaviour();
                break;
            default:
                Debug.Log("Unknown idle behavior.");
                break;
        }

        if (_currentIdleBehaviour != null)
            _currentIdleBehaviour.Initialize(this);

        switch (_reactionBehaviourEnum)
        {
            case ReactionBehaviorEnum.Flee:
                _currentReactionBehaviour = new FleeBehaviour();
                break;
            case ReactionBehaviorEnum.Aggro:
                _currentReactionBehaviour = new AggroBehaviour();
                break;
            case ReactionBehaviorEnum.ScaredDeath:
                _currentReactionBehaviour = new ScaredDeathBehaviour();
                break;
            default:
                Debug.Log("Unknown reaction behavior.");
                break;
        }

        if (_currentReactionBehaviour != null)
            _currentReactionBehaviour.Initialize(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
            _isIdle = false;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Player>())
            _isIdle = true;
    }
}