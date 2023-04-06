using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroy : MonoBehaviour
{
    private int sceneIndex;
    private bool sceneIndexSet = false;
    // Start is called before the first frame update
    void Awake()
    {
        SceneManager.sceneLoaded += DestroyIfSceneChanged;
        GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);
        if (objs.Length > 1)
        {
            Debug.Log("Music object destroyed");
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void DestroyIfSceneChanged(Scene scene, LoadSceneMode mode)
    {
        if (!sceneIndexSet)
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex;
            sceneIndexSet = true;
        }

        try
        {
            if (sceneIndex != SceneManager.GetActiveScene().buildIndex)
            {
                Destroy(this.gameObject);
            }
        }
        catch
        {
            Debug.Log("Music has been changed");
        }
    }
}
