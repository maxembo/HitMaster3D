using Death;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class Character : MonoBehaviour
    {
        [SerializeField, Range(0, 5)] private float _radius;
        [SerializeField] private Transform _transform;

        private IMover _mover;
        private NavMeshAgent _agent;


        public Vector3 Position => _agent.transform.position;

        public float Speed => _agent.speed;

        private void Awake() => _agent = GetComponent<NavMeshAgent>();

        private void Update()
        {
            _mover?.Update(Time.deltaTime);
            DetectEnemies();
        }

        private void DetectEnemies()
        {
            var hits = Physics.OverlapSphere(_transform.position, _radius);

            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out IDamageable damageable))
                    return;
            }

            _mover?.StartMove();
        }

        public void SetMover(IMover mover)
        {
            _mover?.StopMove();
            _mover = mover;
            _mover.StartMove();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            var position = _transform.position;

            if (position != null)
                Gizmos.DrawWireSphere(position, _radius);
        }
#endif
    }
}
