using UnityEngine;

public class Building109ArmBehavior : MonoBehaviour
{
    [Header("腕のオブジェクト")]
    [SerializeField] Transform _arm;
    [Header("BorderEffectとの横方向のオフセット")]
    [SerializeField] float _offset;

    Transform _borderEffect;

    void Start()
    {
        _borderEffect = UnityEngine.GameObject.Find("BorderEffect").transform;
    }

    void Update()
    {
        Vector3 borderEffectPos = _borderEffect.position;
        borderEffectPos.x += _offset;
        _arm.position = borderEffectPos;
    }
}
