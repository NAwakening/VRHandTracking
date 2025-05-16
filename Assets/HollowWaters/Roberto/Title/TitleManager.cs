using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{

    [SerializeField] XRTypeOfControl playerControl;

    public void LoadNextScene(int id)
    {
        SceneManager.LoadScene(id);
    }

    public void SetMovement(bool mode)
    {
        playerControl.movement.continuousMov = mode;
    }

    public void SetRotation(bool mode)
    {
        playerControl.movement.continuousRot = mode;
    }
}
