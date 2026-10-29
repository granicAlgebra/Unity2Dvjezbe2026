using UnityEngine;

public class Attacker : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _target;

    private SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Stisnuli smo slovo C");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
            _spriteRenderer.color = Color.red;
            Debug.Log("Meta je na " + _target.position);
        }
    }
}