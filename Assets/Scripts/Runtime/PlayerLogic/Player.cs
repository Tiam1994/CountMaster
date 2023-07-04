using Runtime.Core.Constants;
using Runtime.GatesLogic;
using Runtime.Stickmans;
using UnityEngine;
using System;

namespace Runtime.PlayerLogic
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private StickmansGroup _stickmansGroup;

		public event Action OnInteractiveWithEnemies;

		private void Start() => _stickmansGroup.Initialize();

		private void OnTriggerEnter(Collider collider)
		{
			InteractiveWithGate(collider);
			InteractiveWithEnemies(collider);
		}

		private void InteractiveWithGate(Collider collider)
		{
			if (collider.tag == ConstantsTag.GATE_TAG)
			{
				collider.transform.parent.GetComponent<Gates>().DeactivateGates();

				int numberOfNewStickmans = GetNumberOfNewStickmens(collider.GetComponent<Gate>());
				_stickmansGroup.MakeStickmans(_stickmansGroup.NumberOfStickmans, numberOfNewStickmans, Quaternion.identity);
			}
		}

		private void InteractiveWithEnemies(Collider collider)
		{
			if(collider.tag == ConstantsTag.ENEMIES_TAG)
			{
				OnInteractiveWithEnemies?.Invoke();
			}
		}

		private int GetNumberOfNewStickmens(Gate gate)
		{
			if (gate.IsMultiply)
			{
				return _stickmansGroup.NumberOfStickmans * gate.Number;
			}
			else
			{
				return _stickmansGroup.NumberOfStickmans + gate.Number;
			}
		}
	}
}
