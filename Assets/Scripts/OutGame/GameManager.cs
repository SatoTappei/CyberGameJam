using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Q�[���S�̂Ŏg�����𓝊�����N���X
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance = default;
    [Tooltip("�v���C���[1�̃L�������")] int _playerOneCharacter;
    [Tooltip("�v���C���[2�̃L�������")] int _playerTwoCharacter;

    [Tooltip("�Q�[�����J�n����Ă��邩�ǂ����̃t���O")] bool _isGameStart = false;

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

        Debug.Log($"ToggleGame�֐����Ă΂�܂��� ���݂�IsGameStart�� {_isGameStart}");
    }
}
