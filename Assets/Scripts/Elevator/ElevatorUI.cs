using UnityEngine;
using TMPro;

public class ElevatorUI : MonoBehaviour {
    [SerializeField] private TextMeshProUGUI elevatorDepositGoldText;

    private Elevator _elevator;

    private void Start() {
        _elevator = GetComponent<Elevator>();
    }

    private void Update() {
        elevatorDepositGoldText.SetText(_elevator.ElevatorDeposit.CurrentGold.ToString());
    }
}
