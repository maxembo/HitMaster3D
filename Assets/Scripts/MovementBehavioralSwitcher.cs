using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts
{
    public class MovementBehavioralSwitcher : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private List<Transform> _waypoints = new();

        private IMover _mover;

        private void Awake()
        {
            _mover = new PointByPointMover(_agent, _waypoints.Select(point => point.position));
            _character.SetMover(_mover);
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _mover.StartMove();
            }
        }
        //private void SetMover(MoverTypes moverType) => _character.SetMover(_strategyFactory.Get(moverType, _character));
    }
}
