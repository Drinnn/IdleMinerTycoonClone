using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LoadBar : MonoBehaviour {
    public Transform BarContainer { get; set; }

    [SerializeField] private GameObject loadingBarPrefab;
    [SerializeField] private Transform loadingBarPosition;

    private Image _fillImage;
    private BaseMiner _miner;
    private GameObject _barCanvas;

    private void OnEnable() {
        BaseMiner.OnLoading += LoadingBar;
    }

    private void OnDisable() {
        BaseMiner.OnLoading -= LoadingBar;
    }

    private void Start() {
        _miner = GetComponent<BaseMiner>();
        CreateLoadBar();

        BarContainer = _barCanvas.transform;
    }

    private void CreateLoadBar() {
        _barCanvas = Instantiate(loadingBarPrefab, loadingBarPosition.position, Quaternion.identity);
        _barCanvas.transform.SetParent(transform);
        _fillImage = _barCanvas.transform.GetChild(0).transform.GetChild(0).GetComponent<Image>();
    }

    private void LoadingBar(BaseMiner minerSender, float duration) {
        if (minerSender == _miner) {
            _barCanvas.SetActive(true);
            _fillImage.fillAmount = 0f;

            _fillImage.DOFillAmount(1f, duration).OnComplete((() => _barCanvas.SetActive(false)));
        }
    }
}
