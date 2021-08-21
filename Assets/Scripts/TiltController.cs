using UnityEngine;
using UnityEngine.InputSystem;
using ExpPlus.Phariables;

public class TiltController : MonoBehaviour
{
    [Header("Config"),SerializeField]
    //private float tiltSpeed = 0.05f;
    private FloatPhariable tiltSpeed;

    [SerializeField]
    private FloatPhariable maxTiltAngle;
    //private float maxTiltAngle = 30f;

    private Vector2 input;

    private float rotX;
    private float rotZ;

    // Update is called once per frame
    void Update()
    {
        rotX += input.x * tiltSpeed.value;
        rotZ += input.y * tiltSpeed.value;

        rotX = Mathf.Clamp(rotX, -maxTiltAngle.value, maxTiltAngle.value);
        rotZ = Mathf.Clamp(rotZ, -maxTiltAngle.value, maxTiltAngle.value);

        transform.localEulerAngles = new Vector3(rotX, transform.localEulerAngles.y, rotZ);
    }

    public void TiltInput(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }
}
