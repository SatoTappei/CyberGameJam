using UnityEngine;

/// <summary>
/// プレイヤーの入力を受け取ってBorderEffectオブジェクト動かす
/// このスクリプトをアクティブにすることで動く
/// </summary>
public class BorderEffectController : MonoBehaviour
{
    [SerializeField] PlayerInput _p1Controller;
    [SerializeField] PlayerInput _p2Controller;
    [Header("バチバチのオブジェクト")]
    [SerializeField] Transform _borderEffect;
    [Header("加速量")]
    [SerializeField] float _acceleration = 0.5f;
    
    // 時間経過で押すキーが変わる
    // 0~3
    int _correctKeyIndex;
    float _currentAcceleration;

    void Awake()
    {

    }

    void Start()
    {
        //InvokeRepeating(nameof(ChangeCorrectKey), 0, 3);
    }

    void OnDisable()
    {
        CancelInvoke(nameof(ChangeCorrectKey));
    }

    void Update()
    {
        KeyCode[] p1KeyCodes = _p1Controller.GetKeyCodes();
        KeyCode[] p2KeyCodes = _p2Controller.GetKeyCodes();
        bool p1Correct = _p1Controller.InputCorrectKeyDown(p1KeyCodes[_correctKeyIndex]);
        bool p2Correct = _p2Controller.InputCorrectKeyDown(p2KeyCodes[_correctKeyIndex]);

        if (p1Correct)
        {
            _currentAcceleration += _acceleration * Time.deltaTime;
        }
        if (p2Correct)
        {
            _currentAcceleration -= _acceleration * Time.deltaTime;
        }

        _borderEffect.Translate(new Vector2(_currentAcceleration, 0));
    }

    public void InvalidBorderEffect()
    {
        enabled = false;
        _borderEffect.localScale = Vector3.zero;
    }

    void ChangeCorrectKey() => _correctKeyIndex = Random.Range(0, 4);
}
