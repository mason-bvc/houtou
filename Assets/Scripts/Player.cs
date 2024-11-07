using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _velocity;
    private Vector3 _moveAxis;
    private Vector3 _mousePos;
    private Transform _aimTransform;
    private Transform _bulletSpawnTransform;
    private float _shootTimer;

    [SerializeField]
    private PlayerBullet _bulletPrefab;

    [SerializeField]
    public float Speed = 25.0F;

    [SerializeField]
    public float DecelerationRate = 5.0F;

    [SerializeField]
    public float ShootCooldownSeconds = 0.05F;

    public void Start()
    {
        _aimTransform = transform.Find("AimTransform");
        _bulletSpawnTransform = _aimTransform?.Find("BulletSpawnTransform");
    }

    public void Update()
    {
        _moveAxis = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0).normalized;
        _mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        _mousePos.z = 0;
        _aimTransform.LookAt(_mousePos);

        if (_shootTimer <= 0.0F)
        {
            if (Input.GetButton("Fire1"))
            {
                PlayerBullet bullet = Instantiate(_bulletPrefab);

                bullet.transform.position = _bulletSpawnTransform.position;
                bullet.Direction = _bulletSpawnTransform.forward;
            }

            _shootTimer = ShootCooldownSeconds;
        }

        _shootTimer -= Time.deltaTime;
    }

    public void FixedUpdate()
    {
        _velocity += _moveAxis * Speed * Time.fixedDeltaTime;
        transform.position += _velocity;

        float t = DecelerationRate * Time.fixedDeltaTime;

        _velocity = new(Mathf.Lerp(_velocity.x, 0, t), Mathf.Lerp(_velocity.y, 0, t), Mathf.Lerp(_velocity.z, 0, t));
    }
}
