using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetManager : MonoBehaviour
{
    [SerializeField] int pointsNeededToOpenDoor;
    [SerializeField] int pointsNeededToGetClue;
    [SerializeField] GameObject door;
    [SerializeField] GameObject clue;
    [SerializeField] Animator anim;

    [SerializeField] TextMeshProUGUI marcador;

    int points;

    public void StartGame()
    {
        points = 0;
        anim.Play("Game");
        UpdatePoints(0);
    }

    public void EndGame()
    {
        if (points >= pointsNeededToGetClue)
        {
            clue.SetActive(true);
            door.SetActive(false);
        }

        else if (points >= pointsNeededToOpenDoor)
        {
            door.SetActive(false);
        }
    }

    public void UpdatePoints(int newPoints)
    {
        points += newPoints;
        marcador.text = "Points needed to escape: " + pointsNeededToOpenDoor + "\n" + "Points needed for clue: " + pointsNeededToGetClue + "\n" + "Points obtained: " + points;
    }

    public int Points
    {
        get { return points; }
        set { points = value; }
    }
}
