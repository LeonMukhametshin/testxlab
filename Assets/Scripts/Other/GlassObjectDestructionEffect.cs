using UnityEngine;
using Golf;

public class GlassObjectDestructionEffect : MonoBehaviour
{
    [SerializeField] private int m_score = 5;

    [SerializeField] private GameObject[] m_fragments;
    [SerializeField] private ExplisionData m_glassData;

    private Vector3 explosionCenter;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Stone>())
        {
            if (m_fragments != null)
            {
                explosionCenter = collision.contacts[0].point;

                ActivateFragments();

                ScoreManager.Instance.Hit(m_score);
            }
            gameObject.SetActive(false);
        }
    }

    private void ActivateFragments()
    {
        for (int i = 0; i < m_fragments.Length; i++)
        {
            m_fragments[i].gameObject.SetActive(true);
            m_fragments[i].GetComponent<MeshRenderer>().enabled = true;

            var rb = m_fragments[i].GetComponent<Rigidbody>();
            if (rb is not null)
            {
                rb.useGravity = true;
                rb.isKinematic = false;

                rb.AddExplosionForce(
                       m_glassData.ExplosionForce,
                       explosionCenter,
                       m_glassData.ExplosionRadius,
                       m_glassData.UpwardModifier,
                       ForceMode.Impulse
                   );
            }
        }
    }
}
