using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    //[SerializeField] private Transform _target;

    private Camera _camera;
    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            FireProjectile();
    }

    private void FireProjectile()
    {
        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouseWorld = _camera.ScreenToWorldPoint(mouseScreen);
        mouseWorld.z = 0;

        Vector3 direction = mouseWorld - transform.position;
        GameObject projectile  = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.SetDirection(direction);
    }
}
