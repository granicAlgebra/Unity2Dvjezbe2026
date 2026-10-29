using UnityEngine;

public class PlatfornerGravityTest : MonoBehaviour
{
    private const float GRAVITY = -9.81f;

    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _jumpForce = 10f;
    [SerializeField] private float _groundLevel = 0f;


     
    private Vector3 _velovity = Vector3.zero;

    void Update()
    {
        _velovity.y += GRAVITY * Time.deltaTime;

        transform.position += _velovity * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _velovity.y = _jumpForce;
            Vector3 position = transform.position;
            position.y = _groundLevel;
            transform.position = position;
        }

        if (transform.position.y < _groundLevel)
        {
            Vector3 position = transform.position;
            position.y = _groundLevel;
            transform.position = position;
            _velovity.y = 0;
        }
    }
}
