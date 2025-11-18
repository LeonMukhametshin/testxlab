using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class GameScoreText : MonoBehaviour
    {
        [SerializeField] private Text m_scoreText;

        private void OnEnable()
        {
            ScoreManager.Instance.ScoreChanged += UpdateScoreText;
        }

        private void OnDisable()
        {
            ScoreManager.Instance.ScoreChanged -= UpdateScoreText;
        }

        private void UpdateScoreText(int score)
        {
            m_scoreText.text = score.ToString();
        }
    }
}