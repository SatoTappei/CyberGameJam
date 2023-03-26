using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroPanel : MonoBehaviour
{
    [SerializeField, Tooltip("表示させるパネル")] GameObject _panel;
    [SerializeField, Tooltip("カウントダウンのテキスト")] Text _countDownText;

    [SerializeField, Tooltip("カウントダウン秒数")] float _count;

    private void Update()
    {
        _count -= Time.deltaTime;
        _countDownText.text = $"ゲーム開始まで {_count.ToString("F2")}...";

        if(_count < 0)
        {
            GameManager.Instance.ToggleGame();
            _panel.SetActive(false);
        }
    }
}
