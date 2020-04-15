using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    
    public Texture2D map;

    public ColorToPrefab[] colorMappings;

    void Start()
    {
        generateLevel();
    }

    private void generateLevel() {
        for(int x = 0; x < map.width; x++) {
            for(int y = 0; y < map.height; y++) {
                generateTile(x, y);
            }
        }
    }

    private void generateTile(int x, int y) {
        Color pixelColor = map.GetPixel(x, y);

        //Debug.Log("Checking new pixel at (" + x + "," + y + ").");

        if(pixelColor.a == 0) {
            // The pixel is transparent, so we should ignore it
            return;
            //Debug.Log("Above pixel is transparent");
        }

        Debug.Log("Above pixel is NOT transparent");

        foreach (ColorToPrefab colorMapping in colorMappings) {
            if(colorMapping.color == pixelColor) {
                Vector2 position = new Vector2(x, y);
                Instantiate(colorMapping.prefab, position, Quaternion.identity);
                //Debug.Log("New Pixel: "+pixelColor);
            }
        }

    }

}
