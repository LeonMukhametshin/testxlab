using System;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class HealthUI : MonoBehaviour
    {
        public event Action<int> ChangedHealth;

        [SerializeField] private GameObject m_healtGameObject;
        [SerializeField] private Sprite m_healthSprite;
        [SerializeField] private float m_distance;

        private void OnEnable()
        {
            ChangedHealth += DrawHealthPoint;
        }

        private void OnDisable()
        {
            ChangedHealth -= DrawHealthPoint;
        }

        private void CreateImages(int count)
        {
            var parentRect = GetComponent<RectTransform>();

            for (int i = 0; i < count; i++)
            { 
                var sprite = Instantiate(m_healtGameObject, transform);

                var spriteRect = sprite.GetComponent<RectTransform>();

                spriteRect.anchoredPosition = new Vector3(i * m_distance, 0, 0);
                spriteRect.localScale = Vector3.one;
                spriteRect.localRotation = Quaternion.identity;

                if (sprite.TryGetComponent<Image>(out var image))
                {
                    image.sprite = m_healthSprite;
                }
            }
        }

        public void DrawHealthPoint(int currentHealthPoint)
        {
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            CreateImages(currentHealthPoint);
        }
    }
}
