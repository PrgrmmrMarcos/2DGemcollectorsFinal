using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointWin : MonoBehaviour
{
    public static CheckpointWin Instance;

    [SerializeField] private GameObject winScreenUI;

    private Collider2D col;
    private Animator anim;

    private void Awake()
    {
        Instance = this;
        col = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        col.enabled = false;
    }

    public void ActivateCheckpoint()
    {
        col.enabled = true;
        if (anim != null)
            anim.SetTrigger("activate");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.Instance.AllCollected())
        {
            Debug.Log("YOU WIN!");
            SceneManager.LoadScene("WinScreen");
        }
    }
}
