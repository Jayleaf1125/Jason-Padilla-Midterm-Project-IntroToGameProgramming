using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class HW10SaveItem : MonoBehaviour 
{
    public List<Vector3> positionSaves;
    public List<Vector3> scaleSaves;
    public List<float> rotationSaves;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        positionSaves = new List<Vector3>();
        scaleSaves = new List<Vector3>();
        rotationSaves = new List<float>();
    }

    // Update is called once per frame
    void Update() {

        if(Input.GetKeyDown(KeyCode.S))
        {
            SavePositions();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadPositions();
        }
    }

    void SavePositions()
    {
        Vector3 position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 scale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
        float rotation = this.transform.eulerAngles.z;

        positionSaves.Add(position);
        rotationSaves.Add(rotation);
        scaleSaves.Add(scale);
    }

    void LoadPositions()
    {
        if (positionSaves.Count <= 0) return;

        Vector3 lastSavePos = positionSaves[positionSaves.Count-1];
        float lastSaveRot = rotationSaves[rotationSaves.Count-1];
        Vector3 lastSaveScale = scaleSaves[scaleSaves.Count-1];
        
        this.transform.position = lastSavePos;
        this.transform.rotation = Quaternion.Euler(0, 0, lastSaveRot);
        this.transform.localScale = lastSaveScale;

        positionSaves.Remove(lastSavePos);
        rotationSaves.Remove(lastSaveRot);
        scaleSaves.Remove(lastSaveScale);
    }
}