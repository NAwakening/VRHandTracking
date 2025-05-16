using UnityEngine;

[System.Serializable]
public struct Controls
{
    public bool continuousMov;
    public bool continuousRot;
}

[CreateAssetMenu(fileName = "XRTypeOfControl", menuName = "Scriptable Objects/XRTypeOfControl")]
public class XRTypeOfControl : ScriptableObject
{
    [SerializeField] public Controls movement;
}
