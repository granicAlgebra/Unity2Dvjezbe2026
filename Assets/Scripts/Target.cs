using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Vector2 _positionA;
    [SerializeField] private Vector2 _positionB;
    [SerializeField] private float _speed;
   
    void Update()
    {
        float t = Mathf.PingPong(Time.time * _speed, 1.0f);

        Vector2 newPosition = Vector2.Lerp(_positionA, _positionB, t);

        transform.position = new Vector3(newPosition.x, newPosition.y);
    }

    private void OnDrawGizmos()
    {
        Color color = Color.yellow;

        Gizmos.color = color;
        Gizmos.DrawWireCube(new Vector3(_positionA.x, _positionA.y), Vector3.one * 0.1f);
        Gizmos.DrawWireCube(new Vector3(_positionB.x, _positionB.y), Vector3.one * 0.1f);
    }
}
