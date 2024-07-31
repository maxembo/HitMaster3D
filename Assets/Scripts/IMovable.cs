using UnityEngine;

namespace Assets.Scripts
{
    public interface IMovable
    {
        public Vector3 Position { get; }
        public float Speed { get; }
    }
}
