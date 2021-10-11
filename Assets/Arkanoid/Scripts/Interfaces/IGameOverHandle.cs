namespace Arkanoid
{
    public interface IGameOverHandle : IGlobalSubscriber
    {
        public void GameOver();
    }
}