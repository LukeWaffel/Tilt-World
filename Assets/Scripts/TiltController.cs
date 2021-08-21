using UnityEngine;
using ExpPlus.Phariables;

public class TiltController : MonoBehaviour
{
    [Header("Config"),SerializeField]
    //private float tiltSpeed = 0.05f;
    private FloatPhariable tiltSpeed;

    [SerializeField]
    private FloatPhariable maxTiltAngle;
    //private float maxTiltAngle = 30f;

    [Header("Input References"), SerializeField]
    private FloatPhariable inputX;
    [SerializeField]
    private FloatPhariable inputZ;

    [Header("Reset Event"), SerializeField]
    private BoolPhariable resetGame;

    private float rotX;
    private float rotZ;

    private void OnEnable()
    {
        resetGame.SubscribeToOnChangeSignal("Reset Game", ResetTilt);
    }

    private void OnDisable()
    {
        resetGame.UnSubscribeFromOnChangeSignal("Reset Game", ResetTilt);
    }

    // Update is called once per frame
    void Update()
    {
        rotX += inputX.value * tiltSpeed.value;
        rotZ += inputZ.value * tiltSpeed.value;

        rotX = Mathf.Clamp(rotX, -maxTiltAngle.value, maxTiltAngle.value);
        rotZ = Mathf.Clamp(rotZ, -maxTiltAngle.value, maxTiltAngle.value);

        transform.localEulerAngles = new Vector3(rotX, transform.localEulerAngles.y, rotZ);
    }

    private void ResetTilt()
    {
        rotX = 0;
        rotZ = 0;
    }
}
