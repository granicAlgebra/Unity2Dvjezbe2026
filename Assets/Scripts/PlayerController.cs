using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _running = 1f;
    [SerializeField] private float _sprint = 1f;

    [Header("Dash")]
    [SerializeField] private float _dashSpeed = 20f;
    [SerializeField] private float _dashDuration = 0.15f;
    [SerializeField] private float _dashCooldown = 2f;

    [SerializeField] private Vector2 _bounds;

    private float _dashLeft = 0f;
    private float _cooldownLeft = 0f;
    private Vector3 _dashDirection;

    private float _currentSpeed = 0f;

    private void Start()
    {
        _bounds.y = Camera.main.orthographicSize;
        _bounds.x = _bounds.y * Camera.main.aspect;
    }

    void Update()
    {
        _bounds.y = Camera.main.orthographicSize;
        _bounds.x = _bounds.y * Camera.main.aspect;

        _currentSpeed = RunOrSprint();
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Move(new Vector3(horizontal, vertical, 0).normalized);
        BorderLimit();
    }

    private void BorderLimit()
    {
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, -_bounds.x, _bounds.x);
        position.y = Mathf.Clamp(position.y, -_bounds.y, _bounds.y);

        transform.position = position;
    }

    private float RunOrSprint()
    {
        float speed = 0;
        if (Input.GetKey(KeyCode.LeftShift))
            speed = _sprint;
        else
            speed = _running;
        return speed;
    }

    private void Move(Vector3 direction)
    {
        _cooldownLeft -= Time.deltaTime;
        if (_cooldownLeft > 0f)
        {
            Debug.Log($"Dash cool down left {_cooldownLeft}");
        }

        bool dashReady = _cooldownLeft <= 0f && direction != Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space) && dashReady)
        {
            _dashLeft = _dashDuration;
            _cooldownLeft = _dashCooldown;
            _dashDirection = direction;
        }
       
        if (_dashLeft > 0f)
        {
            _dashLeft -= Time.deltaTime;
            transform.position += _dashDirection * _dashSpeed * Time.deltaTime;
        }
        else
        {
            transform.position += direction * _currentSpeed * Time.deltaTime;
        }
    }
}
