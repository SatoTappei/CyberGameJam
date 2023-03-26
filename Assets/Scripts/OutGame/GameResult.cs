using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

/// <summary>
/// �Q�[�����U���g�̃N���X
/// </summary>
[RequireComponent(typeof(CanvasGroup))]
public class GameResult : MonoBehaviour
{
    [SerializeField, Tooltip("�\��������p�l��")] Image _image;
    CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = 0f;
        _canvasGroup.blocksRaycasts = false;
    }

    public void ShowResult(float endValue = 1, float duration = 1f)
    {
        _canvasGroup.alpha = 1f;
        _canvasGroup.blocksRaycasts = true;
        _image.DOFade(endValue, duration);      
    }
}
