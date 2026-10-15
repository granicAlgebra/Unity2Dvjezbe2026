using Unity.VisualScripting;
using UnityEngine;

public class Vjezbe3 : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _sprint = 1f;

    [SerializeField] private Vector2 _bounds;

    private void Start()
    {
        _bounds.y = Camera.main.orthographicSize;
        _bounds.x = _bounds.y * Camera.main.aspect;
    }

    void Update()
    {
        _bounds.y = Camera.main.orthographicSize;
        _bounds.x = _bounds.y * Camera.main.aspect;

        float sprintSpeed = Sprint();
        Move(_speed + sprintSpeed);
        BorderLimit();
    }

    private void BorderLimit()
    {
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, -_bounds.x, _bounds.x);
        position.y = Mathf.Clamp(position.y, -_bounds.y, _bounds.y);

        transform.position = position;
    }

    private float Sprint()
    {
        float sprint = 0;
        if (Input.GetKey(KeyCode.LeftShift))
            sprint = _sprint;
        return sprint;
    }

    private void Move(float speed)
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.position += new Vector3(horizontal, vertical, 0) * speed * Time.deltaTime;
    }
}
