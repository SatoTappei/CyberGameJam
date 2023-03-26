using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    [Header("飛んでいく速度")]
    [SerializeField] float _speed = 10;

    Transform _transform;
    Vector3 _velo;

    void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        _transform.Translate(_velo * Time.deltaTime);
    }

    public void Init(Vector3 dir)
    {
        _velo = -dir * Random.Range(0.9f, 1.1f) * _speed;
        transform.localScale = new Vector3(dir.x, 1, 1);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // BorderEffectコンポーネントが取得出来たらBorderEffectとヒットした
        if (collision.TryGetComponent(out BorderEffect _))
        {
            Destroy(gameObject);
        }
    }
}
