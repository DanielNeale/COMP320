using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Controls the game states
/// </summary>
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

    /// <summary>
    /// Opens the consent form and stops the game time
    /// </summary>
    private void Awake()
    {
        consentForm.SetActive(true);

        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }


    /// <summary>
    /// Opens the difficulty page
    /// </summary>
    public void Consented()
    {
        consentForm.SetActive(false);
        difficulty.SetActive(true);
    }


    /// <summary>
    /// Starts the game
    /// </summary>
    /// <param name="newDiff"></param>
    public void SelectDiff(int newDiff)
    {
        GetComponent<Difficulty>().SetDiff(newDiff);

        difficulty.SetActive(false);

        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        StartCoroutine(GameTime());
    }


    /// <summary>
    /// Ends the game after gameLength seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator GameTime()
    {
        yield return new WaitForSeconds(gameLength);

        survey.SetActive(true);

        Time.timeScale = 0;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;      
    }


    /// <summary>
    /// Generates data file and resets the game
    /// </summary>
    public void Finish()
    {
        GetComponent<DataCollection>().GenerateFile();

        SceneManager.LoadScene(0);
    }
}
