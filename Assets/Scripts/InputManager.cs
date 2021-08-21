using ExpPlus.Phariables;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    [Header("Tilt Input"), SerializeField]
    private FloatPhariable tiltInputX;
    [SerializeField]
    private FloatPhariable tiltInputZ;
    private Vector2 input;

    [Header("Reset Event"), SerializeField]
    private BoolPhariable resetGame;
    public void TiltInput(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
        tiltInputX.value = input.x;
        tiltInputZ.value = input.y;
    }

    public void ResetInput(InputAction.CallbackContext context)
    {
        resetGame.value = true;
    }
}
