using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public GameObject botao;

    private void Start()
    {
        StartCoroutine(CriaBotao());
        Cursor.lockState = CursorLockMode.None;
    }

    IEnumerator CriaBotao()
    {
        yield return new WaitForSeconds(5f);
        botao.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

    public void RestartFullGame()
    {
        SceneManager.LoadScene(0);
    }
}
