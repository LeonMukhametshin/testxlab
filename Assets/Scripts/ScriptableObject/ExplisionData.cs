using UnityEngine;

namespace Golf
{
    [CreateAssetMenu(fileName = "ExplisionData", menuName = "Scriptable Objects/ExplisionData")]
    public class ExplisionData : ScriptableObject
    {
        [SerializeField] private float m_explosionForce = 10f;
        [SerializeField] private float m_explosionRadius = 3f;
        [SerializeField] private float m_upwardModifier = 0.5f;

        public float ExplosionForce => m_explosionForce;
        public float ExplosionRadius => m_explosionRadius;
        public float UpwardModifier => m_upwardModifier;
    }
}
