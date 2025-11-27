using UnityEngine;
using System;
using UnityEngine.InputSystem;

[DefaultExecutionOrder(-100)]
public class CurrencyManager : MonoBehaviour
{
    public static CurrencyManager Instance;

    public double Currency { get; private set; } = 0;

    private const string CurrencyKey = "PlayerCurrency";

    //An event the UI can listen to
    public event Action<double> OnCurrencyChanged;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadCurrency();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ResetCurrency()
    {
        Currency = 0;
        NotifyUI();
        SaveCurrency();
    }

    public void AddCurrency(double amount)
    {
        if (amount <= 0) return;

        Currency += amount;

        NotifyUI();
    }

    public bool SpendCurrency(double amount)
    {
        if (amount <= 0) return false;

        if (Currency >= amount)
        {
            Currency -= amount;

            NotifyUI();
            return true;
        }
        return false;
    }

    //Helper function to update UI safely
    private void NotifyUI()
    {
        OnCurrencyChanged?.Invoke(Currency);
    }

    //Save automatically when the player quits the game
    private void OnApplicationQuit()
    {
        SaveCurrency();
    }

    //Save when the app is paused
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) SaveCurrency();
    }

    public void SaveCurrency()
    {
        // PlayerPrefs acts weird with Double, so we convert to String for safety
        PlayerPrefs.SetString(CurrencyKey, Currency.ToString());
        PlayerPrefs.Save();
        Debug.Log("Game Saved!");
    }

    public void LoadCurrency()
    {
        // Load as string and convert back to double
        string s = PlayerPrefs.GetString(CurrencyKey, "0");
        if (double.TryParse(s, out double result))
        {
            Currency = result;
        }
        else
        {
            Currency = 0;
        }
    }

    private void Update()
    {
        //Testing
        //Space bar to add money
        //R to reset money
        if (Keyboard.current == null) return;

        if (Keyboard.current.aKey.wasPressedThisFrame)
        {
            AddCurrency(100);
            Debug.Log("Testing successful! Currency earned successfully. Current Money: " + Currency);
        }
        if (Keyboard.current.dKey.wasPressedThisFrame)
        {
            SpendCurrency(50);
            Debug.Log("Testing successful! Currency spent successfully. Current Money: " + Currency);
        }
            if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            ResetCurrency();
            Debug.Log("Testing successful! Money Successfully reset. Current money: " + Currency);
        }
    }
}