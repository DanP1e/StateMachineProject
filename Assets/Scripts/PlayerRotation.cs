using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    [SerializeField] private Transform _camera;
    [SerializeField] private float _mouseSensitivity = 500;
    [SerializeField] private float _xViewRange = 75;
    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
        
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Vector2 mouseDelta = new Vector2();
        mouseDelta.x = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
        mouseDelta.y = Input.GetAxis("Mouse Y") * _mouseSensitivity * Time.deltaTime;

        xRotation -= mouseDelta.y;
        xRotation = Mathf.Clamp(xRotation, -_xViewRange, _xViewRange);

        _camera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseDelta.x);
    }
}
