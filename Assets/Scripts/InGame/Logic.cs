using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �v���C���[�̓��͂��󂯎����BorderEffect�I�u�W�F�N�g������
/// ���̃X�N���v�g���A�N�e�B�u�ɂ��邱�Ƃœ���
/// </summary>
public class Logic : MonoBehaviour
{
    [SerializeField] PlayerInput _p1Controller;
    [SerializeField] PlayerInput _p2Controller;
    [Header("���S�̉摜")]
    [SerializeField] Transform _bachibachi;

    // ���Ԍo�߂ŉ����L�[���ς��
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
