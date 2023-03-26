using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// プレイヤーの入力を受け取ってBorderEffectオブジェクト動かす
/// このスクリプトをアクティブにすることで動く
/// </summary>
public class Logic : MonoBehaviour
{
    [SerializeField] PlayerInput _p1Controller;
    [SerializeField] PlayerInput _p2Controller;
    [Header("中心の画像")]
    [SerializeField] Transform _bachibachi;

    // 時間経過で押すキーが変わる
    // 0~3
    int _correctKeyIndex;
    float _centerPosAcceleration;

    void Awake()
    {

    }

    void Start()
    {
        //InvokeRepeating(nameof(ChangeCorrectKey), 0, 3);
    }

    void OnDisable()
    {
        //CancelInvoke(nameof(ChangeCorrectKey));
    }

    void Update()
    {
        KeyCode[] p1KeyCodes = _p1Controller.GetKeyCodes();
        KeyCode[] p2KeyCodes = _p2Controller.GetKeyCodes();
        bool p1Correct = _p1Controller.InputCorrectKeyDown(p1KeyCodes[_correctKeyIndex]);
        bool p2Correct = _p2Controller.InputCorrectKeyDown(p2KeyCodes[_correctKeyIndex]);

        if (p1Correct)
        {
            _centerPosAcceleration += 0.5f * Time.deltaTime;
        }
        if (p2Correct)
        {
            _centerPosAcceleration -= 0.5f * Time.deltaTime;
        }

        _bachibachi.Translate(new Vector2(_centerPosAcceleration, 0));
    }

    void ChangeCorrectKey() => _correctKeyIndex = Random.Range(0, 4);
}
