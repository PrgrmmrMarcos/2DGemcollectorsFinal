// Marcos Acedo 006884833 Team StrawHat //
// This code is an adaptation of the code from pg.215 of our textbook //
// "Unity In Action 3rd edition" By Joseph Hocking //
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class InventoryManager : MonoBehaviour, IGameManager 
{
  public int gems = 0;
  public int goal = 3;

    public delegate void GemsUpdated(int gems);
    public event GemsUpdated OnGemsUpdated;

    public ManagerStatus status { get; private set; }

    public void Startup()
    {
        Debug.Log("Inventory manager starting...");
        gems = 0;
        status = ManagerStatus.Started;
    }

    private void DisplayItems()
    {
        Debug.Log($"Gems Collected: {gems}");
    }

    public void AddItem(string itemName)
    {
        gems++;
        Debug.Log($"Gem Collected");

        OnGemsUpdated?.Invoke(gems);

        if (gems >= goal)
        {
            EndGame();
        }
    }

private void EndGame()
{
    Debug.Log("You collected 10 Rupees! Congrats !");
    
    SceneManager.LoadScene("MainMenu");
}
}
