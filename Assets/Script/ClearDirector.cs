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
        //�}�E�X���N���b�N���ꂽ���ɉ�ʂ̑J�ڂ�����(�V�[�����J�ڂ����)
        if (Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("ClearScene");
        }
    }
}
