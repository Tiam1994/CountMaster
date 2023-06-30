using UnityEngine;
using TMPro;

namespace Runtime.GatesLogic
{
	[RequireComponent(typeof(BoxCollider))]
	public class Gate : MonoBehaviour
	{
		[SerializeField] private TMP_Text _numberText;
		[SerializeField] private bool _isMultiply;

		private BoxCollider _gateCollider;
		private int _number;

		private void Start()
		{
			Initialize();
			GenerateRandomNumber();
		}

		private void Initialize() => _gateCollider = GetComponent<BoxCollider>();

		private void GenerateRandomNumber()
		{
			if (_isMultiply)
			{
				_number = Random.Range(1, 3);
				_numberText.text = $"X{_number}";
			}
			else
			{
				_number = Random.Range(10, 100);

				if (_number % 2 != 0)
				{
					_number += 1;
				}

				_numberText.text = $"+{_number}";
			}
		}

		public void DeactivateGate() => _gateCollider.enabled = false;
	}
}
