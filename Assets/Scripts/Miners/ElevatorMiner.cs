using System.Collections;
using UnityEngine;

public class ElevatorMiner : BaseMiner {
    [SerializeField] private Elevator elevator;

    private int _currentShaftIndex = -1;
    private Deposit _currentDeposit;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.N)) {
            MoveToNextLocation();
        }
    }

    public void MoveToNextLocation() {
        _currentShaftIndex++;

        Shaft currentShaft = ShaftManager.Instance.Shafts[_currentShaftIndex];
        Vector2 nextPosition = new Vector2(transform.position.x, currentShaft.DepositLocation.position.y);

        _currentDeposit = currentShaft.CurrentDeposit;

        Move(nextPosition);
    }

    protected override void CollectGold() {
        if (!_currentDeposit.CanCollectGold() && _currentShaftIndex == ShaftManager.Instance.Shafts.Count - 1) {
            _currentShaftIndex = -1;
            Vector3 elevatorDepositPosition = new Vector3(transform.position.x, elevator.DepositLocation.position.y, transform.position.z);
            Move(elevatorDepositPosition);
            return;
        }

        int amountToCollect = _currentDeposit.CollectGold(this);
        float collectTime = amountToCollect / CollectPerSecond;
        StartCoroutine(IECollect(amountToCollect, collectTime));
    }

    protected override IEnumerator IECollect(int collectGold, float collectTime) {
        yield return new WaitForSeconds(collectTime);

        CurrentGold = collectGold;
        _currentDeposit.RemoveGold(collectGold);

        yield return new WaitForSeconds(0.5f);

        if (CurrentGold == CollectCapacity || _currentShaftIndex == ShaftManager.Instance.Shafts.Count - 1) {
            _currentShaftIndex = -1;
            ChangeGoal();

            Vector3 elevatorDepositPosition = new Vector3(transform.position.x, elevator.DepositLocation.position.y, transform.position.z);
            Move(elevatorDepositPosition);
        } else {
            MoveToNextLocation();
        }
    }
}
