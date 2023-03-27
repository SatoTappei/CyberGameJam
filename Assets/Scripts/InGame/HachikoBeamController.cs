using UnityEngine;

public class HachikoBeamController : MonoBehaviour, IWeaponControl
{
    [Header("ビームをマスクするオブジェクト")]
    [SerializeField] Transform _mask;
    [Header("マスクとの相対位置を調整するためのオフセット")]
    [SerializeField] float _offsetX;
    [Header("マスクの位置を反転させる")]
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

    void IWeaponControl.Inactive()
    {
        _mask.GetComponent<SpriteMask>().enabled = false;
        Debug.Log("はちこ");
    }
}
