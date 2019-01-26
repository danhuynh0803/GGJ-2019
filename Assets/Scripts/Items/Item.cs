﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string name;
    public Sprite sprite;
    public int score;
    public int cost;
    public float radius;
    public float canvasStayTimer = 1.5f;
    public GameObject interactionImage;
    private bool playerInRange;
    private GameObject player;
    private float canvasTimer;
    

    private void Start()
    {
        name = this.gameObject.name.ToLower();
        player = FindObjectOfType<PlayerController>().gameObject;
        if (radius == 0)
        {
            radius = 1;
        }
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
        if (Vector3.Distance(transform.position, player.transform.position) <= radius)
        {
            playerInRange = true;
            canvasTimer = canvasStayTimer;
        }
        else
        {
            playerInRange = false;
        }

        if (playerInRange)
        {
            if(interactionImage != null)
                interactionImage.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                player.GetComponent<PlayerController>().PickUpItem(this);
            }
        }
        else
        {
            canvasTimer -= Time.deltaTime;
        }

        if (canvasTimer <= 0)
        {
            if(interactionImage != null && interactionImage.activeSelf == true)
                interactionImage.SetActive(false);
        }
    }
}