using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Vector2 _positionA;
    [SerializeField] private Vector2 _positionB;

    [SerializeField] private int _spwanAmount;
    [SerializeField] private GameObject _prefab;

    void Start()
    {
        for (int i = 0; i < _spwanAmount; i++)
        {
            Vector2 spawnPosition = new Vector2(Random.Range(_positionA.x, _positionB.x), Random.Range(_positionA.y, _positionB.y));
            Instantiate(_prefab, spawnPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Color color = Color.red;

        Gizmos.color = color;

        float minX = Mathf.Min(_positionA.x, _positionB.x);
        float maxX = Mathf.Max(_positionA.x, _positionB.x);
        float minY = Mathf.Min(_positionA.y, _positionB.y);
        float maxY = Mathf.Max(_positionA.y, _positionB.y);

        Vector3 center = (new Vector3(_positionB.x, _positionB.y) + new Vector3(_positionA.x, _positionA.y)) / 2;
        Vector3 size = new Vector3(maxX - minX, maxY - minY);
        Gizmos.DrawWireCube(center, size);
    }
}
