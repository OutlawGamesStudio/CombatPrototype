using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    private const float MAX_UPDOWN = 80f;
    private const float MIN_DISTANCE = 2f;
    private const float MAX_DISTANCE = 4f;

    [SerializeField] private float m_RotationSpeed = 4;
    [SerializeField] private Transform m_Target = null;
    
    Vector2 rotation = new Vector2(0, 0);
    [SerializeField] private float m_Distance = 0f;
    float mouseX, mouseY, mouseScroll;
    private InputHandler m_InputHandler;

    // Start is called before the first frame update
    void Start()
    {
        m_InputHandler = InputHandler.Instance;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rotation.x = 0f;
        rotation.y = 0f;
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
        Quaternion targetRot = Quaternion.Euler(rotation.x, rotation.y, 0.0f);
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, m_RotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, Time.deltaTime * (m_RotationSpeed * 4));
        transform.position = m_Target.transform.position - (transform.forward * m_Distance);
    }

    private void ProcessData()
    {
        rotation.y += mouseX * m_RotationSpeed;
        rotation.x += mouseY * m_RotationSpeed;
        rotation.x = Mathf.Clamp(rotation.x, -MAX_UPDOWN, MAX_UPDOWN);


        m_Distance -= mouseScroll;
        m_Distance = Mathf.Clamp(m_Distance, MIN_DISTANCE, MAX_DISTANCE);
    }

    private void GetInput()
    {
        mouseX = m_InputHandler.MouseX;
        mouseY = m_InputHandler.MouseY;
        mouseScroll = m_InputHandler.MouseScroll;
    }
}
