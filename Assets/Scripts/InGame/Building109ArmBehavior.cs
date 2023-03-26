using UnityEngine;

public class Building109ArmBehavior : MonoBehaviour
{
    [Header("�r�̃I�u�W�F�N�g")]
    [SerializeField] Transform _arm;
    [Header("BorderEffect�Ƃ̉������̃I�t�Z�b�g")]
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
