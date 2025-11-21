using System;
using UnityEngine;

namespace Golf
{
    public class GamePlayState : MonoBehaviour
    {
        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private GameScoreText m_gameScoreText;

        private GameStateMachine m_gameStateMachine;

        public void Init(GameStateMachine gameStateMachine)
        {
            m_gameStateMachine = gameStateMachine; 
            m_gameScoreText.gameObject.SetActive(false);
        }

        public void Enter()
        {
            ScoreManager.Instance.Reset();

            m_levelController.enabled = true;
            m_playerController.enabled = true;
            m_gameScoreText.gameObject.SetActive(true);

            m_levelController.Finished += OnFinished;
        }

        public void Exit()
        {
            m_levelController.enabled = false;
            m_playerController.enabled = false;
            m_gameScoreText.gameObject.SetActive(false);

            m_levelController.Finished -= OnFinished;
        }

        private void OnFinished()
            => m_gameStateMachine.Enter<GameOverState>();
    }
}