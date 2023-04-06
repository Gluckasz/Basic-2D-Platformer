using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideText : MonoBehaviour
{
    public float time = 4;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideAfterTime());
    }
    IEnumerator HideAfterTime()
    {
        yield return new WaitForSecondsRealtime(time);
        gameObject.SetActive(false);
    }
}
