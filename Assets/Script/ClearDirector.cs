using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear : MonoBehaviour
{
    // Start is called before the first frame updat
    // Update is called once per frame
    void Update()
    {
        //マウスがクリックされた時に画面の遷移をする(シーンが遷移される)
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
