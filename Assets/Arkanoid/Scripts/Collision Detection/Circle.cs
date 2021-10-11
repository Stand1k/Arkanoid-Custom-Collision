using UnityEngine;

namespace Arkanoid
{
    public struct Circle
    {
        public float Radius { get; private set; }

        public float X { get; private set; }
        public float Y { get; private set; }
        
        public Vector3 Center => new Vector3(X, Y, 0);

        public Circle(Transform transform)
        {
            Radius = transform.localScale.x / 2;
            X = transform.position.x;
            Y = transform.position.y;
        }

        public void UpdateData(Transform transform)
        {
            Radius = transform.localScale.x / 2;
            X = transform.position.x;
            Y = transform.position.y;
        }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y + " Radius: " +  Radius;
        }
    }
}