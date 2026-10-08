using UnityEngine;

public class Test : MonoBehaviour
{
    private const float GRAVITY = 9.91f;

    [Header("Tralalala")]
    public string TestUpdate = "Update";
    private int _testInt = 1;

    [SerializeField] private float _rotationSpeed = 1.0f;

  
    private void Awake()
    {
        Debug.Log("Awake!");
        new Class2();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Debug.Log("Hello world!");
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, _rotationSpeed * Time.deltaTime));
    }

    private void OnDestroy()
    {
        Debug.Log("Destroyed!");
    }
}

public class Class2 { }