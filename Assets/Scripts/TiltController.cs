using UnityEngine;
using UnityEngine.InputSystem;

public class TiltController : MonoBehaviour
{
    [Header("Config"),SerializeField]
    private float tiltSpeed = 1;

    [SerializeField]
    private float maxTiltAngle;

    private Vector2 input;

    private float rotX;
    private float rotZ;

    // Update is called once per frame
    void Update()
    {
        rotX += input.x * tiltSpeed;
        rotZ += input.y * tiltSpeed;

        rotX = Mathf.Clamp(rotX, -maxTiltAngle, maxTiltAngle);
        rotZ = Mathf.Clamp(rotZ, -maxTiltAngle, maxTiltAngle);

        transform.localEulerAngles = new Vector3(rotX, transform.localEulerAngles.y, rotZ);
    }

    public void TiltInput(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }
}
