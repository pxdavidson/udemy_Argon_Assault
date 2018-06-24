using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShepherd : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    ScoreBoard scoreBoard;

    // Use this for initialization
    void Start ()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
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
        scoreBoard.ScoreHit();
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }
}
