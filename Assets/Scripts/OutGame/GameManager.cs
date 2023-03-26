using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ゲーム全体で使う情報を統括するクラス
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    [Tooltip("プレイヤー1のキャラ情報")] int _playerOneCharacter;
    [Tooltip("プレイヤー2のキャラ情報")] int _playerTwoCharacter;

    [Tooltip("ゲームが開始されているかどうかのフラグ")] bool _isGameStart = false;

    public int PlayerOneCharacter { get => _playerOneCharacter; set => _playerOneCharacter = value; }
    public int PlayerTwoCharacter { get => _playerTwoCharacter; set => _playerTwoCharacter = value; }
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
        _playerOneCharacter = id;
    }

    public void ChangePlayerTwoCharacter(int id)
    {
        _playerTwoCharacter = id;
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
