using DG.Tweening;
using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace FindDifferences.UI
{
    public class EndGamePopUp : MonoBehaviour, IInitializable, IRestartInput
    {
        [SerializeField] private Image _rayCastBlockImage;
        [SerializeField] private RectTransform _popUpPanelTransform;
        [SerializeField] private TextMeshProUGUI _endGameLabel;
        [SerializeField] private TextMeshProUGUI _timeLabel;
        [Space]
        [SerializeField] private string _winMessage;
        [SerializeField] private string _lostMessage;
        [Space]
        [SerializeField] private float _inSpeed = 2f;
        [SerializeField] private Ease _InEase;
        [SerializeField] private float _outSpeed = 2f;
        [SerializeField] private Ease _OutEase;
        [Space]
        [SerializeField] private Button _restartBttn;

        public event Action RestartPressed;

        private Tweener _appearTweener;
        private Tweener _disappearTweener;

        private Vector2 _startPosition;

        private void OnEnable()
        {
            _restartBttn.onClick.AddListener(RestartBttnClicked);
        }

        private void OnDisable()
        {
            _restartBttn.onClick.RemoveListener(RestartBttnClicked);
        }

        public void Initialize()
        {
            BlockRayCastEnable(false);
            _startPosition = _popUpPanelTransform.position;
            _appearTweener.SetAutoKill(false);
            _disappearTweener.SetAutoKill(false);
        }

        public void Show(EndGameData data)
        {
            BlockRayCastEnable(true);
            SetPanelState(data);
            _appearTweener = _popUpPanelTransform.DOMove(Vector2.zero, _inSpeed).SetEase(_InEase);
        }

        [ContextMenu("Hide")]
        public void Hide()
        {
            BlockRayCastEnable(false);
            _disappearTweener = _popUpPanelTransform.DOMove(_startPosition, _inSpeed).SetEase((_OutEase));
        }

        private void BlockRayCastEnable(bool isEnable) => _rayCastBlockImage.enabled = isEnable;

        private void RestartBttnClicked()
        {
            RestartPressed?.Invoke();
        }
        private void SetPanelState(EndGameData data)
        {
            _endGameLabel.text = data.IsWin ? _winMessage : _lostMessage;
            _timeLabel.enabled = data.IsWin;
            _timeLabel.text = data.IsWin ? data.Time : string.Empty;
        }

        private void OnDestroy()
        {
            _appearTweener.Kill();
            _disappearTweener.Kill();
        }
    }
}
