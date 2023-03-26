using UnityEngine;
using UnityEngine.Events;

public class Actor : MonoBehaviour
{
    [Header("”s–k‚ÉÄ¶‚³‚ê‚é‰‰o")]
    [SerializeField] GameObject _defeatedParitcle;
    [Header("‰Ÿ‚µ•‰‚¯‚ÄBorderEffect‚ÆÚG‚µ‚½‚ÉŒÄ‚Î‚ê‚é")]
    [SerializeField] UnityEvent _onBorderEffectHit;

    void OnDisable()
    {
        _onBorderEffectHit = null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(_defeatedParitcle, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
        _onBorderEffectHit?.Invoke();
    }
}
