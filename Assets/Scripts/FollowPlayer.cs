using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.Find("Player");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        player = GameObject.Find("Player");

        if (player == null)
        {
            Debug.LogError("Could not find object with name " + "Player");
        }
    }
        // Update is called once per frame
        void Update()
    {
        transform.position = player.transform.position;
    }
}
