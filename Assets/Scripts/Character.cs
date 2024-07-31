using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class Character : MonoBehaviour, IMovable
    {
        private IMover _mover;
        private NavMeshAgent _agent;

        public Vector3 Position => _agent.transform.position;

        public float Speed => _agent.speed;

        private void Awake() => _agent = GetComponent<NavMeshAgent>();

        private void Update() => _mover?.Update(Time.deltaTime);

        public void SetMover(IMover mover)
        {
            _mover?.StopMove();
            _mover = mover;
            _mover.StartMove();
        }
    }
}
