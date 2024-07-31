namespace Assets.Scripts
{
    public interface IMover
    {
        public void StartMove();

        public void StopMove();

        public void Update(float deltaTime);
    }
}
