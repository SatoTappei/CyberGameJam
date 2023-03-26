using UnityEngine;
using UnityEngine.Events;

public class ActorBehavior : MonoBehaviour
{
    [Header("敗北時に再生される演出")]
    [SerializeField] GameObject _defeatedParitcle;
    [Header("押し負けてBorderEffectと接触した時に呼ばれる")]
    [SerializeField] UnityEvent _onBorderEffectHit;

    void OnDisable()
    {
        _onBorderEffectHit = null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // コンポーネントを取得できた場合はBorderEffectとヒットした
        if (collision.TryGetComponent(out BorderEffect _))
        {
            Instantiate(_defeatedParitcle, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            _onBorderEffectHit?.Invoke();
        }
    }
}
