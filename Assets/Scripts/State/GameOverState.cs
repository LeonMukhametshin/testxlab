using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class GameOverState : MonoBehaviour
    {
        [SerializeField] private GameObject m_gameOverPanel;

        [SerializeField] private Button m_backMainMenu;
        [SerializeField] private TextMeshProUGUI m_scoreText;

        private GameStateMachine m_gameStateMachine;


        public void Init(GameStateMachine gameStateMachine)
        {
            m_gameStateMachine = gameStateMachine;
        }

        public void Enter()
        {
            m_scoreText.text = ScoreManager.Instance.Score.ToString();
            m_backMainMenu.onClick.AddListener(OnClicked);
            m_gameOverPanel.SetActive(true);
        }

        private void OnClicked() => m_gameStateMachine.Enter<MainMenuState>();

        public void Exit()
        {
            m_gameOverPanel.SetActive(false);
        }
    }
}
