using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    public bool nextLevel;
    public int idLevel;

    public void Update(){
        if (nextLevel) levelUp();
    }

    public void levelUp(){
        int nextLevel = idLevel + 1;
        SceneManager.LoadScene(nextLevel);
    }

}
