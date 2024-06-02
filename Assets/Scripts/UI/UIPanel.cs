using UnityEngine;
using UnityEngine.Events;

namespace Defence.UI{
    /// <summary>
    /// Describes behaviour of the all UI panels in game
    /// UI menu must be inherited from this class
    ///</summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class UIPanel : MonoBehaviour
    {
        public float display_speed = 4f;

        public UnityAction onShow;
        public UnityAction onHide;

        private CanvasGroup _canvas_group;

        private bool _visible;

        protected void Awake() {
            _canvas_group = GetComponent<CanvasGroup>();
            _canvas_group.alpha = 0f;
            _visible = false;
        }

        protected virtual void Update() {

            float add = _visible ? display_speed : -display_speed;
            float alpha = Mathf.Clamp01(_canvas_group.alpha + add * Time.deltaTime);
            _canvas_group.alpha = alpha;

            if (!_visible && alpha < 0.01f)
                AfterHide();
        }

        public virtual void Toggle(bool instant = false) {
            if (IsVisible())
                Hide(instant);
            else
                Show(instant);
        }

        public virtual void Show(bool instant = false) {
            _visible = true;
            gameObject.SetActive(true);

            if (instant || display_speed < 0.01f)
                _canvas_group.alpha = 1f;
                _canvas_group.blocksRaycasts = true;

            if (onShow != null)
                onShow.Invoke();
        }

        public virtual void Hide(bool instant = false) {
            _visible = false;
            if (instant || display_speed < 0.01f)
                _canvas_group.alpha = 0f;
                _canvas_group.blocksRaycasts = false;

            if (onHide != null)
                onHide.Invoke();
        }

        public void SetVisible(bool visi) {
            if (!_visible && visi)
                Show();
            else if (_visible && !visi)
                Hide();
        }

        public virtual void AfterHide() {
            gameObject.SetActive(false);
        }

        public bool IsVisible() {
            return _visible;
        }

        public bool IsFullyVisible() {
            return _visible && _canvas_group.alpha > 0.99f;
        }

        public bool IsFullyHidden() {
            return !_visible && !gameObject.activeSelf;
        }

        public float GetAlpha() {
            return _canvas_group.alpha;
        }
    }
}
