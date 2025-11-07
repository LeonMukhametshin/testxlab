using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FreeCamera m_freeCamera;
    [SerializeField] private GameObject m_uiPanel;
    [SerializeField] private CloudController m_cloudController;

    private void Update()
    {
        if (m_uiPanel.activeSelf) return;
        m_freeCamera.Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_cloudController.MoveNext();
        }
    }
}