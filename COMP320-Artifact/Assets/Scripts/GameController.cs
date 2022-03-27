using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private GameObject consentForm;
    [SerializeField]
    private GameObject difficulty;
    [SerializeField]
    private GameObject survey;
    [SerializeField]
    private int gameLength;


    private void Awake()
    {
        consentForm.SetActive(true);

        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    public void Consented()
    {
        consentForm.SetActive(false);
        difficulty.SetActive(true);
    }


    public void SelectDiff(int newDiff)
    {
        GetComponent<Difficulty>().SetDiff(newDiff);

        difficulty.SetActive(false);

        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(GameTime());
    }


    IEnumerator GameTime()
    {
        yield return new WaitForSeconds(gameLength);

        survey.SetActive(true);

        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;      
    }


    public void Finish()
    {
        GetComponent<DataCollection>().GenerateFile();

        SceneManager.LoadScene(0);
    }
}
