using Runtime.Core.Constants;
using Runtime.GatesLogic;
using Runtime.Stickmans;
using UnityEngine;

namespace Runtime.PlayerLogic
{
	public class Player : MonoBehaviour
	{
		[SerializeField] private StickmansGroup _stickmansGroup;

		private void Start() => _stickmansGroup.Initialize();

		private void OnTriggerEnter(Collider collider)
		{
			InteractiveWithGate(collider);
		}

		private void InteractiveWithGate(Collider collider)
		{
			if (collider.tag == ConstantsTag.GATE_TAG)
			{
				collider.transform.parent.GetComponent<Gates>().DeactivateGates();

				int numberOfNewStickmans = GetNumberOfNewStickmens(collider.GetComponent<Gate>());
				_stickmansGroup.MakeStickmans(_stickmansGroup.NumberOfStickmans, numberOfNewStickmans);
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
