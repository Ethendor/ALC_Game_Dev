﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

    public GameObject currentCheckPoint;
    public Rigidbody2D pc;
    public GameObject pc2;

    // Particles

    public GameObject deathParticle;
    public GameObject respawnParticle;

    // Respawn Delay

    public float respawnDelay;

    // Point Penalty for Death

    public int pointPenaltyOnDeath;

    // Store Gravity Value

    private float gravityStore;

	// Use this for initialization
	void Start () {
        //pc = FindObjectOfType<Rigidbody2D>();
        pc = GameObject.Find("PC").GetComponent<Rigidbody2D>();
        pc2 = GameObject.Find("PC");
	}
	
    public void RespawnPlayer(){
        StartCoroutine("RespawnPlayerCo");
    }

    public IEnumerator RespawnPlayerCo(){
        // Generate Death Particle
        Instantiate(Resources.Load("Prefabs/DeathParticle") as GameObject, pc.transform.position, pc.transform.rotation);
        // Hide Player
        //  pc.enabled = false;
        pc2.SetActive(false);
        pc.GetComponent<Renderer>().enabled = false;
        // Gravity Reset
        gravityStore = pc.GetComponent<Rigidbody2D>().gravityScale;
        pc.GetComponent<Rigidbody2D>().gravityScale = 0f;
        pc.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // Point Penalty
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
        // Debug Message
        Debug.Log("Player Respawn");
        // Respawn Delay
        yield return new WaitForSeconds(respawnDelay);
        // Gravity Restore
        pc.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        // Match Players transform position
        pc.transform.position = currentCheckPoint.transform.position;
        // Show Player
      // pc.enabled = true;
        pc2.SetActive(true);
        pc.GetComponent<Renderer>().enabled = true;

        //Spawn PC
        Instantiate(Resources.Load("Prefabs/RespawnParticle") as GameObject, currentCheckPoint.transform.position, currentCheckPoint.transform.rotation);
    }
}
