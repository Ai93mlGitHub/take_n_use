using UnityEngine;

public class RocketItem : Item
{
    [SerializeField] float _moveSpeed;
    [SerializeField] ParticleSystem _engineVFX;

    private bool _isMove = false;
    private Rigidbody _rigidBody;
    private CapsuleCollider _collider;

    private void Awake()
    {
        SetIdleSize();
        _rigidBody = gameObject.GetComponent<Rigidbody>();
        _rigidBody.isKinematic = true;
        _engineVFX.Stop();
        _collider = gameObject.GetComponent<CapsuleCollider>();
        _collider.enabled = false;
    }

    private void Update()
    {
        if (_isMove)
        {
            _rigidBody.isKinematic = false;
            Vector3 movement = transform.forward * _moveSpeed;
            _rigidBody.velocity = movement;
        }

    }

    public override void Activate(GameObject owner)
    {
        IsUsed = true;
        Transform shootingPoint = owner.GetComponent<Player>().ShootingPoint;
        gameObject.transform.SetParent(null);
        gameObject.transform.position = shootingPoint.transform.position;
        gameObject.transform.rotation = shootingPoint.transform.rotation;
        _isMove = true;
        _collider.enabled = true;
        _engineVFX.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
            return;

        if (_vfxPrefab is not null)
            Instantiate(_vfxPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
