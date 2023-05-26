using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public delegate void InteractInputHandler();
    public static event InteractInputHandler OnInteractPressed;
    public KeyCode interactKey;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(interactKey))
        {
            OnInteractPressed?.Invoke();
        }
    }
}
