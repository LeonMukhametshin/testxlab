using System;
using UnityEditor.Analytics;
using UnityEngine;

namespace Golf
{
    public class GamePlayState : StateBase
    {
        [SerializeField] private GameObject m_gameplayPanel;

        [SerializeField] private Transform m_transform;
        [SerializeField] private GameObject m_glassWall;

        [SerializeField] private PlayerController m_playerController;
        [SerializeField] private LevelController m_levelController;
        [SerializeField] private GameScoreText m_gameScoreText;

        private GameStateMachine m_gameStateMachine;
        private GameObject m_glassWallGameObject;

        public override void Initialize(GameStateMachine gameStateMachine)
        {
            m_gameStateMachine = gameStateMachine;
            m_gameplayPanel.gameObject.SetActive(false);
        }

        public override void Enter()
        {
            ScoreManager.Instance.Reset();

            m_glassWallGameObject = Instantiate(m_glassWall, m_transform.position, m_transform.rotation);

            m_levelController.enabled = true;
            m_playerController.enabled = true;
            m_gameplayPanel.gameObject.SetActive(true);

            m_levelController.Finished += OnFinished;
            m_levelController.Reset();
        }

        public override void Exit()
        {
            m_levelController.enabled = false;
            m_playerController.enabled = false;
            m_gameplayPanel.gameObject.SetActive(false);

            m_levelController.Finished -= OnFinished;

            Destroy(m_glassWallGameObject);
        }

        private void OnFinished()
            => m_gameStateMachine.Enter<GameOverState>();
    }
}