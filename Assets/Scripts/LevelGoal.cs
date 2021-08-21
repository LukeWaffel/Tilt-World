using ExpPlus.Phariables;
using UnityEngine;

public class LevelGoal : MonoBehaviour
{

    [SerializeField]
    private BoolPhariable finishGame;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            finishGame.value = true;
        }
    }
}
