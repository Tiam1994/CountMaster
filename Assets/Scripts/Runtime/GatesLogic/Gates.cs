using UnityEngine;

namespace Runtime.GatesLogic
{
	public class Gates : MonoBehaviour
	{
		[SerializeField] private Gate _leftGate;
		[SerializeField] private Gate _rightGate;

		public void DeactivateGates()
		{
			_leftGate.DeactivateGate();
			_rightGate.DeactivateGate();
		}
	}
}
