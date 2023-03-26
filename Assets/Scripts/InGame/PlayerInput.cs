using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    enum PlayerNum
    {
        Player1,
        Player2,
    }

    [Header("�v���C���[�̔ԍ�")]
    [SerializeField] PlayerNum _playerNum = PlayerNum.Player1;
    [Header("���͂���L�[")]
    [SerializeField] KeyCode _up = KeyCode.W;
    [SerializeField] KeyCode _down = KeyCode.S;
    [SerializeField] KeyCode _left = KeyCode.A;
    [SerializeField] KeyCode _right = KeyCode.D;

    public int Num => (int)_playerNum;

    public KeyCode[] GetKeyCodes() => new KeyCode[4] { _up, _down, _left, _right, };
    public bool InputCorrectKeyDown(KeyCode key) => Input.GetKeyDown(key);
}
