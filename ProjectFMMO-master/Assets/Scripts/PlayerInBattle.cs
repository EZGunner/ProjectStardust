using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Actions {
    JUMP,
    HAMMER,
    ITEMS,
    RUN
}

public class PlayerInBattle : MonoBehaviour {
    public int HP; //find a way to keep this stored in a more 
                   //general player class, then bring their hitpoints here    

    List<GameObject> validEnemies;

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void DoAction(int actionChosen) {
        if (actionChosen == (int)Actions.JUMP) {
            //if any valid targets available (not too often targets will be physically impossible to jump on):
            //pick a target
            validEnemies = ListAllEnemies((int)Actions.JUMP);
            if (validEnemies.Count > 0) {
                print("jump on something");
            }
            else {
                print("no valid targets!");
            }
        }
        if (actionChosen == (int)Actions.HAMMER) {
            //if any valid targets available:
            //pick a target
            validEnemies = ListAllEnemies((int)Actions.HAMMER);
            if (validEnemies.Count > 0) {
                print("hammer something");
            }
            else {
                print("no valid targets!");
            }
        }
        if (actionChosen == (int)Actions.ITEMS) {
            //if any items available for use:

        }
        if (actionChosen == (int)Actions.RUN) {
            //if NOT in a boss fight:

        }
    }

    public List<GameObject> ListAllEnemies(int attackChosen) {
        //
        GameObject[] activeEnemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> validEnemies = new List<GameObject>();

        if (attackChosen == (int)Actions.HAMMER) {
            foreach (GameObject e in activeEnemies) {
                if (!e.GetComponent<Enemy>().notHammerable) {
                    validEnemies.Add(e);
                }
            }
        }
        if (attackChosen == (int)Actions.JUMP) {
            foreach (GameObject e in activeEnemies) {
                if (!e.GetComponent<Enemy>().notJumpable) {
                    validEnemies.Add(e);
                }
            }
        }

        return validEnemies;
    }

    public void DamageIncoming() {

    }
}
