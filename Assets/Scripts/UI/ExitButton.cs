using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class ExitButton : MonoBehaviour
    {
        [SerializeField] private Button m_button;

        private void OnEnable()
        {
            m_button.onClick.AddListener(Exit);
        }

        private void OnDisable()
        {
            m_button.onClick.RemoveListener(Exit);
        }

        private void Exit()
        {
            Application.Quit();
        }
    }
}
