using UnityEngine;
using TMPro;

public class ShaftUI : MonoBehaviour {
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

    private void UpgradeShaft(BaseUpgrade upgrade, int currentLevel) {
        if (upgrade == _shaftUpgrade)
            currentLevelText.SetText($"Level\n{currentLevel.ToString()}");
    }

}
