using UnityEngine;

namespace Player
{
    public class View : MonoBehaviour
    {
        private const string State = "state";
        private const int Idle = 0;
        private const int Walk = 1;

        private Animator _animator;

        private void Awake() => _animator = GetComponent<Animator>();

        public void StartIdle() => _animator.SetFloat(State, Idle);
        public void StartWalk() => _animator.SetFloat(State, Walk);
    }
}
