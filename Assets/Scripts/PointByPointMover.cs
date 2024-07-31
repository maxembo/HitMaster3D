using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class PointByPointMover : IMover
    {
        private NavMeshAgent _agent;
        private Queue<Vector3> _targets;
        private Vector3 _currentTarget;

        private bool _isMoving;

        public PointByPointMover(NavMeshAgent agent, IEnumerable<Vector3> targets)
        {
            _agent = agent;
            _targets = new Queue<Vector3>(targets);

            SwitchTarget();
        }

        public void StartMove() => _isMoving = true;

        public void StopMove() => _isMoving = false;

        public void Update(float deltaTime)
        {
            if (!_isMoving) return;

            var direction = _currentTarget - _agent.transform.position;

            _agent.SetDestination(_currentTarget);

            if (direction.magnitude <= 0.5f) SwitchTarget();
        }

        private void SwitchTarget()
        {
            _targets.Enqueue(_currentTarget);
            _currentTarget = _targets.Dequeue();
            _isMoving = false;
        }
    }
}
