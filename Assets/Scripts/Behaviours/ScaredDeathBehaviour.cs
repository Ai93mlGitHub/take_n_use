using UnityEngine;

public class ScaredDeathBehaviour : IdleBehaviour
{
    private Transform _entityTransform;
    private ParticleSystem _deathParticlesPrefab;
    private float _destroyDelay = 0f;
    private bool _isDeathing = false;

    public override void Initialize(MonoBehaviour controller)
    {
        Entity entity = controller as Entity;
        _entityTransform = controller.transform;
        _deathParticlesPrefab = entity.GetDeathVFX();
    }

    public override void UpdateBehaviour()
    {
        if (_deathParticlesPrefab != null && _isDeathing == false)
        {
            MonoBehaviour.Instantiate(_deathParticlesPrefab, _entityTransform.position, Quaternion.identity);
            _isDeathing = true;
        }

        MonoBehaviour.Destroy(_entityTransform.gameObject, _destroyDelay);
    }
}

