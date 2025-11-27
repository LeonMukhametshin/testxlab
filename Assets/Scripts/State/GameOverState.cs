using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class GameOverState : StateBase
    {
        [SerializeField] private GameObject m_gameOverPanel;

        [SerializeField] private Button m_backMainMenu;
        [SerializeField] private TextMeshProUGUI m_scoreText;

        private GameStateMachine m_gameStateMachine;

        public override void Initialize(GameStateMachine gameStateMachine)
        {
            m_gameStateMachine = gameStateMachine;
            m_gameOverPanel.SetActive(false);
        }

        public override void Enter()
        {
            m_scoreText.text = "Score: " + ScoreManager.Instance.Score.ToString();

            ScoreManager.Instance.UpdateRecord();

            m_backMainMenu.onClick.AddListener(OnClicked);
            m_gameOverPanel.SetActive(true);
        }

        public override void Exit()
        {
            m_gameOverPanel.SetActive(false);
            m_backMainMenu?.onClick.RemoveListener(OnClicked);
        }

        private void OnClicked() => m_gameStateMachine.Enter<MainMenuState>();
    }
}
