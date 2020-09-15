using System.Collections;
using UnityEngine;
using DG.Tweening;

public class BaseMiner : MonoBehaviour {
    public int CurrentGold { get; set; }
    public int CollectCapacity { get; set; }
    public float CollectPerSecond { get; set; }
    public bool IsTimeToCollect { get; set; }

    private float _moveSpeed = 5f;
    private int _initialCollectCapacity = 200;
    private float _goldCollectPerSecond = 50f;

    private void Awake() {
        CollectCapacity = _initialCollectCapacity;
        CollectPerSecond = _goldCollectPerSecond;
        IsTimeToCollect = true;
    }

    public virtual void Move(Vector3 newPosition) {
        transform.DOMove(newPosition, 10 / _moveSpeed).OnComplete((() => {
            if (IsTimeToCollect)
                CollectGold();
            else
                DepositGold();
        })).Play();
    }

    public void ChangeGoal() {
        IsTimeToCollect = !IsTimeToCollect;
    }

    public void Rotate(int direction) {
        transform.localScale = new Vector3(direction, transform.localScale.y, transform.localScale.y);
    }
    protected virtual void CollectGold() {

    }

    protected virtual void DepositGold() {

    }

    protected virtual IEnumerator IECollect(int collectGold, float collectTime) {
        yield return null;
    }
}
