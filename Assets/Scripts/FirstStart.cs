using UnityEngine;
using ExpPlus.Phariables;
public class FirstStart : MonoBehaviour
{

    [SerializeField]
    private BoolPhariable resetGame;

    // Start is called before the first frame update
    void Start()
    {
        resetGame.value = true;
        Destroy(gameObject);
    }
}
