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
            TextActive("二人とも頑張って!!!");
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
        _textObject.transform.DOMoveY(90, 0.5f);
        _textObject.transform.DOScale(new Vector2(1, 1), 0.5f)
            .OnComplete(() => _textController.UICommentText(comment));

        yield return new WaitForSeconds(5f);

        // UIをアニメーションさせながら非アクティブにする
        _textObject.transform.DOMoveY(-90, 0.5f)
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
        if (_effectTransform.position.x >= 3 && !_isTween && !_isRight)
        {
            TextActive("左のランドマークが優勢です!!!");
            _isTween = true;
            _isRight = true;
            _isLeft = false;
        }
        else if (_effectTransform.position.x <= -3 && !_isTween && !_isLeft)
        {
            TextActive("右のランドマークが優勢です!!!");
            _isTween = true;
            _isLeft = true;
            _isRight = false;
        }
    }
}
