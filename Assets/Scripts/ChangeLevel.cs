using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    
    
    public bool nextLevel;
    public int idLevel;

    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        if (nextLevel)
        {
            levelUp();
        }
    
    }

    public void levelUp(){
        int nextLevel = idLevel + 1;
        Debug.Log("nextLevel--------" + nextLevel);
        SceneManager.LoadScene(nextLevel);
    }

    /*
    [ContextMenu("boton cambiar nivel")]
    public void Change(){
        int nextLevel = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextLevel);
    }

    public void OnColisionEnter2D(Collision2D collision2D){
        Debug.Log("Hola tocando la puerta");
        int level = SceneManager.GetActiveScene().buildIndex;
        int nextLevel = level + 1;
        Debug.Log("Next level: " + nextLevel);
        Debug.Log("Tag" + collision2D.gameObject.tag);
        if(collision2D.gameObject.tag == "NextLevel"){
            SceneManager.LoadScene(nextLevel);
        }
    }*/


}
