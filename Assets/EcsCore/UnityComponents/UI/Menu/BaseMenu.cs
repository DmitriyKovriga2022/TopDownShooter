using System.Collections;
using UnityEngine;

public abstract class BaseMenu : MonoBehaviour
{
	[SerializeField] private CanvasGroup canvasGroup;
	[SerializeField] protected float _fadeTime = 0.2f;
	[SerializeField] protected bool _lerpOnPause = false;

	public virtual void Hide()
	{
		StopAllCoroutines();

		if (gameObject.activeSelf == false) return;

		canvasGroup.alpha = 1f;

		if ((Time.timeScale <= 0f && _lerpOnPause == true) || Time.timeScale > 0f)
		{
			this.LerpCoroutine(time: _fadeTime,
							   from: canvasGroup.alpha,
							   to: 0f,
							   action: a => canvasGroup.alpha = a,
							   onEnd: () => DisableGameObject(),
							   settings: new CoroutineTemplate.Settings(lerpOnPause: _lerpOnPause)
							   );
		}
		else
		{
			StopAllCoroutines();

			if (gameObject.activeSelf == false) return;

			canvasGroup.alpha = 1f;

			if ((Time.timeScale <= 0f && _lerpOnPause == true) || Time.timeScale > 0f)
			{
				this.LerpCoroutine(time: _fadeTime,
								   from: canvasGroup.alpha,
								   to: 0f,
								   action: a => canvasGroup.alpha = a,
								   onEnd: () => DisableGameObject(),
								   settings: new CoroutineTemplate.Settings(lerpOnPause: _lerpOnPause)
								   );
			}
			else
			{
				DisableGameObject();
			}
		}
	}

    public virtual void Show()
    {
		StopAllCoroutines();

		canvasGroup.alpha = 0f;
		gameObject.SetActive(true);
		if ((Time.timeScale <= 0f && _lerpOnPause == true) || Time.timeScale > 0f)
		{
			this.LerpCoroutine(time: _fadeTime,
							   from: canvasGroup.alpha,
							   to: 1f,
							   action: a => canvasGroup.alpha = a,
							   settings: new CoroutineTemplate.Settings(lerpOnPause: _lerpOnPause)
							   );
		}
		else
		{
			canvasGroup.alpha = 1f;
		}
    }

	private void DisableGameObject()
	{
		canvasGroup.alpha = 0f;
		gameObject.SetActive(false);
	}
}