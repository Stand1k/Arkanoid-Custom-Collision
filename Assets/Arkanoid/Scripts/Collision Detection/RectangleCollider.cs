using UnityEngine;

namespace Arkanoid
{
    public class RectangleCollider : BaseCollider
    {
        public Rectangle Rectangle => _rectangle;

        private Rectangle _rectangle;

        private void Awake()
        {
            _rectangle = new Rectangle(transform);
        }

        public override bool Intersects(RectangleCollider rectangleCollider)
        {
            var rectangle = rectangleCollider.Rectangle;

            if (_rectangle.Right < rectangle.Left || _rectangle.Left > rectangle.Right) return Collide = false;
            if (_rectangle.Top < rectangle.Bottom || _rectangle.Bottom > rectangle.Top) return Collide = false;

            return true;
        }

        public override bool Intersects(CircleCollider circleCollider)
        {
            var circle = circleCollider.Circle;
            var circlePos = new Vector3(circle.X, circle.Y, 0f);

            Vector3 closePoint = CollisionUtils.ClosestPointTo(circlePos, _rectangle);

            bool intersect = CollisionUtils.DistanceSq(closePoint, circlePos) <= circle.Radius * circle.Radius;

            if (intersect) Angle = CollisionUtils.GetCollisionAngle(closePoint, circlePos);

            return intersect;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            var r = GetComponent<Renderer>();
            Gizmos.DrawWireCube(transform.position, r.bounds.size);
        }

        public override void UpdateCollider()
        {
            _rectangle.UpdateData(transform);
        }
    }
}