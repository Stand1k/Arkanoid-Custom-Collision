using UnityEngine;

namespace Arkanoid
{
    public static class CollisionUtils
    {
        public static float DistanceSq(Vector3 a, Vector3 rhs)
        {
            float dx = a.x - rhs.x;
            float dy = a.y - rhs.y;
            float dz = a.z - rhs.z;
            return dx * dx + dy * dy + dz * dz;
        }
        
        public static Vector3 ClosestPointTo(Vector3 point, Rectangle rectangle)
        {
            var center = rectangle.Center;

            var halfExtents = new Vector2(rectangle.Width / 2, rectangle.Height / 2);

            var directionVector = point - center;

            var xAxis = rectangle.Rotation * new Vector3(1, 0, 0);
            var yAxis = rectangle.Rotation * new Vector3(0, 1, 0);

            var distanceX = Vector3.Dot(directionVector, xAxis);
            if (distanceX > halfExtents.x) distanceX = halfExtents.x;
            else if (distanceX < -halfExtents.x) distanceX = -halfExtents.x;

            var distanceY = Vector3.Dot(directionVector, yAxis);
            if (distanceY > halfExtents.y) distanceY = halfExtents.y;
            else if (distanceY < -halfExtents.y) distanceY = -halfExtents.y;

            return center + distanceX * xAxis + distanceY * yAxis;
        }
        
        public static Vector3 BounceDirection(this Vector3 direction, Transform transform)
        {
            float normalAngle = (transform.eulerAngles.z + 90f) * Mathf.Deg2Rad;
            Vector3 normalDir = new Vector3(Mathf.Cos(normalAngle), Mathf.Sin(normalAngle), 0);
            

           return Vector3.Reflect(direction, normalDir);
        }
        
        public static Vector3 BounceDirection(this Vector3 direction, float angle)
        {
            float normalAngle = angle * Mathf.Deg2Rad;
            Vector3 normalDir = new Vector3(Mathf.Cos(normalAngle), Mathf.Sin(normalAngle), 0);
            
            return Vector3.Reflect(direction, normalDir);
        }
        
        public static float GetCollisionAngle(Vector3 closePoint, Vector3 center)
        {
            var distance = closePoint - center;
            return Vector2.Angle(Vector2.right, distance);
        }
    }
}