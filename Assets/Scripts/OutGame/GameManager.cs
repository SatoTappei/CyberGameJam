using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���S�̂Ŏg�����𓝊�����N���X
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    [Tooltip("�v���C���[1(�̃L�������)")] int _playerOne;
    [Tooltip("�v���C���[2(�̃L�������)")] int _playerTwo;

    [Tooltip("�Q�[�����J�n����Ă��邩�ǂ����̃t���O")] bool _isGameStart = false;

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

        Debug.Log($"ToggleGame�֐����Ă΂�܂��� ���݂�IsGameStart�� {_isGameStart}");
    }
}
