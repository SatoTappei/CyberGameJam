using UnityEngine;

/// <summary>
/// �X�N���v�g�̃I���I�t�Ő�����؂�ւ���
/// </summary>
public class WeaponGenerator : MonoBehaviour
{
    [Header("���˂���Prefab")]
    [SerializeField] LinearMovement _prefab;
    [Header("��������ۂ̃I�t�Z�b�g")]
    [SerializeField] Vector3 _offset;
    [Header("��������Ԋu")]
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
