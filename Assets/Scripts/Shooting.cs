using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject _projectilePrefab;
    [SerializeField] private Transform _target;
       

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            FireProjectile();
    }

    private void FireProjectile()
    {
        Vector3 direction = _target.position - transform.position;
        GameObject projectile  = Instantiate(_projectilePrefab, transform.position, Quaternion.identity);
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        projectileScript.SetDirection(direction);
    }
}
