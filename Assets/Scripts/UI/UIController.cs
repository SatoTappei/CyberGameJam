using System.Collections;
using UnityEngine;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField, Tooltip("�e�L�X�g�����Ԃɏo���N���X")]
    private TextController _textController;

    [SerializeField, Tooltip("�e�L�X�g�̃I�u�W�F�N�g")]
    private GameObject _textObject;

    [SerializeField, Tooltip("�Փ˃G�t�F�N�g�̃I�u�W�F�N�g")]
    private Transform _effectTransform;

    [SerializeField, Tooltip("�e�L�X�g���A�N�e�B�u�ɂ��鎞��(��)")]
    private float _textTime = 10f;

    [SerializeField]
    private string[] _comments;

    [SerializeField]
    private float _h;

    private float _timer;

    private bool _isTime = false;

    private bool _isTween = false;

    private bool _isRight = false;

    private bool _isLeft = false;

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _textTime && !_isTime)
        {
            _isTime = true;
            TextActive(_comments[0]);
        }

        EffectDistance();
    }

    /// <summary>
    /// �����ɓ��ꂽ�������������̃R�����g�ɂȂ�
    /// </summary>
    public void TextActive(string comment)
    {
        StartCoroutine(TextAnimation(comment));
    }

    /// <summary>
    /// �e�L�X�g��\����������A���b�҂��ď���
    /// </summary>
    IEnumerator TextAnimation(string comment)
    {
        // UI���A�j���[�V���������Ȃ���A�N�e�B�u�ɂ���
        _isTween = true;
        _textObject.SetActive(true);
        _textObject.transform.DOMoveY(_h, 0.5f);
        _textObject.transform.DOScale(Vector3.one, 0.5f)
            .OnComplete(() => _textController.UICommentText(comment));

        yield return new WaitForSeconds(5f);

        // UI���A�j���[�V���������Ȃ����A�N�e�B�u�ɂ���
        _textObject.transform.DOMoveY(-6, 0.5f)
    �@�@�@�@.OnComplete(() => _textObject.transform.DOScale(new Vector2(0.8f, 0.8f), 0.5f)
    �@�@�@�@.OnComplete(() =>
    �@�@�@�@{
        �@�@�@�@_textController.RemoveText();
       �@�@�@�@ _isTween = false;
       �@�@�@�@ _textObject.SetActive(false);
   �@�@�@�@ }));
    }

    /// <summary>
    /// �Փ˃G�t�F�N�g�̈ʒu�ɂ���Ď����̃R�����g��ς���
    /// </summary>
    private void EffectDistance()
    {
        if (_effectTransform.position.x >= 3 && !_isTween && !_isRight)
        {
            TextActive(_comments[1]);
            _isTween = true;
            _isRight = true;
            _isLeft = false;
        }
        else if (_effectTransform.position.x <= -3 && !_isTween && !_isLeft)
        {
            TextActive(_comments[2]);
            _isTween = true;
            _isLeft = true;
            _isRight = false;
        }
    }
}
