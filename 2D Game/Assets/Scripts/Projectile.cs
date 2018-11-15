using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float Speed;
    public float TimeOut;
    public GameObject PC;

    public GameObject EnemyDeath;

    public GameObject ProjectileParticle;

    public int PointsForKill;

	// Use this for initialization
	void Start () {
        // PC = FindObjectOfType<Rigidbody2D>();
        PC = GameObject.Find("PC");
            
        EnemyDeath = Resources.Load("Prefabs/EnemyDeathParticle") as GameObject;
        ProjectileParticle = Resources.Load("Prefabs/ProjectileParticle") as GameObject;
        
        if (PC.transform.localScale.x < 0)
            Speed = -Speed;
        
        // Destroy Projectile afterX seconds
        Destroy(gameObject,TimeOut);
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy"){
            Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            ScoreManager.AddPoints(PointsForKill);
        }

        Instantiate(ProjectileParticle, transform.position, transform.rotation);
        Destroy(gameObject);
        
	}
    void OnCollisionEnter2D(Collision2D other){
        Instantiate(ProjectileParticle, transform.position, transform.rotation);
        Destroy (gameObject);
    }
}