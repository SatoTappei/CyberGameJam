using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// ゲームリザルトのクラス
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public class GameResult : MonoBehaviour
{
    [SerializeField, Tooltip("表示させる画像")] Image[] _image;
    CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShowResult();
        }
    }

    public void ShowResult(float endValue = 1, float duration = 1f)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        _image[0].DOFade(endValue, duration);
    }
}
