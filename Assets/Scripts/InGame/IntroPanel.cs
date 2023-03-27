using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroPanel : MonoBehaviour
{
    [SerializeField, Tooltip("表示させるパネル")] UnityEngine.GameObject _panel;
    [SerializeField, Tooltip("カウントダウンのテキスト")] Text _countDownText;

    [SerializeField, Tooltip("カウントダウン秒数")] float _count;

    GameStreamWrapper _stream;

    public float Count => _count;

    private void Start()
    {
        _stream = GetComponent<GameStreamWrapper>();

        _stream.CallBeforeCountDown(GameManager.Instance.PlayerOne, GameManager.Instance.PlayerTwo);
    }

    private void Update()
    {
        _count -= Time.deltaTime;
        _countDownText.text = $"ゲーム開始まで {_count.ToString("F2")}...";

        if(_count < 0)
        {
            GameManager.Instance.ToggleGame();

            _stream.CallAfterCountDown();

            _panel.SetActive(false);
        }
    }
}
