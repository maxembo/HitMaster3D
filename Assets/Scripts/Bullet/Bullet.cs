using UnityEngine;

namespace Bullet
{

    public class Bullet : MonoBehaviour
    {
        [SerializeField, Range(0, 20)] private float _radius;
        [SerializeField, Range(0, 20)] private float _speed;
        [SerializeField] private float _time;

        private Vector3 _direction;

        private void Start() => Destroy(gameObject, _time);

        private void Update() => transform.Translate(_direction.normalized * (_speed * Time.deltaTime));

        public void SetDirection(Vector3 bullet) => _direction = bullet - transform.position;
    }
}
