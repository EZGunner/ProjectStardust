using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int HP;
    public int attack;
    public int defense;

    public bool notHammerable; //if true, enemy then can't be reached w/ hammer
    public bool notJumpable; //if true, enemy then can't even be reached w/ jump
    public bool spikey; //if true, player will take spike damage trying to jump on this enemy
    public bool firey; //if true, player will be burned trying to jump on this enemy

    public PlayerInBattle targetPlayer; //the player in battle to interact with

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void Attack() {
        //assuming multiple attack targets, the enemy has to choose one

        //for now, assuming only one target: the player themselves in the battle scene
        targetPlayer.DamageIncoming();
    }

    public void TakeDamage(int damage) {
        int incomingDamage = damage - defense;
        if (incomingDamage < 0) {
            incomingDamage = 0;
        }
        HP -= incomingDamage;

        //then check if HP is 0 or less; if so, enemy dies
        if (HP <= 0) {
            Die();
        }
    }

    public void Die() {
        //placeholder code to show enemy "died"
        this.gameObject.SetActive(false);
        //Destroy(this.gameObject);
    }
}
