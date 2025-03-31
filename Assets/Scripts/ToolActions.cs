using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Eventes
{
    None, 
    Activate
}

public class ToolActions : MonoBehaviour
{
    void activateObject()
    {
        print("Se ha activado el objeto");
    }

    public void ModifyDataOnInspector(string p_NameOfEvent)
    {
        switch (p_NameOfEvent)
        {
            case "Activate":
                activateObject();
                break;
        }
    }
}
