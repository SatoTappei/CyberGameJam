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
