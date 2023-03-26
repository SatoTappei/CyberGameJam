using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{

    private Text _text;

    /// <summary>
    /// 指定された文字を順番に表示する
    /// </summary>
    public void UICommentText(string comment)
    {
        _text = GetComponent<Text>();
        StartCoroutine(TextInterval(comment));
    }

    /// <summary>
    /// 文字間のインターバル
    /// </summary>
    IEnumerator TextInterval(string comment)
    {
        foreach(char commentText in comment)
        {
            _text.text = _text.text + commentText;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
