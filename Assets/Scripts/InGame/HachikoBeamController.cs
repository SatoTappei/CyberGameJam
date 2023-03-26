using UnityEngine;

public class HachikoBeamController : MonoBehaviour
{
    [Header("ビームをマスクするオブジェクト")]
    [SerializeField] Transform _mask;
    [Header("マスクとの相対位置を調整するためのオフセット")]
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
