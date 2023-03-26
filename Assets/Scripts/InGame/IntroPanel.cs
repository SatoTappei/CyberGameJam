using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroPanel : MonoBehaviour
{
    [SerializeField, Tooltip("�\��������p�l��")] GameObject _panel;
    [SerializeField, Tooltip("�J�E���g�_�E���̃e�L�X�g")] Text _countDownText;

    [SerializeField, Tooltip("�J�E���g�_�E���b��")] float _count;

    private void Update()
    {
        _count -= Time.deltaTime;
        _countDownText.text = $"�Q�[���J�n�܂� {_count.ToString("F2")}...";

        if(_count < 0)
        {
            GameManager.Instance.ToggleGame();
            _panel.SetActive(false);
        }
    }
}
