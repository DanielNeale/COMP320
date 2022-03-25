using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    private void Start()
    {
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
    }


    IEnumerator GameTime()
    {
        yield return new WaitForSeconds(gameLength);


    }
}
