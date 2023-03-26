using UnityEngine;

public class HachikoBeamController : MonoBehaviour
{
    [Header("�r�[�����}�X�N����I�u�W�F�N�g")]
    [SerializeField] Transform _mask;
    [Header("�}�X�N�Ƃ̑��Έʒu�𒲐����邽�߂̃I�t�Z�b�g")]
    [SerializeField] float _offsetX;

    Transform _borderEffect;

    void Start()
    {
        _borderEffect = UnityEngine.GameObject.Find("BorderEffect").transform;
    }

    void Update()
    {
        Vector3 borderEffectPos = _borderEffect.position;
        borderEffectPos.x += _offsetX;
        _mask.position = borderEffectPos;
    }
}