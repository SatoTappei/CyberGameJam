using UnityEngine;
using UnityEngine.Events;

public class ActorBehavior : MonoBehaviour
{
    [Header("�s�k���ɍĐ�����鉉�o")]
    [SerializeField] GameObject _defeatedParitcle;
    [Header("�Ή�����v���C���[�̔ԍ�")]
    [SerializeField] int _playerNum = 1;

    IWeaponControl _weaponControl;

    public UnityAction<int> OnBorderEffectHit;

    void Awake()
    {
        _weaponControl = GetComponent<IWeaponControl>();
    }

    /// <summary>
    /// �������o�͑��葤�̔s�k���̃R�[���o�b�N�Ƃ��ēo�^����
    /// </summary>
    public void WinPerformance() => _weaponControl?.Inactive();

    void OnTriggerEnter2D(Collider2D collision)
    {
        // �R���|�[�l���g���擾�ł����ꍇ��BorderEffect�ƃq�b�g����
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
