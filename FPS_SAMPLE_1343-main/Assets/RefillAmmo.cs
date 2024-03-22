using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefillAmmo : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void OnTriggerStay(Collider other)
    {
        if (other.Equals(player))
        {
            if (Input.GetButtonDown("Interact"))
            {
                print("test");
            }
        }
    }
}
