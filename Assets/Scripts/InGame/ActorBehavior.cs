using UnityEngine;
using UnityEngine.Events;

public class ActorBehavior : MonoBehaviour
{
    [Header("敗北時に再生される演出")]
    [SerializeField] GameObject _defeatedParitcle;
    [Header("対応するプレイヤーの番号")]
    [SerializeField] int _playerNum = 1;

    IWeaponControl _weaponControl;

    public UnityAction<int> OnBorderEffectHit;

    void Awake()
    {
        _weaponControl = GetComponent<IWeaponControl>();
    }

    /// <summary>
    /// 勝利演出は相手側の敗北時のコールバックとして登録する
    /// </summary>
    public void WinPerformance() => _weaponControl?.Inactive();

    void OnTriggerEnter2D(Collider2D collision)
    {
        // コンポーネントを取得できた場合はBorderEffectとヒットした
        if (collision.TryGetComponent(out BorderEffect _))
        {
            Instantiate(_defeatedParitcle, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            OnBorderEffectHit?.Invoke(_playerNum);
        }
    }

    void OnDestroy()
    {
        OnBorderEffectHit = null;
    }
}
