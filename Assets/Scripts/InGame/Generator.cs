using UnityEngine;

public class Generator : MonoBehaviour
{
    [Header("��������Prefab")]
    [SerializeField] SpriteMove _prefab;
    [Header("�����ӏ�")]
    [SerializeField] Transform _muzzle;
    [Header("�����Ԋu")]
    [SerializeField] float _interval = 1.5f;
    [Header("���]�����邩�ǂ���")]
    [SerializeField] bool _isInverse;

    float _randomInterval;
    float _timer;

    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer > _randomInterval)
        {
            _timer = 0;
            _randomInterval = _interval * Random.Range(0.9f, 1.1f);
            SpriteMove sprite = Instantiate(_prefab, _muzzle.position, Quaternion.identity);
            sprite.Init(_isInverse ? Vector3.right : Vector3.left);
        }
    }
}