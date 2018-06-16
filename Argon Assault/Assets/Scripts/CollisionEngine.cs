using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionEngine : MonoBehaviour
{

    // Detect triggers
    void OnTriggerEnter(Collider collider)
    {
        SendMessage("PlayerDead");
    }
}
