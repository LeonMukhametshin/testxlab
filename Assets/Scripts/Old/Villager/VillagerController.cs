using UnityEngine;

namespace Old
{
    public class VillagerController : MonoBehaviour
    {
        private Transform m_spawnPoint;
        private GameObject m_currentItem;

        private void Awake()
        {
            m_spawnPoint = GetComponent<Transform>();
        }

        public void SwitchItem()
        {
            if (m_currentItem is not null)
            {
                m_currentItem.SetActive(false);
                ObjectPoolManager.Instance.ReturnObject(m_currentItem);
                m_currentItem = null;
            }

            m_currentItem = ObjectPoolManager.Instance.GetObject(
                m_spawnPoint.position,
                m_spawnPoint.rotation
            );

            m_currentItem.transform.SetParent(m_spawnPoint.transform);
        }
    }
}