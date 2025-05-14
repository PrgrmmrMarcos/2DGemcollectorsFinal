using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int collected = 0;
    private int totalCollectibles = 10;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void Collect()
    {
        collected++;
        Debug.Log($"Collected: {collected}/{totalCollectibles}");

        if (collected >= totalCollectibles)
        {
            Debug.Log("All collectibles gathered! Activating checkpoint.");
            CheckpointWin.Instance.ActivateCheckpoint();
        }
    }

    public bool AllCollected()
    {
        return collected >= totalCollectibles;
    }
}

