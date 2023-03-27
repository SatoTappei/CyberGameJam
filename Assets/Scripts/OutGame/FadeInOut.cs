using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

/// <summary>
/// フェードインの機能
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public class FadeInOut : MonoBehaviour
{
    [SerializeField, Tooltip("表示させる画像")] Image _image;
    [SerializeField, Tooltip("どのシーンに移動させるか")] string _loadSceneName;
    [SerializeField, Tooltip("フェードインさせるかどうか")] bool _ableToFadeIn;


    CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;

        if (_ableToFadeIn)
        {
            StartFadeIn();
        }
    }

    public void StartFadeIn(float endValue = 0, float duration = 1f)
    {
        _canvasGroup.alpha = 1f;
        _image.DOFade(endValue, duration).OnComplete(BlockRayCast);
    }

    public void StartFadeOut(float endValue = 1, float duration = 1f)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        _image.DOFade(endValue, duration).OnComplete(() => SceneManager.LoadScene(_loadSceneName));
    }

    public void SceneLoad()
    {
        StartFadeOut();
    }

    void BlockRayCast()
    {
        _canvasGroup.blocksRaycasts = false;
    }
}
