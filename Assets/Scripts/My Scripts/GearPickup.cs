using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearPickup : MonoBehaviour
{
    public delegate void PickupHandler(int scoreToIncrement);
    public static event PickupHandler OnPickupEvent;
    [SerializeField] private int scoreValue = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPickupEvent?.Invoke(scoreValue);
            gameObject.SetActive(false);
        }
    }
}
