using UnityEngine;

public class GoldManager : MonoBehaviour {
    public static GoldManager Instance;

    public int CurrentGold { get; set; }

    [SerializeField] private int testGold = 0;

    private readonly string GOLD_KEY = "GoldKey";

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        LoadGold();
    }

    private void LoadGold() {
        CurrentGold = PlayerPrefs.GetInt(GOLD_KEY, testGold);
    }

    public void AddGold(int amount) {
        CurrentGold += amount;
        SaveGold();
    }

    public void RemoveGold(int amount) {
        CurrentGold -= amount;
        SaveGold();
    }

    private void SaveGold() {
        PlayerPrefs.SetInt(GOLD_KEY, CurrentGold);
        PlayerPrefs.Save();
    }

}
