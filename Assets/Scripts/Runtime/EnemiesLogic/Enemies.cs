using Runtime.Stickmans;
using UnityEngine;

namespace Runtime.EnemiesLogic
{
	[RequireComponent(typeof(BoxCollider))]
	public class Enemies : MonoBehaviour
	{
		[SerializeField] private StickmansGroup _stickmansGroup;

		private Quaternion _rotation = new Quaternion(0f, 180f, 0f, 1f);

		private void Start()
		{
			_stickmansGroup.Initialize();
			_stickmansGroup.MakeStickmans(_stickmansGroup.NumberOfStickmans, GetRandomNumber(10,120), _rotation);
		}

		private int GetRandomNumber(int minNumber, int maxNumber)
		{
			return Random.Range(minNumber, maxNumber);
		}
	}
}
