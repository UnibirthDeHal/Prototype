using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReStart : MonoBehaviour
{
    //�V�[�������[�h����
    public void LordScene(string str)
    {
        SceneManager.LoadScene(str);
    }
}
