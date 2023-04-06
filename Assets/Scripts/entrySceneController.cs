using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class entrySceneController : MonoBehaviour
{
    private bool canPress = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckIfKeyPressed());
    }
    private void Update()
    {
        if (Input.anyKey && canPress)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    // Update is called once per frame
    IEnumerator CheckIfKeyPressed()
    {
        yield return new WaitForSecondsRealtime(2);
        canPress = true;
    }
}
