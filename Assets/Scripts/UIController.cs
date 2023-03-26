using UnityEngine;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField, Tooltip("�e�L�X�g�����Ԃɏo���N���X")]
    private TextController _textController;

    [SerializeField, Tooltip("�e�L�X�g�̃I�u�W�F�N�g")]
    private GameObject _textObject;

    [SerializeField, Tooltip("�e�L�X�g���A�N�e�B�u�ɂ��鎞��(��)")]
    private float _textTime = 10f;

    private float _timer;

    private bool _isText = true;

    private void Update()
    {
        _timer += Time.deltaTime;
        
        if(_timer >= _textTime && _isText)
        {
            EnableText();
            _isText = false;
        }
    }

    /// <summary>
    /// UI���A�j���[�V���������Ȃ���A�N�e�B�u�ɂ���
    /// </summary>
    private void EnableText()
    {
        _textObject.SetActive(true);
        _textObject.transform.DOMoveY(90, 0.5f);
        _textObject.transform.DOScale(new Vector2(1, 1), 0.5f)
            .OnComplete(() => _textController.UICommentText("��l�Ƃ��撣����!!!"));
    }
}
