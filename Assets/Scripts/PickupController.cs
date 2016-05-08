﻿using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour {

    static Potion[] selection = {Potion.Blast, Potion.Quick, Potion.Spine, Potion.Venom};
    Potion potionType;

	// Use this for initialization
	void Start () {
        potionType = selection[Random.Range(0, selection.Length)];
        gameObject.GetComponent<SpriteRenderer>().color = PotionColors.GetColor(potionType);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player") {
            var pc = other.gameObject.GetComponent<PlayerController>();
            pc.ReceivePotion(potionType);
            Destroy(gameObject);
        }
    }
}
