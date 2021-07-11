using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class MenuUI : MonoBehaviour
{
    [SerializeField] InputField NameInput;
    [SerializeField] Text BestScoreText;

    private void Start()
    {
        BestScoreText.text = $"Best Score : {DataManager.Instance.bestScoreName} : {DataManager.Instance.bestScorePoints}";
    }

    public void StartNew()
    {
        DataManager.Instance.c_Name = NameInput.text;
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }

}
