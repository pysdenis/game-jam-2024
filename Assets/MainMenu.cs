using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Funkce pro načtení nové hry (nové scény)
    public void NewGame()
    {
        SceneManager.LoadScene("SampleScene"); 
    }

    // Funkce pro pokračování ve hře
    public void ContinueGame()
    {
        // TODO savings
        SceneManager.LoadScene("SampleScene");
    }

    // Funkce pro zavření aplikace
    public void QuitGame()
    {
        // Zavře aplikaci
        Application.Quit();
        // Pro debugování v editoru:
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}