using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Renderer background;
      void Start()
    {
        
    }

    void Update()
    {
        background.material.mainTextureOffset = background.material.mainTextureOffset + new Vector2(0.013f, 0) * Time.deltaTime;
    }
}
