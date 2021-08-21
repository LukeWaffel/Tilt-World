using UnityEngine;
using ExpPlus.Phariables;

public class PlayerManager : MonoBehaviour
{
    [Header("References"),SerializeField]
    private FloatPhariable failSafeDepth;

    [Header("Events"),SerializeField]
    private BoolPhariable resetGame;

    private void Update()
    {
        if(transform.position.y < failSafeDepth.value)
        {
            resetGame.value = true;
        }
    }
}
