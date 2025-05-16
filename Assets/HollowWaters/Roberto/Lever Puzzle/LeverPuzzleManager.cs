using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class LeverPuzzleManager : MonoBehaviour
{
    [SerializeField] GameObject wall;
    [SerializeField] GameObject wheel;

    [SerializeField] int index = 0;
    [SerializeField] bool canOpen = true;
    [SerializeField] int lastCorrectIndex = 0;

    public void OnNorthActivation()
    {
        index++;
        if (index == 4 && canOpen)
        {
            wall.SetActive(false);
            wheel.SetActive(true);
            lastCorrectIndex = index;
        }
        else
        {
            canOpen = false;
        }
    }

    public void OnNorthDeactivation()
    {
        index--;
        if (index == lastCorrectIndex)
        {
            canOpen = true;
        }
        else if (index == 0)
        {
            canOpen = true;
            lastCorrectIndex = 0;
        }
    }

    public void OnSouthActivation()
    {
        index++;
        if (index == 1 && canOpen)
        {
            lastCorrectIndex = index;
        }
        else
        {
            canOpen = false;
        }
    }

    public void OnSouthDeactivation()
    {
        index--;
        if (index == lastCorrectIndex)
        {
            canOpen = true;
        }
        else if (index == 0)
        {
            canOpen = true;
            lastCorrectIndex = 0;
        }
    }

    public void OnEastActivation()
    {
        index++;
        if (index == 2 && canOpen)
        {
            lastCorrectIndex = index;
        }
        else
        {
            canOpen = false;
        }
    }

    public void OnEastDeactivation()
    {
        index--;
        if (index == lastCorrectIndex)
        {
            canOpen = true;
        }
        else if (index == 0)
        {
            canOpen = true;
            lastCorrectIndex = 0;
        }

        if (canOpen)
        {
            lastCorrectIndex = index;
        }
    }

    public void OnWeastActivation()
    {
        index++;
        if (index == 3 && canOpen)
        {
            lastCorrectIndex = index;
        }
        else
        {
            canOpen = false;
        }
    }

    public void OnWeastDeactivation()
    {
        index--;
        if (index == lastCorrectIndex)
        {
            canOpen = true;
        }
        else if (index == 0)
        {
            canOpen = true;
            lastCorrectIndex = 0;
        }

        if (canOpen)
        {
            lastCorrectIndex = index;
        }
    }
}
