using Player;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private List<Transform> _waypoints = new();
        [SerializeField] private View _view;

        private const string PlayerTag = "Player";
        private const string Scene = "Gameplay";

        private IMover _mover;

        private void Start()
        {
            _mover = new PointByPointMover(_agent, _view, _waypoints.Select(point => point.position));
            _character?.SetMover(_mover);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(PlayerTag)) return;

            SceneManager.LoadScene(Scene);
        }
    }
}
