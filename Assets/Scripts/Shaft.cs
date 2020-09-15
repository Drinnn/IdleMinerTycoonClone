using UnityEngine;

public class Shaft : MonoBehaviour {

    public Transform MiningLocation => miningLocation;
    public Transform DepositLocation => depositLocation;


    [Header("Prefab")]
    [SerializeField] private ShaftMiner minerPrefab;

    [Header("Locations")]
    [SerializeField] private Transform miningLocation;
    [SerializeField] private Transform depositLocation;

    private void Start() {
        CreateMiner();
    }

    private void CreateMiner() {
        ShaftMiner newMiner = Instantiate(minerPrefab, depositLocation.position, Quaternion.identity);
        newMiner.CurrentShaft = this;

        newMiner.Move(miningLocation.position);
    }
}
