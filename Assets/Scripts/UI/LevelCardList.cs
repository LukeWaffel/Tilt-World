using UnityEngine;
using ExpPlus.Molds;
using ExpPlus.Molds.Collections.Generated;

public class LevelCardList : MonoBehaviour
{

    [SerializeField]
    private GameObject levelCardPrefab;

    [SerializeField]
    private LevelCollection levels;
    // Start is called before the first frame update
    void Start()
    {
     
        for(int i =0; i < levels.entries.Count; i++){

            GameObject levelCard = Instantiate(levelCardPrefab, transform, false);
            levelCard.GetComponent<MoldRoot>().index = i;
            levelCard.GetComponent<MoldRoot>().UpdateAllContent();
        }
    }
}
