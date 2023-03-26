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
    [SerializeField, Tooltip("�I���ł���L�����N�^�[")] Image[] _characters;

    [SerializeField, Tooltip("���ݑ���ł���v���C���[��\������Text")] Text _currentText;
    [SerializeField, Tooltip("��������̃e�L�X�g")] Text _instructionText;
    [SerializeField, Tooltip("�I�𒆂̃L������\��������Image")] Sprite[] _characterImage;

    [SerializeField, Tooltip("�v���C���[�̃L�����\��")] Image[] _playerImage;
    [SerializeField, Tooltip("�v���C���[�̃L�������\��")] Text[] _playerText;

    [SerializeField, Tooltip("�V�[���J�ڂ̍ۂ̃V�[����")] string _nextSceneName;

    [Tooltip("���ݑI������Ă���L�����N�^�[�ԍ�")] int _currentSelectedCharacter = 0;
    [Tooltip("���ݑ���ł���v���C���[")] int _currentPlayer = 1;

    SceneLoader _sceneLoader;

    private void Start()
    {
        if (_currentPlayer != 1)
        {
            _currentPlayer = 1;
        }

        _currentSelectedCharacter = 0;
        Debug.Log(_currentSelectedCharacter);

        _sceneLoader = GetComponent<SceneLoader>();
    }

    private void Update()
    {
        SelectCharacterPhase();

        ChangeColor();
    }

    /// <summary>
    /// �L�����I���t�F�[�Y
    /// </summary>
    void SelectCharacterPhase()
    {
        switch (_currentPlayer)
        {
            case 1:
                //_currentText.text = $"�v���C���[{_currentPlayer}�̓L�����N�^�[��I�����Ă�������";
                //_instructionText.text = $"���FA�L�[�@���FD�L�[�@����FSpace�L�[";
                SelectCharacter();
                break;
            case 2:
                //_currentText.text = $"�v���C���[{_currentPlayer}�̓L�����N�^�[��I�����Ă�������";
                //_instructionText.text = $"���F���L�[�@���F���L�[�@����FSpace�L�[";
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
        switch (_currentPlayer)
        {
            case 1:
                if (Input.GetKeyDown(KeyCode.D))
                {
                    _currentSelectedCharacter++;
                    if (_characters.Length - 1 < _currentSelectedCharacter)
                    {
                        _currentSelectedCharacter = 0;
                    }
                    Debug.Log(_currentSelectedCharacter);
                }
                else if (Input.GetKeyDown(KeyCode.A))
                {
                    _currentSelectedCharacter--;
                    if (0 > _currentSelectedCharacter)
                    {
                        _currentSelectedCharacter = _characters.Length - 1;
                    }
                    Debug.Log(_currentSelectedCharacter);
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameManager.Instance.ChangePlayerOneCharacter(_currentSelectedCharacter);
                    Debug.Log($"�v���C���[1 : {GameManager.Instance.PlayerOneCharacter}");
                    _currentPlayer++;
                }
                break;
            case 2:

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    _currentSelectedCharacter++;
                    if(GameManager.Instance.PlayerOneCharacter == _currentSelectedCharacter)
                    {
                        _currentSelectedCharacter++;
                    }
                    if (_characters.Length - 1 < _currentSelectedCharacter)
                    {
                        _currentSelectedCharacter = 0;
                    }
                    Debug.Log(_currentSelectedCharacter);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    _currentSelectedCharacter--;
                    if (GameManager.Instance.PlayerOneCharacter == _currentSelectedCharacter)
                    {
                        _currentSelectedCharacter--;
                    }
                    if (0 > _currentSelectedCharacter)
                    {
                        _currentSelectedCharacter = _characters.Length - 1;
                    }
                    Debug.Log(_currentSelectedCharacter);
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameManager.Instance.ChangePlayerTwoCharacter(_currentSelectedCharacter);
                    Debug.Log($"�v���C���[2 : {GameManager.Instance.PlayerTwoCharacter}");
                    _currentPlayer++;
                }
                break;
        }
    }

    /// <summary>
    /// �I�𒆂̃L�����\��
    /// </summary>
    void ChangeColor()
    {
        switch (_currentPlayer)
        {
            case 1:
                foreach (var character in _characters)
                {
                    if (character != _characters[_currentSelectedCharacter])
                    {
                        character.color = Color.black;
                    }
                    else
                    {
                        character.color = Color.white;
                        _playerImage[0].sprite = _characterImage[_currentSelectedCharacter];
                        _playerText[0].text = character.name;
                    }
                }
                break;
            case 2:
                foreach (var character in _characters)
                {
                    if (character != _characters[_currentSelectedCharacter])
                    {
                        character.color = Color.black;
                    }
                    else
                    {
                        character.color = Color.white;
                        _playerImage[1].sprite = _characterImage[_currentSelectedCharacter];
                        _playerText[1].text = character.name;
                    }
                }
                break;
        }

    }
}
