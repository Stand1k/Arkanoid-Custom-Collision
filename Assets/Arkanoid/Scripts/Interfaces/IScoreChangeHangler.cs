namespace Arkanoid
{
    public interface IScoreChangeHangler : IGlobalSubscriber

    {
    public void SetScore(int value);
    }
}