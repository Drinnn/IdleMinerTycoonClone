using System.Collections;
using System.Collections.Generic;
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
            Move(new Vector3(ElevatorDepositLocation.position.x, transform.position.y, transform.position.z));
        }
    }

    public override void Move(Vector3 newPosition) {
        base.Move(newPosition);
        _animator.SetBool(_walkingNoGold, true);
    }

    protected override void CollectGold() {
        if (ElevatorDeposit.CurrentGold <= 0) {
            Rotate(1);
            ChangeGoal();
            Move(new Vector3(WarehouseDepositLocation.position.x, transform.position.y, transform.position.z));
            return;
        }
        _animator.SetBool(_walkingNoGold, false);
        _animator.SetBool(_walkingWithGold, true);

        int currentGold = ElevatorDeposit.CollectGold(this);
        float collectTime = CollectCapacity / CollectPerSecond;
        StartCoroutine(IECollect(currentGold, collectTime));
    }

    protected override IEnumerator IECollect(int collectGold, float collectTime) {
        yield return new WaitForSeconds(collectTime);

        CurrentGold = collectGold;
        ElevatorDeposit.RemoveGold(collectGold);

        Rotate(1);
        ChangeGoal();
        Move(new Vector3(WarehouseDepositLocation.position.x, transform.position.y, transform.position.z));
    }
}
