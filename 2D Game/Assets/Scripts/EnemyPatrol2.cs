using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol2 : MonoBehaviour{

    // Movement Variables

    public float MoveSpeed;
    public bool MoveRight;

    // Wall Check

    public Transform WallCheck;
    public float WallCheckRadius;
    public LayerMask WhatIsWall;
    private bool HittingWall;
    private bool NotAtEdge;
    public Transform EdgeCheck;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        NotAtEdge = Physics2D.OverlapCircle(EdgeCheck.position, WallCheckRadius, WhatIsWall);
        HittingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);

        // Flip enemy when hitting wall or edge
        if (HittingWall || !NotAtEdge){
            MoveRight = !MoveRight;
        }

        if (MoveRight){
            transform.localScale = new Vector3(-0.637f, 0.637f, 0.25f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else {
            transform.localScale = new Vector3(0.637f, 0.637f, 0.25f);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent <Rigidbody2D>().velocity.y);
        }
    }
}