using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Runtime.Stickmans
{
	public class StickmansGroup : MonoBehaviour
	{
		[SerializeField] private GameObject _stickmanPrefab;
		[SerializeField] private List<Stickman> _stickmans;

		[Range(0, 1)][SerializeField] private float _distanceFactor;
		[Range(0, 1)][SerializeField] private float _radius;

		public int NumberOfStickmans { get { return _stickmans.Count; } }

		public void Initialize()
		{
			_stickmans = new List<Stickman>();

			for (int i = 0; i < transform.childCount; i++)
			{
				_stickmans.Add(transform.GetChild(i).GetComponent<Stickman>());
			}
		}

		public void MakeStickmans(int currentNumberOfStickmans, int number, Quaternion rotation)
		{
			for (int i = currentNumberOfStickmans; i < number; i++)
			{
				Stickman stickman = Instantiate(_stickmanPrefab, transform.position, rotation, transform).GetComponent<Stickman>();
				_stickmans.Add(stickman);
			}

			FormatStickmans();
		}

		private void FormatStickmans()
		{
			for (int i = 0; i < transform.childCount; i++)
			{
				var x = _distanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i * _radius);
				var z = _distanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i * _radius);

				var NewPos = new Vector3(x, 0, z);

				transform.transform.GetChild(i).DOLocalMove(NewPos, 0.5f).SetEase(Ease.OutBack);
			}
		}
	}
}
