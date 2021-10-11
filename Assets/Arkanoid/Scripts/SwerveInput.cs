using System;
using UnityEngine;

namespace Arkanoid
{
    public class SwerveInput : MonoBehaviour, ISwerveInput
    {
        private float _lastFrameFingerPositionX;
        private float _moveFactorX;

        [SerializeField] private float swerveSpeed = 3f;
        [SerializeField] private float maxSwerveAmount = 3f;

        public float SwerveAmount => Time.deltaTime * swerveSpeed * _moveFactorX;

        private void Start()
        {
#if UNITY_EDITOR
            swerveSpeed *= 2;
            maxSwerveAmount *= 2;
#endif
        }

        public void InputHandler()
        {
            
#if UNITY_EDITOR || UNITY_STANDALONE_WIN
            if (Input.GetMouseButtonDown(0))
            {
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButton(0))
            {
                _moveFactorX = Input.mousePosition.x - _lastFrameFingerPositionX;
                _lastFrameFingerPositionX = Input.mousePosition.x;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                _moveFactorX = 0f;
            }

#elif UNITY_ANDROID && !UNITY_EDITOR
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _lastFrameFingerPositionX = touch.position.x;
                        break;
                    case TouchPhase.Moved:
                        _moveFactorX = touch.position.x - _lastFrameFingerPositionX;
                        _lastFrameFingerPositionX = touch.position.x;
                        break;
                    case TouchPhase.Ended:
                        _moveFactorX = 0f;
                        break;
                }
            }
#endif
        }

        public float GetNextXPosition()
        {
            return Mathf.Clamp(SwerveAmount, -maxSwerveAmount, maxSwerveAmount);
        }

        void LateUpdate()
        {
            InputHandler();
        }
    }
}