using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// キャラクター選択機能のクラス
/// </summary>
public class CharacterSelect : MonoBehaviour
{
    [SerializeField, Tooltip("選択できるキャラクター")] Image[] _characters;

    [SerializeField, Tooltip("現在操作できるプレイヤーを表示するText")] Text _currentText;
    [SerializeField, Tooltip("操作説明のテキスト")] Text _instructionText;

    [SerializeField, Tooltip("シーン遷移の際のシーン名")] string _nextSceneName; 

    [Tooltip("現在選択されているキャラクター番号")] int _currentSelectedCharacter = 0;
    [Tooltip("現在操作できるプレイヤー")] int _currentPlayer = 1;

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
    /// キャラ選択フェーズ
    /// </summary>
    void SelectCharacterPhase()
    {
        switch (_currentPlayer)
        {
            case 1:
                _currentText.text = $"プレイヤー{_currentPlayer}はキャラクターを選択してください";
                _instructionText.text = $"←：Aキー　→：Dキー　決定：Spaceキー";
                SelectCharacter();
                break;
            case 2:
                _currentText.text = $"プレイヤー{_currentPlayer}はキャラクターを選択してください";
                _instructionText.text = $"←：←キー　→：→キー　決定：Spaceキー";
                SelectCharacter();
                break;
            case 3:
                _sceneLoader.SceneLoad(_nextSceneName);
                break;
        }
    }


    /// <summary>
    /// キャラ選択
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
                    if(0 > _currentSelectedCharacter)
                    {
                        _currentSelectedCharacter = _characters.Length - 1;
                    }
                    Debug.Log(_currentSelectedCharacter);
                }

                if (Input.GetKeyDown(KeyCode.Space))
                {
                    GameManager.Instance.PlayerOneCharacter = _currentSelectedCharacter;
                    Debug.Log($"プレイヤー1 : {GameManager.Instance.PlayerOneCharacter}");
                    _currentPlayer++;
                }
                break;
            case 2:

                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    _currentSelectedCharacter++;
                    if (_characters.Length - 1 < _currentSelectedCharacter)
                    {
                        _currentSelectedCharacter = 0;
                    }
                    Debug.Log(_currentSelectedCharacter);
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow))
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
                    GameManager.Instance.PlayerTwoCharacter = _currentSelectedCharacter;
                    Debug.Log($"プレイヤー2 : {GameManager.Instance.PlayerTwoCharacter}");
                    _currentPlayer++;
                }
                break;
        }
    }

    /// <summary>
    /// 選択していないキャラ画像の色を変える
    /// </summary>
    void ChangeColor()
    {
        foreach(var character in _characters)
        {
            if(character != _characters[_currentSelectedCharacter])
            {
                character.color = Color.black;
            }
            else
            {
                character.color = Color.white;
            }
        }
    }
}
