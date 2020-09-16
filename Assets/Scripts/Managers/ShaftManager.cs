using System.Collections.Generic;
using UnityEngine;

public class ShaftManager : Singleton<ShaftManager> {
    public List<Shaft> Shafts => shafts;
    public int NewShaftCost => newShaftCost;

    [SerializeField] private Shaft shaftPrefab;
    [SerializeField] private float newShaftYPosition;
    [SerializeField] private int newShaftCost = 500;

    [Header("Shaft")]
    [SerializeField] private List<Shaft> shafts;

    public void AddShaft() {
        Transform lastShaft = shafts[shafts.Count - 1].transform;
        Shaft newShaft = Instantiate(shaftPrefab, new Vector3(lastShaft.position.x, lastShaft.position.y - newShaftYPosition, lastShaft.position.z),
                                        Quaternion.identity);
        shafts.Add(newShaft);
    }

}
