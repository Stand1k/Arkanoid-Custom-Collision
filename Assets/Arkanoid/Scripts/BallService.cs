using UnityEngine;
using Random = UnityEngine.Random;

namespace Arkanoid
{
    public class BallService : MonoBehaviour, IGameWonHandle
    {
        [SerializeField] private Vector3 direction;
        [SerializeField] private float flySpeed;

        private bool _isGameActive;
        private Transform _transform;

        private void Awake()
        {
            EventBus.Subscribe(this);
        }

        private void Start()
        {
            _transform = transform;

            var collisionDetection = GetComponent<CollisionDetector<CircleCollider>>();
            collisionDetection.CollisionAction += CollisionEnter;
        }

        private void Update()
        {
            if (Mathf.Abs(_transform.position.x) > 9 || Mathf.Abs(_transform.position.y) > 5 && _isGameActive)
            {
                _isGameActive = false;
                Destroy(gameObject);
                EventBus.RaiseEvent<IGameOverHandle>(h => h.GameOver());
            }

            if (_isGameActive)
            {
                _transform.Translate(direction * flySpeed * Time.deltaTime, Space.Self);
            }
        }

        private void LateUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _isGameActive = true;
            }
        }

        private void CollisionEnter(BaseCollider collision)
        {
            if (collision.CompareTag("Player"))
            {
                direction = direction.BounceDirection(collision.Angle);
                
                direction.x = Mathf.Clamp(
                    -(collision.transform.position.x - _transform.position.x),
                    -1f,
                    1f
                );

                return;
            }

            if (collision.CompareTag("Brick"))
            {
                direction = direction.BounceDirection(collision.Angle);
                
                var position = collision.transform.position;
                var checkGameWon = BrickService.Instance.RemoveAndCheckGameWon(collision.gameObject);
                Destroy(collision.gameObject);
                PoolService.GetObject(
                        "BrickDestroyVFX",
                        position,
                        Quaternion.identity)
                    .GetComponent<ParticleSystem>()
                    .Play();

                EventBus.RaiseEvent<IScoreChangeHangler>(h => h.SetScore(1));
                
                if (checkGameWon)
                {
                    EventBus.RaiseEvent<IGameWonHandle>(h => h.GameWon());
                }
                
                return;
            }

            if (collision.CompareTag("Wall"))
            {
                direction = direction.BounceDirection(collision.transform);
                var newColor = new Color(Random.Range(0, 1f), Random.Range(0, 1f), Random.Range(0, 1f));
                collision.GetComponent<SpriteRenderer>().color = newColor;
                
                return;
            }
        }

        public void GameWon()
        {
            GetComponent<CircleCollisionDetector>().enabled = false;
            enabled = false;
            
            if (PlayPrefsUtils.Instance.GetCurrentLvl() >= 5) return;
            
            PlayPrefsUtils.Instance.SetNextLvl(); 
        }
    }
}   