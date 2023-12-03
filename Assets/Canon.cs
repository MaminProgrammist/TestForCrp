using UnityEngine;

public class Canon : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    [SerializeField] private Projectile _projectilePrefab;
    [SerializeField] private float _launchForce;
    [SerializeField] private float _fireRepeatTime = 1.0f;

    private void Awake()
    {
        InvokeRepeating(nameof(SpawnProjectile), 0, _fireRepeatTime);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        Projectile projectile = Instantiate(_projectilePrefab, _firePoint.position, transform.rotation);
        projectile.SetForce(_launchForce);
        projectile.Launch();
    }
}
