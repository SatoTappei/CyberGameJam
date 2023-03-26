using UnityEngine;

public class SpriteMove : MonoBehaviour
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] float _speed = 1;

    Vector3 _velo;

    void FixedUpdate()
    {
        _rb.velocity = _velo;
    }

    public void Init(Vector3 dir)
    {
        _velo = -dir * Random.Range(0.9f, 1.1f) * _speed;
        transform.localScale = new Vector3(dir.x, 1, 1);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bachibachi"))
        {
            Destroy(gameObject);
        }
    }
}
