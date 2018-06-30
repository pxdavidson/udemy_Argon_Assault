using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEngine : MonoBehaviour
{
    PlayerController playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Detect triggers
    void OnTriggerEnter(Collider collider)
    {
        playerController.PlayerDead();
    }
}
