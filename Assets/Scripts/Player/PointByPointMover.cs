using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Player
{
    public class PointByPointMover : IMover
    {
        private NavMeshAgent _agent;
        private View _view;
        private Queue<Vector3> _targets;
        private Vector3 _currentTarget;

        private bool _isMoving;

        public PointByPointMover(NavMeshAgent agent, View view, IEnumerable<Vector3> targets)
        {
            _agent = agent;
            _view = view;
            _targets = new Queue<Vector3>(targets);

            SwitchTarget();
        }

        public void StartMove()
        {
            _isMoving = true;
            _view.StartWalk();
        }

        public void StopMove()
        {
            _isMoving = false;
            _view.StartIdle();
        }

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
            StopMove();
        }
    }
}
