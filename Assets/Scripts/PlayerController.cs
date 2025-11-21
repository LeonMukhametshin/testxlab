using UnityEngine;
using UnityEngine.EventSystems;

namespace Golf
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private EventTrigger m_hitButton;
        [SerializeField] private Stick m_stick;

        private bool m_isDown;

        private void Start()
        {
            var entryDown = new EventTrigger.Entry();
            entryDown.eventID = EventTriggerType.PointerDown;

            var entryUp = new EventTrigger.Entry();
            entryUp.eventID = EventTriggerType.PointerUp;

            entryDown.callback.AddListener(OnPointerDown);
            entryUp.callback.AddListener(OnPointerUp);

            m_hitButton.triggers.Add(entryDown);
            m_hitButton.triggers.Add(entryUp);
        }

        private void Update()
        {
            //if (Input.GetKey(KeyCode.RightArrow))
            if(m_isDown)
            {
                m_stick.Down();
            }
            else
            {
               m_stick.Up();
            }
        }

        private void Down() => m_isDown = true;

        private void Up() => m_isDown = false;


        private void OnPointerDown(BaseEventData arg0) => Down();

        private void OnPointerUp(BaseEventData arg0) => Up();   
    }
}