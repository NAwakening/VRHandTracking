using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PainterManager : MonoBehaviour
{
    [SerializeField] GameObject _paint;
    [SerializeField] Transform _paintPosition;
    public void Paint()
    {
        GameObject paint = Instantiate(_paint);
        paint.transform.position = _paintPosition.position;
    }
}
