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

    public int PlayerOneCharacter { get => _playerOneCharacter; set => _playerOneCharacter = value; }
    public int PlayerTwoCharacter { get => _playerTwoCharacter; set => _playerTwoCharacter = value; }

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
}
