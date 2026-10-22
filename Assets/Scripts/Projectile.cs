using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _lifeTime = 2f; // sekunde 
    private Vector3 _direction;

    void Start()
    {
        Destroy(gameObject, _lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += _direction * _speed * Time.deltaTime;
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }
}
