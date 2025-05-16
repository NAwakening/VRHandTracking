using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] XRTypeOfControl control;
    [SerializeField] TextMeshProUGUI countdownText;
    [SerializeField] GameObject continuousMove;
    [SerializeField] GameObject teleportMovement;
    [SerializeField] GameObject continuousRotation;
    [SerializeField] GameObject snapRotation;

    [Header("Timer")]
    [SerializeField] int minutes;
    [SerializeField] float seconds;

    [Header("Victory&Defeat")]
    [SerializeField] bool isGoingToChangeScene;
    [SerializeField] GameObject victoryPanel;
    [SerializeField] GameObject defeatPanel;
    [SerializeField] int victorySceneId;
    [SerializeField] int defeatSceneID;

    bool gameEnded = false;

    // Start is called before the first frame update
    void Start()
    {
        if (control.movement.continuousMov == true)
        {
            continuousMove.SetActive(true);
            teleportMovement.SetActive(false);
        }
        else
        {
            continuousMove.SetActive(false);
            teleportMovement.SetActive(true);
        }

        if (control.movement.continuousRot == true)
        {
            continuousRotation.SetActive(true);
            snapRotation.SetActive(false);
        }
        else
        {
            continuousRotation.SetActive(false);
            snapRotation.SetActive(true);
        }

        if (isGoingToChangeScene)
        {
            victoryPanel = null;
            defeatPanel = null;
        }
    }

    void FixedUpdate()
    {
        if (!gameEnded)
        {
            seconds -= Time.fixedDeltaTime;
            int time = (int)seconds;
            if (time < 0)
            {
                minutes--;
                if (minutes < 0)
                {
                    GoToDefeat();
                }
                seconds = 59;
                time = 59;
            }
            if (time < 10)
            {
                countdownText.text = "Time Left: " + minutes + ":" + "0" +time;
            }
            else
            {
                countdownText.text = "Time Left: " + minutes + ":" + time;
            }
        }
    }

    void GoToDefeat()
    {
        gameEnded = true;
        countdownText.text = null;
        if (!isGoingToChangeScene)
        {
            defeatPanel.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(defeatSceneID);
        }
    } 

    public void GoToVictory()
    {
        gameEnded = true;
        countdownText.text = null;
        if (!isGoingToChangeScene)
        {
            victoryPanel.SetActive(true);
        }
        else
        {
            SceneManager.LoadScene(victorySceneId);
        }
    }
}
