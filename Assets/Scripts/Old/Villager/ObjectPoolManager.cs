using System.Collections.Generic;
using UnityEngine;

namespace Old
{
    public class ObjectPoolManager : MonoBehaviour
    {
        public static ObjectPoolManager Instance { get; private set; }

        [SerializeField] private GameObject[] m_itemPrefabs;
        [SerializeField] private int m_poolSize = 4;

        private Queue<GameObject> m_pool = new();

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }

            ValidatePrefabsArray();
            InitializePool();
        }

        private void ValidatePrefabsArray()
        {
            if (m_itemPrefabs is null || m_itemPrefabs.Length == 0)
            {
                Debug.LogWarning("Array is empty");
            }

            for (int i = 0; i < m_itemPrefabs.Length; i++)
            {
                if (m_itemPrefabs[i] is null)
                {
                    Debug.LogWarning($"Array element ¹{i} is null");
                }
            }
        }

        private void InitializePool()
        {
            for (int i = 0; i < m_poolSize; i++)
            {
                CreateNewObject();
            }
        }

        public GameObject GetObject(Vector3 position, Quaternion rotation)
        {
            if (m_pool.Count == 0)
            {
                CreateNewObject();
            }

            GameObject obj = m_pool.Dequeue();
            obj.transform.SetPositionAndRotation(position, rotation);
            obj.SetActive(true);

            return obj;
        }

        public void ReturnObject(GameObject obj)
        {
            obj.SetActive(false);
            m_pool.Enqueue(obj);
        }

        private void CreateNewObject()
        {
            GameObject obj = Instantiate(m_itemPrefabs[Random.Range(0, m_itemPrefabs.Length)]);
            obj.SetActive(false);
            m_pool.Enqueue(obj);
        }
    }
}