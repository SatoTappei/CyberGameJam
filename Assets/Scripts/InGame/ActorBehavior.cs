using UnityEngine;
using UnityEngine.Events;

public class ActorBehavior : MonoBehaviour
{
    [Header("�s�k���ɍĐ�����鉉�o")]
    [SerializeField] GameObject _defeatedParitcle;
    [Header("����������BorderEffect�ƐڐG�������ɌĂ΂��")]
    [SerializeField] UnityEvent _onBorderEffectHit;
    [SerializeField] Transform _sprite;
    [Header("�v���C���[2�Ƃ��Ĉ���")]
    [SerializeField] bool _usePlayer2;

    void Start()
    {

    }

    void OnDisable()
    {
        _onBorderEffectHit = null;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // �R���|�[�l���g���擾�ł����ꍇ��BorderEffect�ƃq�b�g����
        if (collision.TryGetComponent(out BorderEffect _))
        {
            Instantiate(_defeatedParitcle, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            _onBorderEffectHit?.Invoke();
        }
    }
}