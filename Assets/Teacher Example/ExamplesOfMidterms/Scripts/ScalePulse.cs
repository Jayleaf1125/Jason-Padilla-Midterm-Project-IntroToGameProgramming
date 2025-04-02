using JetBrains.Annotations;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class ScalePulse : MonoBehaviour
{
    public float scaleVal = 0;
    public float scaleRate = 0.1f;
    public float scaleLimit = 2f;

    public bool increasingScale = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if the value is increasing
        if(increasingScale) {
            
            // increasing scale value
            scaleVal += scaleRate * Time.deltaTime;

            // if the scale value reaches the limit
            if(scaleVal >= scaleLimit) {

                // Swapping the decreasing scale
                increasingScale = false;
            }
        }
        else {

            // Decreasing the scale of the scale value
            scaleVal -= scaleRate * Time.deltaTime;

            // If the scale reaches the other limit
            if (scaleVal <= 0) {

                // Swap to increasing the scale
                increasingScale = true;
            }
        }

        // Setting the scale of the object
        transform.localScale = new Vector3(scaleVal, scaleVal, scaleVal);
    }
}
