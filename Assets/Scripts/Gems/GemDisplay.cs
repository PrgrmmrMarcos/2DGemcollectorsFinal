//Marcos Acedo 006884833 Team StrawHat // 
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class GemDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI rupeeText;


    private void OnEnable()
    {
        
         InventoryManager inventoryManager = FindObjectOfType<InventoryManager>();
        if (inventoryManager != null)
        {
       
            inventoryManager.OnGemsUpdated += UpdateUI;
        }
    }

    public void UpdateUI(int gems)
    {
        rupeeText.text = "Rupees: " + gems;
    }
}
