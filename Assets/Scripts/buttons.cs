using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    public void quitting() { Application.Quit(); }
    public void start_game() { SceneManager.LoadScene(1); }
    public void lose_game() { StartCoroutine(waiting()); }
    IEnumerator waiting()
    {
        yield return (new WaitForSeconds(2f));
        SceneManager.LoadScene(2);
    }
}
