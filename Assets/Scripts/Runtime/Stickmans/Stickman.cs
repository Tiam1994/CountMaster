using UnityEngine;

namespace Runtime.Stickmans
{
	public class Stickman : MonoBehaviour
	{
		private readonly int _toRunParametrHash = Animator.StringToHash("Is Running");
		private Animator _animator;

		private bool _isKilled;

		private void OnEnable() => Initialize();

		private void Initialize() => _animator = GetComponent<Animator>();

		public void PlayRunAnimation() => _animator.SetBool(_toRunParametrHash, true);

		private void OnTriggerEnter(Collider collider)
		{
			if(collider.gameObject.tag == "Enemy" && !_isKilled)
			{
				_isKilled = true;

				Destroy(collider.gameObject);
				Destroy(gameObject);
			}
		}
	}
}
