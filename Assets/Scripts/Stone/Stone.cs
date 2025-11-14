using System;
using UnityEngine;

namespace Golf
{
    public class Stone : MonoBehaviour
    {
        public event Action<Stone> Hit;
        public event Action<Stone> Missed;

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.GetComponent<Stick>())
            {
                Hit?.Invoke(this);
            }
            else
            {
                Missed?.Invoke(this);
            }
        }
    }
}
