using System;
using System.Collections;
using UnityEngine;

namespace Weapon
{
    public class Gun : MonoBehaviour
    {
        [SerializeField] private Bullet.Bullet _bulletPrefab;
        [SerializeField] private Transform _spawnPoint;
        [SerializeField, Range(0, 10)] private float _shootingDelay;

        private const float DistanceFromCamera = 12.0f;

        private PlayerInput _input;
        private Camera _camera;

        private void Awake() => _input = new PlayerInput();

        private bool _canShoot;

        private void Start()
        {
            _canShoot = true;
            _camera = Camera.main;
        }

        private void Shoot()
        {
            if (!_canShoot) return;

            InitializeBullet();

            StartCoroutine(Delay());
        }
        private void InitializeBullet()
        {
            Vector3 targetPoint = GetWorldPointFromScreenPoint(Input.mousePosition);

            var bullet = Instantiate(_bulletPrefab, _spawnPoint.position, Quaternion.identity);
            bullet.GetComponent<Bullet.Bullet>()?.SetDirection(targetPoint);
        }

        private Vector3 GetWorldPointFromScreenPoint(Vector3 screehPosition)
        {
            screehPosition.z = DistanceFromCamera;
            return Camera.main.ScreenToWorldPoint(screehPosition);
        }

        private IEnumerator Delay()
        {
            _canShoot = false;
            yield return new WaitForSeconds(_shootingDelay);
            _canShoot = true;
        }

        private void OnEnable()
        {
            _input.Enable();
            _input.Gameplay.Shoot.performed += _ => Shoot();
        }

        private void OnDisable()
        {
            _input.Gameplay.Shoot.performed -= _ => Shoot();
            _input.Disable();
        }
    }
}
