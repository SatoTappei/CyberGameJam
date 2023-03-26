using UnityEngine;
using UnityEngine.Events;

public class Actor : MonoBehaviour
{
    [Header("�s�k���ɍĐ�����鉉�o")]
    [SerializeField] GameObject _defeatedParitcle;
    [Header("����������BorderEffect�ƐڐG�������ɌĂ΂��")]
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
