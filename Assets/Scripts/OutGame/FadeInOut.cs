using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

/// <summary>
/// �t�F�[�h�C���̋@�\
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public class FadeInOut : MonoBehaviour
{
    [SerializeField, Tooltip("�\��������摜")] Image _image;
    [SerializeField, Tooltip("�ǂ̃V�[���Ɉړ������邩")] string _loadSceneName;
    [SerializeField, Tooltip("�t�F�[�h�C�������邩�ǂ���")] bool _ableToFadeIn;


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
