using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム全体で使う情報を統括するクラス
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    [Tooltip("プレイヤー1(のキャラ情報)")] int _playerOne;
    [Tooltip("プレイヤー2(のキャラ情報)")] int _playerTwo;

    [Tooltip("ゲームが開始されているかどうかのフラグ")] bool _isGameStart = false;

    public int PlayerOne { get => _playerOne; set => _playerOne = value; }
    public int PlayerTwo { get => _playerTwo; set => _playerTwo = value; }
    public bool IsGameStart { get => _isGameStart; set => _isGameStart = value; }

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ChangePlayerOneCharacter(int id)
    {
        _playerOne = id;
    }

    public void ChangePlayerTwoCharacter(int id)
    {
        _playerTwo = id;
    }

    public void ToggleGame()
    {
        if (_isGameStart)
        {
            _isGameStart = false;
        }
        else
        {
            _isGameStart = true;
        }

        Debug.Log($"ToggleGame関数が呼ばれました 現在のIsGameStartは {_isGameStart}");
    }
}
