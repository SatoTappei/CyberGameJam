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
    [SerializeField, Tooltip("選択できるキャラクター")] GameObject[] _characters;
    [SerializeField, Tooltip("現在操作できるプレイヤーを表示するText")] Text _text;
    [SerializeField, Tooltip("シーン遷移の際のシーン名")] string _nextSceneName; 

    [Tooltip("現在選択されているキャラクター番号")] int _currentSelectedCharacter;
    [Tooltip("現在操作できるプレイヤー()")] int _currentPlayer = 1;

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
    /// キャラ選択フェーズ
    /// </summary>
    void SelectCharacterPhase()
    {
        switch (_currentPlayer)
        {
            case 1:
                _text.text = $"プレイヤー{_currentPlayer}はキャラクターを選択してください";
                SelectCharacter();
                break;
            case 2:
                _text.text = $"プレイヤー{_currentPlayer}はキャラクターを選択してください";
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _currentPlayer++;
        }
    }
}
