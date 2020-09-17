using System.Collections.Generic;
using UnityEngine;

public class Warehouse : MonoBehaviour {
    [Header("Prefab")]
    [SerializeField] private GameObject warehouseMinerPrefab;

    [Header("Extras")]
    [SerializeField] private Deposit elevatorDeposit;
    [SerializeField] private Transform elevatorLocation;
    [SerializeField] private Transform warehouseDepositLocation;
    [SerializeField] private List<WarehouseMiner> miners;

    private void Start() {
        miners = new List<WarehouseMiner>();
        AddMiner();
    }

    public void AddMiner() {
        GameObject newMiner = Instantiate(warehouseMinerPrefab, warehouseDepositLocation.position, Quaternion.identity);
        WarehouseMiner miner = newMiner.GetComponent<WarehouseMiner>();
        miner.ElevatorDeposit = elevatorDeposit;
        miner.ElevatorDepositLocation = elevatorLocation;
        miner.WarehouseDepositLocation = warehouseDepositLocation;

        miners.Add(miner);
    }

}
