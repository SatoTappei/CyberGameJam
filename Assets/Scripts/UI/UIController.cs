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

    private GameManager _gameManager;

    private bool _isTime = false;

    private bool _isTween = false;

    private bool _isRight = false;

    private bool _isLeft = false;

    private float _testTimer = 12f;

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }

    private void Update()
    {
        _testTimer -= Time.deltaTime;

        if (_testTimer <= _textTime && !_isTime)
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
        int comment = Random.Range(1, _comments.Length);
        if (_effectTransform.position.x >= 3 && !_isTween && !_isRight)
        {
            _isTween = true;
            _isRight = true;
            _isLeft = false;

            if(comment <= 3)
            {
                TextActive(SelectPlayer(_gameManager.PlayerOne) + _comments[comment]);
            }
            else
            {
                TextActive(SelectPlayer(_gameManager.PlayerTwo) + _comments[comment]);
            }
            
        }
        else if (_effectTransform.position.x <= -3 && !_isTween && !_isLeft)
        {
            _isTween = true;
            _isLeft = true;
            _isRight = false;

            if (comment <= 3)
            {
                TextActive(SelectPlayer(_gameManager.PlayerTwo) + _comments[comment]);
            }
            else
            {
                TextActive(SelectPlayer(_gameManager.PlayerOne) + _comments[comment]);
            }
        }
    }
    private string SelectPlayer(int playerId)
    {
        if(playerId == 0)
        {
            return "106";
        }
        else if(playerId == 1)
        {
            return "�p�`��";
        }
        else if(playerId == 2)
        {
            return "�����C";
        }
        else if(playerId == 3)
        {
            return "�A�x�}";
        }

        return "Player";
    }
}
