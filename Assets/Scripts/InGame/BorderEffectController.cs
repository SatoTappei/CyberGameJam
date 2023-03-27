using UnityEngine;

/// <summary>
/// �v���C���[�̓��͂��󂯎����BorderEffect�I�u�W�F�N�g������
/// ���̃X�N���v�g���A�N�e�B�u�ɂ��邱�Ƃœ���
/// </summary>
public class BorderEffectController : MonoBehaviour
{
    [SerializeField] PlayerInput _p1Controller;
    [SerializeField] PlayerInput _p2Controller;
    [Header("�o�`�o�`�̃I�u�W�F�N�g")]
    [SerializeField] Transform _borderEffect;
    [Header("������")]
    [SerializeField] float _acceleration = 0.5f;
    
    // ���Ԍo�߂ŉ����L�[���ς��
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
