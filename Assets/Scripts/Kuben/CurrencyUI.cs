using UnityEngine;
using TMPro;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinText;

    private void Start()
    {
        //Make sure the Manager exists
        if (CurrencyManager.Instance != null)
        {
            //Update the text immediately when the game starts
            UpdateCoinText(CurrencyManager.Instance.Currency);
        }
    }

    private void OnEnable()
    {
        //Listen for the "OnCurrencyChanged" event
        //Whenever the manager shouts that money changed, run UpdateCoinText
        if (CurrencyManager.Instance != null)
        {
            CurrencyManager.Instance.OnCurrencyChanged += UpdateCoinText;
        }
    }

    private void OnDisable()
    {
        //Stop listening when this object is turned off
        //This prevents errors when changing scenes or quitting
        if (CurrencyManager.Instance != null)
        {
            CurrencyManager.Instance.OnCurrencyChanged -= UpdateCoinText;
        }
    }

    // This function runs automatically whenever currency changes
    private void UpdateCoinText(double amount)
    {
        //coinText.text = amount.ToString("N0");
        coinText.text = "$" + amount.ToString("N0");
    }
}