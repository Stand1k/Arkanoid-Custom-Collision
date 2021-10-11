namespace Arkanoid
{
    public interface IColliderDestroy : IGlobalSubscriber
    {
        void ColliderDestroy(BaseCollider collider);
    }
}