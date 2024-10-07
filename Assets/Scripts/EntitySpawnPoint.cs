using UnityEngine;

public class EntitySpawnPoint : MonoBehaviour
{
    [SerializeField] private Entity _entityPrefab;
    [SerializeField] private IdleBehaviorEnum _idleBehaviour;
    [SerializeField] private ReactionBehaviorEnum _reactionBehaviour;

    private Entity _spawnedEntity;

    private Entity _entity;
    
    public void SpawnEntity()
    {
        _spawnedEntity = Instantiate<Entity>(_entityPrefab, transform.position, Quaternion.identity);
        _spawnedEntity.InializeEntity(_idleBehaviour, _reactionBehaviour);
    }
}
