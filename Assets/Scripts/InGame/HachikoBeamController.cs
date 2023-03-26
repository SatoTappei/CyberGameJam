using UnityEngine;

public class HachikoBeamController : MonoBehaviour
{
    [Header("�r�[�����}�X�N����I�u�W�F�N�g")]
    [SerializeField] Transform _mask;
    [Header("�}�X�N�Ƃ̑��Έʒu�𒲐����邽�߂̃I�t�Z�b�g")]
    [SerializeField] float _offsetX;
    [SerializeField] bool _usePlayer2;

    Transform _borderEffect;

    void Start()
    {
        _borderEffect = UnityEngine.GameObject.Find("BorderEffect").transform;
    }

    void Update()
    {
        int dir = _usePlayer2 ? -1 : 1;

        Vector3 borderEffectPos = _borderEffect.position;
        borderEffectPos.x += _offsetX * dir;
        _mask.position = borderEffectPos;
    }
}
