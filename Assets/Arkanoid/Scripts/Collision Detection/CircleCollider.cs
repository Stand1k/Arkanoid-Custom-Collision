using UnityEngine;

namespace Arkanoid
{
    public class CircleCollider : BaseCollider
    {
        
        public Circle Circle => _circle;
        
        private Circle _circle;

        private void Awake()
        {
            _circle = new Circle(transform);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            var r = GetComponent<Renderer>();
            Gizmos.DrawWireSphere(transform.position, r.bounds.extents.x);
        }

        public override bool Intersects(CircleCollider circleCollider)
        {
            var circle = circleCollider.Circle;
            var centre0 = new Vector2(circle.X, circle.Y);
            var centre1 = new Vector2(_circle.X, _circle.Y);
            return Vector2.Distance(centre0, centre1) < _circle.Radius + circle.Radius;
        }

        public override bool Intersects(RectangleCollider rectangleCollider)
        {
            var rectangle = rectangleCollider.Rectangle;
            
            Vector3 closePoint = CollisionUtils.ClosestPointTo(_circle.Center,rectangle);
            
            bool intersect = CollisionUtils.DistanceSq(closePoint, _circle.Center) <= _circle.Radius * _circle.Radius;

            if (intersect) Angle = CollisionUtils.GetCollisionAngle(closePoint, rectangle.Center);

            return intersect;
        }

        public override void UpdateCollider()
        {
            _circle.UpdateData(transform);
        }
    }
}