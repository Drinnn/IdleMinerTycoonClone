﻿using UnityEngine;

public class ShaftUpgrade : BaseUpgrade {
    protected override void RunUpgrade() {
        if (_shaft != null) {
            foreach (ShaftMiner miner in _shaft.Miners) {
                miner.CollectCapacity *= (int)collectCapacityMultiplier;
                miner.CollectPerSecond *= collectPerSecondMultiplier;

                if (CurrentLevel % 10 == 0)
                    miner.MoveSpeed *= moveSpeedMultiplier;
            }
        }
    }
}
