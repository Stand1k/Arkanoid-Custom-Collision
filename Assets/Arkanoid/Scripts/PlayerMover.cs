using UnityEngine;
using Zenject;

namespace Arkanoid
{
    public class PlayerMover : MonoBehaviour, IGameWonHandle, IGameOverHandle
    {
        private ISwerveInput _swerveInput;

        [SerializeField] private Vector2 moveBounds =  new Vector2(-7f,7f);

        private void Awake()
        {
            EventBus.Subscribe(this);
        }

        [Inject]
        void Construct(ISwerveInput swerveInput)
        {
            _swerveInput = swerveInput;
        }

        private void Update()
        {
            var xPosition = _swerveInput.GetNextXPosition();
            var position = transform.position;
            var nextXPosition = position.x + xPosition;

            position = new Vector2(
                Mathf.Clamp(
                nextXPosition, 
                moveBounds.x, 
                moveBounds.y),
                position.y
                );
            transform.position = position;
        }

        public void GameWon()
        {
            enabled = false;
        }

        public void GameOver()
        {
            enabled = false;
        }
    }
}