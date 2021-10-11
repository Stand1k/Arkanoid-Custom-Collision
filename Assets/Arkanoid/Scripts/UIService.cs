using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class UIService : MonoBehaviour, IGameWonHandle, IGameOverHandle, IScoreChangeHangler
    {
        [SerializeField] private Canvas gameOverCanvas;
        [SerializeField] private CanvasGroup blurBackground;    
        [SerializeField] private Button nextReloadButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private TMP_Text scoreText;

        private int _currentScore;

        private void Awake()
        {
            EventBus.Subscribe(this);
        }

        public void SetScore(int value)
        {
            _currentScore += value;
            scoreText.text = "Score: " + _currentScore;
        }

        public void GameWon()
        {
            nextReloadButton.GetComponentInChildren<TMP_Text>().text = "Next";
            GameOverMenu();
        }
        
        public void GameOver()
        {
            nextReloadButton.GetComponentInChildren<TMP_Text>().text = "Again";
            GameOverMenu();
        }
        
        private void GameOverMenu()
        {   
            gameOverCanvas.enabled = true;
            exitButton.onClick.AddListener(() => Application.Quit());
            nextReloadButton.onClick.AddListener(() => SceneLoader.Instance.LoadNextScene());
            blurBackground.DOFade(1f, 1f);
            nextReloadButton.transform.DOLocalMoveX(0f, 1f);
            exitButton.transform.DOLocalMoveX(0f, 1f);
        }
        
        private void OnDestroy()
        {
            EventBus.Unsubscribe(this);
        }
    }
}