using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    private GameObject activePanel;

    [SerializeField]
    private GameObject levelSelectPanel;
    [SerializeField]
    private GameObject controlsPanel;
    [SerializeField]
    private GameObject creditsPanel;

    public void SetMenuPanel(int panelNumber)
    {
        if (activePanel)
            activePanel.SetActive(false);

        switch (panelNumber)
        {
            case 1:
                activePanel = levelSelectPanel;
                break;
            case 2:
                activePanel = controlsPanel;
                break;
            case 3:
                activePanel = creditsPanel;
                break;
        }

        activePanel.SetActive(true);
    }
}
