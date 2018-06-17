using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShepherd : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

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
    void OnParticleCollision(GameObject other)
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
