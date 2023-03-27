using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStreamWrapper : MonoBehaviour
{
    [SerializeField] BorderEffectController _borderEffectController;
    [SerializeField] ActorPrefabHolder _actorPrefabHolder;

    // ���������L�����N�^�[�����񂾎��̃R�[���o�b�N��o�^�������̂ŕێ�����K�v������
    ActorBehavior _player1;
    ActorBehavior _player2;

    IEnumerator Start()
    {
        CallBeforeCountDown(1, 4);
        RegisterOnGameSet(i => Debug.Log(i + "����"));
        yield return new WaitForSeconds(1.0f);
        Debug.Log("3");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("2");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("1");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("�J�n");
        CallAfterCountDown();
    }

    /// <summary>
    /// �Q�[���J�n���̃J�E���g�_�E����ɌĂ�
    /// BorderEffect���v���C���[�̓��͂ő��삷�邱�Ƃ��\�ɂȂ�
    /// </summary>
    public void CallAfterCountDown()
    {
        _borderEffectController.enabled = true;
    }

    /// <summary>
    /// �Q�[���J�n���̃J�E���g�_�E���O�ɌĂ�
    /// �v���C���[1�ƃv���C���[2��ID���g���ăL�����N�^�[����ʂɕ\������
    /// </summary>
    public void CallBeforeCountDown(int player1ID, int player2ID)
    {
        _player1 = _actorPrefabHolder.GetActorPrefab(1, player1ID)
            .GetComponent<ActorBehavior>();
        _player2 = _actorPrefabHolder.GetActorPrefab(2, player2ID)
            .GetComponent<ActorBehavior>();
    }

    /// <summary>
    /// ���������������ɌĂ΂��R�[���o�b�N��o�^����
    /// ���������̃v���C���[�ԍ��������ɂ��ČĂ΂��
    /// </summary>
    /// <param name="callback">�����Ƀv���C���[�̔ԍ�(1 or 2)���Ƃ�֐�</param>
    public void RegisterOnGameSet(UnityAction<int> callback)
    {
        _player1.OnBorderEffectHit += _ => _player2.WinPerformance();
        _player2.OnBorderEffectHit += _ => _player1.WinPerformance();
        _player1.OnBorderEffectHit += _ => _borderEffectController.InvalidBorderEffect();
        _player2.OnBorderEffectHit += _ => _borderEffectController.InvalidBorderEffect();
        _player1.OnBorderEffectHit += callback;
        _player2.OnBorderEffectHit += callback;
    }
}
