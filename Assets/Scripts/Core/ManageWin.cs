// Marcos Acedo 006884833 Team StrawHat //
using UnityEngine;
using UnityEngine.SceneManagement;
public class ManageWin : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene("Level1"); // Restarts level //
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu"); // Takes you back to main menu //
    }
}
