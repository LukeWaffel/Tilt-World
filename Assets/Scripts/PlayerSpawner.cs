using UnityEngine;
using ExpPlus.Phariables;

public class PlayerSpawner : MonoBehaviour
{
    [Header("References"),SerializeField]
    private GameObject activePlayer;

    [SerializeField]
    private GameObject playerPrefab;
    
    [Header("Events"),SerializeField]
    private BoolPhariable resetGame;

    private void OnEnable()
    {
        resetGame.SubscribeToOnChangeSignal("Reset Game", SpawnPlayer);
    }

    private void OnDisable()
    {
        resetGame.UnSubscribeFromOnChangeSignal("Reset Game", SpawnPlayer);
    }

    private void SpawnPlayer()
    {

        if (activePlayer != null)
            Destroy(activePlayer);   

        activePlayer = Instantiate(playerPrefab, transform.position, Quaternion.identity);
        activePlayer.GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 0, 2);
    }
}
