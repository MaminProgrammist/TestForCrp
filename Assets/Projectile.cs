using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _liveTime;

    private float _force;
    private float _slowdownValue = 1.0f;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        Invoke(nameof(Delete), _liveTime);
    }

    public void SetForce(float force)
    {
        _force = force;
    }

    public void Launch()
    {
        _rigidbody.AddForce(transform.up * _force);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Zone zone))
        {
            _slowdownValue = zone.GetSlowdownValue();
            _rigidbody.gravityScale = _slowdownValue;
            _rigidbody.velocity *= _slowdownValue;
            _rigidbody.angularVelocity *= _slowdownValue;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Zone zone))
        {
            _slowdownValue = 1.0f;
            _rigidbody.gravityScale = 1.0f;
        }
    }

    private void Delete()
    {
        Destroy(gameObject);
    }
}
