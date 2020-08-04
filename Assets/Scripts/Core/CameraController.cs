using ForgottenLegends.Character;
using UnityEngine;

namespace ForgottenLegends.Core
{
    public class CameraController : Singleton<CameraController>
    {
        private const float MAX_UPDOWN = 80f;
        private const float MIN_DISTANCE = 2f;
        private const float MAX_DISTANCE = 4f;
        private const float SPEED_MULT = 2f;

        [SerializeField] private float m_RotationSpeed = 4;
        [SerializeField] private Transform m_Target = null;
        [SerializeField] private NPC m_LockOnTarget;

        private Vector2 m_CameraRotation = new Vector2(0, 0);
        private float m_Distance = 0f;
        float mouseX, mouseY, mouseScroll;
        private InputHandler m_InputHandler;

        // Start is called before the first frame update
        void Start()
        {
            m_InputHandler = InputHandler.Instance;
            MouseCursor.SetMouseVisible(false);
            m_CameraRotation.x = 0f;
            m_CameraRotation.y = 0f;
            m_Distance = Vector3.Distance(transform.position, m_Target.transform.position);
        }

        private void Update()
        {
            GetInput();
            ProcessData();
            UpdateCamera();
        }

        private void UpdateCamera()
        {
            Quaternion targetRot = Quaternion.Euler(m_CameraRotation.x, m_CameraRotation.y, 0.0f);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * (m_RotationSpeed * SPEED_MULT));
            if (m_LockOnTarget)
            {
                transform.LookAt(m_LockOnTarget.transform.position + Vector3.up);
            }
            transform.position = m_Target.transform.position - transform.forward * m_Distance;
        }

        private void ProcessData()
        {
            if (MouseCursor.MouseShown == true)
            {
                return;
            }

            m_CameraRotation.y += mouseX * m_RotationSpeed;
            m_CameraRotation.x += mouseY * m_RotationSpeed;
            m_CameraRotation.x = Mathf.Clamp(m_CameraRotation.x, -MAX_UPDOWN, MAX_UPDOWN);


            m_Distance -= mouseScroll;
            m_Distance = Mathf.Clamp(m_Distance, MIN_DISTANCE, MAX_DISTANCE);
        }

        private void GetInput()
        {
            if (MouseCursor.MouseShown == true)
            {
                return;
            }

            mouseX = m_InputHandler.MouseX;
            mouseY = m_InputHandler.MouseY;
            mouseScroll = m_InputHandler.MouseScroll;
        }

        public void LockOn(NPC npc)
        {
            m_LockOnTarget = npc;
        }

        public void LockOff()
        {
            m_LockOnTarget = null;
        }
    }
}