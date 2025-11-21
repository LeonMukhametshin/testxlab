using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Golf
{
    [RequireComponent(typeof(Rigidbody))]
    public class Stone : MonoBehaviour
    {
        public event Action<Stone> Hit;
        public event Action<Stone> Missed;

        [SerializeField] private StoneData[] m_data;

        private Rigidbody m_rigidbody;
        private StoneData m_currentData;

        public int Score { get; private set; }

        private void Awake()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            Score = m_data[Random.Range(0, m_data.Length)].Score;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.GetComponent<Stick>())
            {
                Hit?.Invoke(this);
            }
            else
            {
                Missed?.Invoke(this);
            }
        }

        public void AddForce(Vector3 power) =>
            m_rigidbody.AddForce(power, ForceMode.Force);
    }
}
