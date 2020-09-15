using UnityEngine;
using TMPro;

public class ShaftUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI currentGoldText;

    private Shaft _shaft;

    private void Awake() {
        _shaft = GetComponent<Shaft>();
    }

    private void Update() {
        currentGoldText.SetText(_shaft.CurrentDeposit.CurrentGold.ToString());
    }
}
