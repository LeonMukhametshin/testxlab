using UnityEngine;

namespace Golf
{
    [CreateAssetMenu(fileName = "CollisionLayers", menuName = "Scriptable Objects/CollisionLayers")]
    public class CollisionLayersScriptableObject : ScriptableObject
    {
        public LayerMask CombinedLayers => m_combinedLayers;

        [SerializeField] private LayerMask[] m_layers;

        private LayerMask m_combinedLayers;

        private void OnEnable()
        {
            m_combinedLayers = 0;
            foreach (var layer in m_layers)
            {
                m_combinedLayers |= layer;
            }
        }
    }
}
