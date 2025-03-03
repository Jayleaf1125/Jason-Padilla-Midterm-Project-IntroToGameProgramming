using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public int sceneLevel;
    public bool isInteractableChange = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Print()
    {
        Debug.Log("Button Works");
    }

    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync(sceneLevel);   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (isInteractableChange)
        {
            SceneManager.LoadSceneAsync(sceneLevel);
        }
    }
}
