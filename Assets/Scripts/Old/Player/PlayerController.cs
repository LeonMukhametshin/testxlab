using Old;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private FreeCamera m_freeCamera;
    [SerializeField] private GameObject m_uiPanel;
    [SerializeField] private CloudController m_cloudController;

    [SerializeField] private List<VillagerController> m_villagerControllers;

    private void Update()
    {
        //if (m_uiPanel.activeSelf) return;
        m_freeCamera.Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            m_cloudController.MoveNext();
        }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            m_villagerControllers.ForEach(villager => villager.SwitchItem());
        }
    }
}