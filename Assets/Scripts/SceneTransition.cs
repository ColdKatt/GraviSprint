using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    private int _sceneNum;

    public void AnimateTransition(int sceneNum)
    {
        _anim.SetBool("IsSceneChanging", true);
        _sceneNum = sceneNum;
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene(_sceneNum);
    }
}
