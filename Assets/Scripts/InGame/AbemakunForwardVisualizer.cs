using UnityEngine;

public class AbemakunForwardVisualizer : MonoBehaviour
{
    [Header("オフセット")]
    [SerializeField] Vector3 _offset;

    Transform _transform;
    Transform _borderEffect;

    void Awake()
    {
        _transform = transform;
    }

    void Start()
    {
        _borderEffect = GameObject.Find("BorderEffect").transform;
    }

    void Update()
    {
        Vector3 pos = _borderEffect.position;
        pos.x += _offset.x;
        pos.y += _offset.y;
        pos.z += _offset.z;
        _transform.position = pos;
    }
}
