using UnityEngine;

/// <summary>
/// スクリプトのオンオフで生成を切り替える
/// </summary>
public class WeaponGenerator : MonoBehaviour
{
    [Header("発射するPrefab")]
    [SerializeField] LinearMovement _prefab;
    [Header("生成する際のオフセット")]
    [SerializeField] Vector3 _offset;
    [Header("生成する間隔")]
    [SerializeField] float _interval;
    
    Transform _transform;

    void Awake()
    {
        _transform = transform;
    }

    void OnEnable()
    {
        InvokeRepeating(nameof(InstantiateMissile), 0, _interval);
    }

    void OnDisable()
    {
        CancelInvoke(nameof(InstantiateMissile));
    }

    void InstantiateMissile()
    {
        Vector3 pos = transform.position;
        pos.x += _offset.x;
        pos.y += _offset.y;
        pos.z += _offset.z;

        LinearMovement behavior = Instantiate(_prefab, pos, Quaternion.identity, _transform);
        behavior.Init(Vector3.left);
    }
}
