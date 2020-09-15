using System.Collections;
using UnityEngine;

public class ShaftMiner : BaseMiner
{
    [SerializeField] private Transform shaftMiningLocation;
    [SerializeField] private Transform shaftDepositLocation;

    private Animator _animator;
    private int _miningAnimationParameter = Animator.StringToHash("Mining");
    private int _walkingAnimationParameter = Animator.StringToHash("Walking");


    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            Move(shaftMiningLocation.position);
        }
    }

    public override void Move(Vector3 newPosition)
    {
        base.Move(newPosition);
        _animator.SetTrigger(_walkingAnimationParameter);
    }

    protected override void CollectGold()
    {
        float collectTime = CollectCapacity / CollectPerSecond;

        _animator.SetTrigger(_miningAnimationParameter);
        StartCoroutine(IECollect(CollectCapacity, collectTime));
    }

    protected override void DepositGold()
    {
        CurrentGold = 0;
        ChangeGoal();
        Rotate(1);
        Move(shaftMiningLocation.position);
    }

    protected override IEnumerator IECollect(int collectGold, float collectTime)
    {
        yield return new WaitForSeconds(collectTime);

        CurrentGold = collectGold;
        ChangeGoal();
        Rotate(-1);
        Move(shaftDepositLocation.position);
    }
}
