using UnityEngine;
using TMPro;

public class ShaftUI : MonoBehaviour {

    [Header("Buttons")]
    [SerializeField] private GameObject buyNewShaftButton;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI currentGoldText;
    [SerializeField] private TextMeshProUGUI currentLevelText;

    private Shaft _shaft;
    private ShaftUpgrade _shaftUpgrade;

    private void Awake() {
        _shaft = GetComponent<Shaft>();
        _shaftUpgrade = GetComponent<ShaftUpgrade>();
    }

    private void OnEnable() {
        ShaftUpgrade.OnUpgrade += UpgradeShaft;
    }

    private void OnDisable() {
        ShaftUpgrade.OnUpgrade -= UpgradeShaft;
    }

    private void Update() {
        currentGoldText.SetText(_shaft.CurrentDeposit.CurrentGold.ToString());
    }

    public void BuyNewShaft() {
        if (GoldManager.Instance.CurrentGold >= ShaftManager.Instance.NewShaftCost) {
            GoldManager.Instance.RemoveGold(ShaftManager.Instance.NewShaftCost);
            ShaftManager.Instance.AddShaft();
            buyNewShaftButton.SetActive(false);
        }
    }

    private void UpgradeShaft(BaseUpgrade upgrade, int currentLevel) {
        if (upgrade == _shaftUpgrade)
            currentLevelText.SetText($"Level\n{currentLevel.ToString()}");
    }

}
