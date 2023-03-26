using UnityEngine;

public class HachikoBeamController : MonoBehaviour
{
    [Header("�r�[�����}�X�N����I�u�W�F�N�g")]
    [SerializeField] Transform _mask;
    [Header("�}�X�N�Ƃ̑��Έʒu�𒲐����邽�߂̃I�t�Z�b�g")]
    [SerializeField] float _offsetX;
    [Header("�}�X�N�̈ʒu�𔽓]������")]
    [SerializeField] bool _isMaskFlip;

    Transform _borderEffect;

    void Start()
    {
        _borderEffect = GameObject.Find("BorderEffect").transform;
    }

    void Update()
    {
        int dir = _isMaskFlip ? -1 : 1;

        Vector3 borderEffectPos = _borderEffect.position;
        borderEffectPos.x += _offsetX * dir;
        _mask.position = borderEffectPos;
    }
}
