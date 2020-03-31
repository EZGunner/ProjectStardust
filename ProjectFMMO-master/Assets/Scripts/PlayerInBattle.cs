using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public Transform arrow; //point at single target

    int currentSelection;
    bool selectingSingleTarget = false;

    // Start is called before the first frame update
    void Start() {
        arrow.GetComponent<SpriteRenderer>().enabled = false;
    }

    // Update is called once per frame
    void Update() {
        if (selectingSingleTarget) {
            arrow.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.RightArrow)) {
                if (currentSelection == validEnemies.Count - 1) {
                    currentSelection = 0;
                }
                else {
                    currentSelection++;
                }
                SetCursor(validEnemies);
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                if (currentSelection == 0) {
                    currentSelection = validEnemies.Count - 1;
                }
                else {
                    currentSelection--;
                }
                SetCursor(validEnemies);
            }
            if (Input.GetKeyDown(KeyCode.Return)) {
                validEnemies[currentSelection].GetComponent<Enemy>().TakeDamage(1);
                currentSelection = 0;
                arrow.GetComponent<SpriteRenderer>().enabled = false;
                selectingSingleTarget = false;
            }
        }
    }

    public void DoAction(int actionChosen) {
        if (actionChosen == (int)Actions.JUMP) {
            //if any valid targets available (not too often targets will be physically impossible to jump on):
            //pick a target
            validEnemies = ListAllEnemies((int)Actions.JUMP);
            if (validEnemies.Count > 0) {
                print("jump on something");
                SetCursor(validEnemies);
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
                SetCursor(validEnemies);
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

    //for any action that takes one target
    public void SetCursor(List<GameObject> targets) {
        arrow.transform.position = new Vector3(
            targets[currentSelection].transform.position.x,
            targets[currentSelection].transform.position.y + 3f,
            0);
        print("set cursor");
        selectingSingleTarget = true;
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

    public void EnemiesAttack(List<GameObject> validEnemies) {

    }

    public void DamageIncoming() {

    }
}
