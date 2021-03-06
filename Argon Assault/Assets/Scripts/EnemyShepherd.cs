﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShepherd : MonoBehaviour
{
    // Variables
    [SerializeField] GameObject deathFX;
    [SerializeField] Transform parent;

    [Header("Enemy Stats")]
    [SerializeField] int pointsValue = 10;
    [SerializeField] int maxHP = 5;
    int currentHP;

    ScoreBoard scoreBoard;

    // Use this for initialization
    void Start ()
    {
        DefineEnemyShepherdVariables();
        CreateNonTriggerBoxCollider();
    }

    private void DefineEnemyShepherdVariables()
    {
        currentHP = maxHP;
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void CreateNonTriggerBoxCollider()
    {
        Collider enemyCollider = gameObject.AddComponent<BoxCollider>();
        enemyCollider.isTrigger = false;
    }

    // Detect particle collisions
    public void OnParticleCollision(GameObject other)
    {
        currentHP--;
        if (currentHP <= 0)
        {
            KillEnemy();
            IncreaseScore();
        }
        else
        {
            //Do nothing
        }
        
    }

    // Play death FX and destroy gameobject
    private void KillEnemy()
    {
        GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
        fx.transform.parent = parent;
        Destroy(gameObject);
    }

    // Send message to increase the score to the scoreboard
    private void IncreaseScore()
    {
        scoreBoard.ScoreHit(pointsValue);
        print("score increase");
    }
}
