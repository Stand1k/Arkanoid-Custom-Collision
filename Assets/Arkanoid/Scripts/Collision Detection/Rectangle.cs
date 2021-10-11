using UnityEngine;

namespace Arkanoid
{
    public class Rectangle 
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        
        public float Top => Y + (Height / 2);
        public float Bottom => Y - (Height / 2);
        public float Right => X + (Width / 2);
        public float Left => X - (Width / 2);
        
        public float Width { get; private set; }
        public float Height { get; private set; }
        
        public Vector3 Center => new Vector3(X, Y, 0);
        
        public Quaternion Rotation { get; set; }

        public Rectangle(Transform transform)
        {
            X = transform.position.x;
            Y = transform.position.y;
            Width = transform.localScale.x;
            Height = transform.lossyScale.y;
            Rotation = transform.rotation;
        }

        public void UpdateData(Transform transform)
        {
            X = transform.position.x;
            Y = transform.position.y;
            Width = transform.localScale.x;
            Height = transform.lossyScale.y;
            Rotation = transform.rotation;
        }
        
        public override string ToString()
        {
            return "X: " + X + " Y: " + Y + " Width: " +  Width + " Height: " + Height + " Rotation: " + Rotation.eulerAngles;
        }
    }
}