namespace Arkanoid
{
    public interface IGameWonHandle : IGlobalSubscriber
    {
        public void GameWon();
    }
}