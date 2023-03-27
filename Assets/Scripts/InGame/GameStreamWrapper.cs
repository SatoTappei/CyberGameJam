using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameStreamWrapper : MonoBehaviour
{
    [SerializeField] BorderEffectController _borderEffectController;
    [SerializeField] ActorPrefabHolder _actorPrefabHolder;

    // 生成したキャラクターが死んだ時のコールバックを登録したいので保持する必要がある
    ActorBehavior _player1;
    ActorBehavior _player2;

    IEnumerator Start()
    {
        CallBeforeCountDown(1, 4);
        RegisterOnGameSet(i => Debug.Log(i + "勝利"));
        yield return new WaitForSeconds(1.0f);
        Debug.Log("3");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("2");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("1");
        yield return new WaitForSeconds(1.0f);
        Debug.Log("開始");
        CallAfterCountDown();
    }

    /// <summary>
    /// ゲーム開始時のカウントダウン後に呼ぶ
    /// BorderEffectをプレイヤーの入力で操作することが可能になる
    /// </summary>
    public void CallAfterCountDown()
    {
        _borderEffectController.enabled = true;
    }

    /// <summary>
    /// ゲーム開始時のカウントダウン前に呼ぶ
    /// プレイヤー1とプレイヤー2のIDを使ってキャラクターを画面に表示する
    /// </summary>
    public void CallBeforeCountDown(int player1ID, int player2ID)
    {
        _player1 = _actorPrefabHolder.GetActorPrefab(1, player1ID)
            .GetComponent<ActorBehavior>();
        _player2 = _actorPrefabHolder.GetActorPrefab(2, player2ID)
            .GetComponent<ActorBehavior>();
    }

    /// <summary>
    /// 決着が着いた時に呼ばれるコールバックを登録する
    /// 勝った方のプレイヤー番号を引数にして呼ばれる
    /// </summary>
    /// <param name="callback">引数にプレイヤーの番号(1 or 2)をとる関数</param>
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
