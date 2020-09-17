using UnityEngine;
using TMPro;

public class WarehouseUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI globalGoldText;

    private void Update() {
        globalGoldText.SetText(GoldManager.Instance.CurrentGold.ToString());
    }
}
