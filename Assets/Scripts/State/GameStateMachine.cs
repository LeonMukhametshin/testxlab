using UnityEngine;

namespace Golf
{
    public class GameStateMachine : MonoBehaviour
    {
        [SerializeField] private MainMenuState m_mainMenuState;
        [SerializeField] private GamePlayState m_gamePlayState;
        [SerializeField] private BootstrapState m_boorstrapState;
        [SerializeField] private GameOverState m_gameOverState;

        private void Awake()
        {
            m_mainMenuState.Init(this);
            m_gamePlayState.Init(this);
            m_boorstrapState.Init(this);
        }

        private void Start() => Enter<BootstrapState>();

        public void Enter<T>()
        {
            if(typeof(T) == typeof(MainMenuState))
            {
                m_gameOverState.Exit();
                m_gamePlayState.Exit();

                m_mainMenuState.Enter();
            }
            else if (typeof(T) == typeof(GamePlayState))
            {
                m_mainMenuState.Exit();
                m_gamePlayState.Enter();
            }
            else if(typeof(T) == typeof(BootstrapState))
            {
                m_boorstrapState.Enter();
            }
            else if (typeof(T) == typeof(GameOverState))
            {
                m_gamePlayState.Enter();
            }
        }
    }
}
