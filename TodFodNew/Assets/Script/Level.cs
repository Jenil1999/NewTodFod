using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{

    [SerializeField] int BreakableObj;

    SceneLoader sceneloader;

    public void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }

    public void CountBlock()
    {
        BreakableObj++;
    }

    public void BreakDownObj()
    {
        BreakableObj--;
        if(BreakableObj <= 0)
        {
            sceneloader.NextScene();
        }
    }
}
