using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HW10Scrambler : MonoBehaviour {
    List<HW10SaveItem> saveItems = new List<HW10SaveItem>();
    public Vector2 positionOffset;
    public Vector2 scaleRangeRandom;

    void Start()
    {
        HW10SaveItem[] saveItemsArray = FindObjectsByType<HW10SaveItem>(FindObjectsSortMode.None); // Finding all objects in the scene with this script on it
        saveItems = saveItemsArray.ToList(); // Converting an array to a list
    }

    void Update()
    {
        // Scramlbing all the position rotations and scales of the save items
        if(Input.GetKeyDown(KeyCode.Space)) {
            Scramble();
        }
    }

    public void Scramble() {
        foreach(HW10SaveItem item in saveItems) {
            Transform itemTransform = item.gameObject.transform; // Saving transform to make it easier to work with
            // Setting random position
            itemTransform.position = new Vector3(Random.Range(-positionOffset.x, positionOffset.x), Random.Range(-positionOffset.y, positionOffset.y));
            
            // Setting random rotation
            itemTransform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
            
            // Calculating and setting random scale 
            float randomScaleVal = Random.Range(scaleRangeRandom.x, scaleRangeRandom.y);
            itemTransform.localScale = new Vector3(randomScaleVal, randomScaleVal, randomScaleVal);
        }
    }
}
