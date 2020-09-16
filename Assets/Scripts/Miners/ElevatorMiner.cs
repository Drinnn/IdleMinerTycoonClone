using UnityEngine;

public class ElevatorMiner : BaseMiner {
    private int _currentShaftIndex = 0;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.N)) {
            MoveToNextLocation();
        }
    }

    public void MoveToNextLocation() {
        Shaft currentShaft = ShaftManager.Instance.Shafts[_currentShaftIndex];
        Vector2 nextPosition = new Vector2(transform.position.x, currentShaft.DepositLocation.position.y);

        Move(nextPosition);
    }
}
