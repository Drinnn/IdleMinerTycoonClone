using System.Collections;
using UnityEngine;

public class ShaftMiner : BaseMiner {
    public Shaft CurrentShaft { get; set; }

    private int _miningAnimationParameter = Animator.StringToHash("Mining");
    private int _walkingAnimationParameter = Animator.StringToHash("Walking");

    public override void Move(Vector3 newPosition) {
        base.Move(newPosition);
        _animator.SetTrigger(_walkingAnimationParameter);
    }

    protected override void CollectGold() {
        float collectTime = CollectCapacity / CollectPerSecond;

        _animator.SetTrigger(_miningAnimationParameter);
        StartCoroutine(IECollect(CollectCapacity, collectTime));
    }

    protected override void DepositGold() {
        CurrentShaft.CurrentDeposit.DepositGold(CurrentGold);

        CurrentGold = 0;
        ChangeGoal();
        Rotate(1);
        Move(CurrentShaft.MiningLocation.position);
    }

    protected override IEnumerator IECollect(int collectGold, float collectTime) {
        yield return new WaitForSeconds(collectTime);

        CurrentGold = collectGold;
        ChangeGoal();
        Rotate(-1);
        Move(CurrentShaft.DepositLocation.position);
    }
}
