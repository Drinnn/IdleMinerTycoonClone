using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShaftManager : MonoBehaviour {
    public static ShaftManager Instance;

    public int NewShaftCost => newShaftCost;

    [SerializeField] private Shaft shaftPrefab;
    [SerializeField] private float newShaftYPosition;
    [SerializeField] private int newShaftCost = 500;

    [Header("Shaft")]
    [SerializeField] private List<Shaft> shafts;

    private void Awake() {
        Instance = this;
    }

    public void AddShaft() {
        Transform lastShaft = shafts[0].transform;
        Shaft newShaft = Instantiate(shaftPrefab, new Vector3(lastShaft.position.x, lastShaft.position.y - newShaftYPosition, lastShaft.position.z),
                                        Quaternion.identity);
        shafts.Add(newShaft);
    }

}
