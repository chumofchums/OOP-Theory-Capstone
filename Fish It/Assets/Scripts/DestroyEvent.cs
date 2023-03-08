using System;
using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    public event Action OnDestroyed;

    private void OnDestroy()
    {
        OnDestroyed.Invoke();
    }
}
