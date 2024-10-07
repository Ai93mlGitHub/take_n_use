using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected Vector3 _sizeInIdle = new Vector3(2f, 2f, 2f);
    [SerializeField] protected Vector3 _sizeInUse = new Vector3(1f, 1f, 1f);
    [SerializeField] protected VFXController _vfxPrefab;

    public bool IsUsed { get; protected set; } = false;

    private void Awake() => SetIdleSize();

    public void SetUseSize() => transform.localScale = _sizeInUse;

    public void SetIdleSize() => transform.localScale = _sizeInIdle;

    public virtual void Activate(GameObject owner)
    {
        IsUsed = true; 
        
        if (_vfxPrefab is not null)
            Instantiate(_vfxPrefab, transform.position, Quaternion.identity);

        DestroyItem();
    }

    public virtual void DestroyItem()
    {
        Destroy(gameObject);
    }
}
