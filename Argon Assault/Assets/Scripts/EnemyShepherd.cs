using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShepherd : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
        CreateNonTriggerBoxCollider();
    }

    private void CreateNonTriggerBoxCollider()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    // Detect particle collisions
    void OnParticleCollision(GameObject otherGameObject)
    {
        Destroy(gameObject);
    }
}
