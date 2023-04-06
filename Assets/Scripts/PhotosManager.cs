using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PhotosManager : MonoBehaviour
{
    public float time = 45;
    void Start()
    {
        StartCoroutine(ShowAllPhotos(time));
    }
    IEnumerator ShowAllPhotos(float time)
    {
        List<Transform> children = new();

        foreach (Transform child in transform)
        {
            Debug.Log(child.name);
            children.Add(child);
        }
        float timeForOnePhoto = time / children.Count;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
            yield return new WaitForSecondsRealtime(timeForOnePhoto);
            child.gameObject.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
// Update is called once per frame
void Update()
    {
        
    }
}
