using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapEditor : MonoBehaviour {

    public GameObject selectedTile; //tile player has currently chosen


    
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 mousePositionSnap = new Vector3
                (RoundToWholeNum(mousePosition.x), 
                RoundToWholeNum(mousePosition.y),
                0);

            Instantiate(selectedTile, 
                new Vector3(mousePositionSnap.x, mousePositionSnap.y, 10f), 
                Quaternion.identity);
        }
    }

    float RoundToWholeNum(float value) {
        if (value - (int)value >= 0.5) {
            return Mathf.Ceil(value);
        }
        else {
            return Mathf.Floor(value);
        }
    }
}
