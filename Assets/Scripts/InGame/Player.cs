using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] UnityEvent _onBachibachiHit;

    void OnDisable()
    {
        _onBachibachiHit = null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        _onBachibachiHit?.Invoke();
    }
}
