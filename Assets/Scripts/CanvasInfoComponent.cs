using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasInfoComponent : MonoBehaviour
{
	[SerializeField] private Image _healthBar;
	[SerializeField] private TextMeshProUGUI _scoreCountLabel;

	public void UpdateScore(int score, int damage)
	{
		_scoreCountLabel.text = $"{score}    {damage}";
	}

	public void UpdateHealthBar(int health)
	{
		_healthBar.fillAmount = health/100.00f;
	}
}
