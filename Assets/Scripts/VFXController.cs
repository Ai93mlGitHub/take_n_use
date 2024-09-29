using UnityEngine;

public class VFXController : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;

    private void Start() => _particleSystem.Play();

    private void Update()
    {
        if (!_particleSystem.IsAlive())
            Destroy(gameObject);
    }
}
