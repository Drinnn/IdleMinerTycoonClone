using System.Collections;
using UnityEngine;

public class WarehouseMiner : BaseMiner {
    public Deposit ElevatorDeposit { get; set; }
    public Transform ElevatorDepositLocation { get; set; }
    public Transform WarehouseDepositLocation { get; set; }

    private readonly int _walkingNoGold = Animator.StringToHash("WalkingNoGold");
    private readonly int _walkingWithGold = Animator.StringToHash("WalkingWithGold");


    private void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            Rotate(-1);
            _animator.SetBool(_walkingNoGold, true);
            Move(new Vector3(ElevatorDepositLocation.position.x, transform.position.y, transform.position.z));
        }
    }

    protected override void CollectGold() {
        if (ElevatorDeposit.CurrentGold <= 0) {
            Rotate(1);
            ChangeGoal();
            Move(new Vector3(WarehouseDepositLocation.position.x, transform.position.y, transform.position.z));
            return;
        }
        _animator.SetBool(_walkingNoGold, false);

        int currentGold = ElevatorDeposit.CollectGold(this);
        float collectTime = CollectCapacity / CollectPerSecond;
        StartCoroutine(IECollect(currentGold, collectTime));
    }

    protected override IEnumerator IECollect(int collectGold, float collectTime) {
        yield return new WaitForSeconds(collectTime);

        CurrentGold = collectGold;
        ElevatorDeposit.RemoveGold(collectGold);
        _animator.SetBool(_walkingWithGold, true);

        Rotate(1);
        ChangeGoal();
        Move(new Vector3(WarehouseDepositLocation.position.x, transform.position.y, transform.position.z));
    }

    protected override void DepositGold() {
        if (CurrentGold <= 0) {
            Rotate(-1);
            ChangeGoal();
            Move(new Vector3(ElevatorDepositLocation.position.x, transform.position.y, transform.position.z));
            return;
        }

        _animator.SetBool(_walkingWithGold, false);
        _animator.SetBool(_walkingNoGold, false);

        float depositTime = CurrentGold / CollectPerSecond;
        StartCoroutine(IEDeposit(CurrentGold, depositTime));
    }

    protected override IEnumerator IEDeposit(int collectedGold, float depositTime) {
        yield return new WaitForSeconds(depositTime);

        GoldManager.Instance.AddGold(CurrentGold);
        CurrentGold = 0;

        Rotate(-1);
        ChangeGoal();
        Move(new Vector3(ElevatorDepositLocation.position.x, transform.position.y, transform.position.z));
    }
}
