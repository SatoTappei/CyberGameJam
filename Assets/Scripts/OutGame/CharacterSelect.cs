using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// �L�����N�^�[�I���@�\�̃N���X
/// </summary>
public class CharacterSelect : MonoBehaviour
{
    [SerializeField, Tooltip("�I���ł���L�����N�^�[")] GameObject[] _characters;
    [SerializeField, Tooltip("���ݑ���ł���v���C���[��\������Text")] Text _text;
    [SerializeField, Tooltip("�V�[���J�ڂ̍ۂ̃V�[����")] string _nextSceneName; 

    [Tooltip("���ݑI������Ă���L�����N�^�[�ԍ�")] int _currentSelectedCharacter;
    [Tooltip("���ݑ���ł���v���C���[()")] int _currentPlayer = 1;

    SceneLoader _sceneLoader;

    private void Start()
    {
        if (_currentPlayer != 1)
        {
            _currentPlayer = 1;
        }

        _sceneLoader = GetComponent<SceneLoader>();
    }

    private void Update()
    {
        SelectCharacterPhase();
    }

    /// <summary>
    /// �L�����I���t�F�[�Y
    /// </summary>
    void SelectCharacterPhase()
    {
        switch (_currentPlayer)
        {
            case 1:
                _text.text = $"�v���C���[{_currentPlayer}�̓L�����N�^�[��I�����Ă�������";
                SelectCharacter();
                break;
            case 2:
                _text.text = $"�v���C���[{_currentPlayer}�̓L�����N�^�[��I�����Ă�������";
                SelectCharacter();
                break;
            case 3:
                _sceneLoader.SceneLoad(_nextSceneName);
                break;
        }
    }


    /// <summary>
    /// �L�����I��
    /// </summary>
    void SelectCharacter()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentPlayer++;
        }
    }
}
