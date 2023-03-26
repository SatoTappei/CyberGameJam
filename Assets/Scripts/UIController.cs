using UnityEngine;
using DG.Tweening;

public class UIController : MonoBehaviour
{
    [SerializeField, Tooltip("テキストを順番に出すクラス")]
    private TextController _textController;

    [SerializeField, Tooltip("テキストのオブジェクト")]
    private GameObject _textObject;

    [SerializeField, Tooltip("テキストをアクティブにする時間(仮)")]
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
    /// UIをアニメーションさせながらアクティブにする
    /// </summary>
    private void EnableText()
    {
        _textObject.SetActive(true);
        _textObject.transform.DOMoveY(90, 0.5f);
        _textObject.transform.DOScale(new Vector2(1, 1), 0.5f)
            .OnComplete(() => _textController.UICommentText("二人とも頑張って!!!"));
    }
}
