using UnityEngine;

namespace Golf
{
    public class Stick : MonoBehaviour
    {
        [SerializeField, Min(0)] private float m_power;
        [SerializeField] private Transform m_point;

        [SerializeField] private float m_minAngelX;
        [SerializeField] private float m_maxAngelX;
        [SerializeField, Min(0)] private float m_speed;

        private Vector3 m_direction;
        private Vector3 m_lastPointPosition;

        private void FixedUpdate()
        {
            var angels = transform.localEulerAngles;

            if(Input.GetKey(KeyCode.RightArrow))
            {
                angels.x = Rotate(angels.x, m_minAngelX);
            }
            else
            {
                angels.x = Rotate(angels.x, m_maxAngelX);
            }

            transform.localEulerAngles = angels;

            m_direction = (m_point.position - m_lastPointPosition).normalized;
            m_lastPointPosition = m_point.position;
        }

        private float Rotate(float angelX, float target)
            => Mathf.MoveTowardsAngle(angelX, target, Time.deltaTime * m_speed);

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Stone>(out var stone))
            {
                stone.GetComponent<Rigidbody>().AddForce(m_power * m_direction, ForceMode.Force);
            }
        }
    }
}
