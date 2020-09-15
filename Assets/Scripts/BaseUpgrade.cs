using System;
using UnityEngine;

public class BaseUpgrade : MonoBehaviour {
    public int CurrentLevel { get; set; }
    public float UpgradeCost { get; set; }

    public static Action<BaseUpgrade, int> OnUpgrade;

    [Header("Upgrades")]
    [SerializeField] protected float collectCapacityMultiplier = 2f;
    [SerializeField] protected float collectPerSecondMultiplier = 2f;
    [SerializeField] protected float moveSpeedMultiplier = 1.25f;

    [Header("Costs")]
    [SerializeField] private float initialUpgradeCost = 200f;
    [SerializeField] private float upgradeCostMultiplier = 1.25f;

    protected Shaft _shaft;

    private void Start() {
        _shaft = GetComponent<Shaft>();

        CurrentLevel = 1;
        UpgradeCost = initialUpgradeCost;
    }

    public virtual void Upgrade(int upgradeAmount) {
        if (upgradeAmount > 0) {
            for (int i = 0; i < upgradeAmount; i++) {
                UpgradeSuccess();
                UpdateUpgradeValues();
                RunUpgrade();
            }
        }
    }

    protected virtual void UpgradeSuccess() {
        CurrentLevel++;
        OnUpgrade?.Invoke(this, CurrentLevel);
    }

    protected virtual void UpdateUpgradeValues() {
        UpgradeCost *= upgradeCostMultiplier;
    }

    protected virtual void RunUpgrade() {

    }
}
