using UnityEngine;

namespace Golf
{
    public class CollisionLogger : MonoBehaviour
    {
        [SerializeField] private CollisionLayersScriptableObject m_collisionLayers;
        
        private LayerMask m_combinedLayers;

        private void Awake()
        {
            if(m_collisionLayers is null)
            {
                Debug.LogError("SO CollisionLayers is null");
            }
            m_combinedLayers = m_collisionLayers.CombinedLayers;
        }

        //TODO: избавиться от дублежа логики
        private void OnCollisionEnter(Collision collision)
        {
            if (IsInTargetLayers(collision.gameObject.layer))
            {
                Debug.Log($"OnCollisionEnter with: {collision.gameObject.name}");
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (IsInTargetLayers(collision.gameObject.layer))
            {
                Debug.Log($"OnCollisionExit with: {collision.gameObject.name}");
            }
        }

        private bool IsInTargetLayers(int objectLayer) =>
            ((1 << objectLayer) & m_combinedLayers) != 0;
    }
}