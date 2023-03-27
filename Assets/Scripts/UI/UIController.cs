using System.Collections;
using UnityEngine;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField, Tooltip("テキストを順番に出すクラス")]
    private TextController _textController;

    [SerializeField, Tooltip("テキストのオブジェクト")]
    private GameObject _textObject;

    [SerializeField, Tooltip("衝突エフェクトのオブジェクト")]
    private Transform _effectTransform;

    [SerializeField, Tooltip("テキストをアクティブにする時間(仮)")]
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
    /// 引数に入れた文字がが実況のコメントになる
    /// </summary>
    public void TextActive(string comment)
    {
        StartCoroutine(TextAnimation(comment));
    }

    /// <summary>
    /// テキストを表示させた後、数秒待って消す
    /// </summary>
    IEnumerator TextAnimation(string comment)
    {
        // UIをアニメーションさせながらアクティブにする
        _isTween = true;
        _textObject.SetActive(true);
        _textObject.transform.DOMoveY(_h, 0.5f);
        _textObject.transform.DOScale(Vector3.one, 0.5f)
            .OnComplete(() => _textController.UICommentText(comment));

        yield return new WaitForSeconds(5f);

        // UIをアニメーションさせながら非アクティブにする
        _textObject.transform.DOMoveY(-6, 0.5f)
    　　　　.OnComplete(() => _textObject.transform.DOScale(new Vector2(0.8f, 0.8f), 0.5f)
    　　　　.OnComplete(() =>
    　　　　{
        　　　　_textController.RemoveText();
       　　　　 _isTween = false;
       　　　　 _textObject.SetActive(false);
   　　　　 }));
    }

    /// <summary>
    /// 衝突エフェクトの位置によって実況のコメントを変える
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
            return "パチ公";
        }
        else if(playerId == 2)
        {
            return "モワイ";
        }
        else if(playerId == 3)
        {
            return "アベマ";
        }

        return "Player";
    }
}
