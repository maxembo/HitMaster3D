using Death;
using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField, Range(0, 1)] private float _radius;
        [SerializeField, Range(0, 20)] private float _speed;
        [SerializeField, Range(0, 100)] private int _damage;
        [SerializeField] private float _time;

        private Vector3 _direction;

        private void Start() => Destroy(gameObject, _time);

        private void Update() => transform.Translate(_direction.normalized * (_speed * Time.deltaTime));

        public void SetDirection(Vector3 bullet) => _direction = bullet - transform.position;

        private void OnTriggerEnter(Collider other)
        {
            var damageHits = Physics.OverlapSphere(transform.position, _radius);

            foreach (var hit in damageHits)
            {
                if (hit.TryGetComponent(out IDamageable damageable))
                    damageable.Apply(_damage);

                Destroy(gameObject);
            }
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            var position = transform.position;
            Gizmos.DrawWireSphere(position, _radius);
        }
#endif
    }
}
