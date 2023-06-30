using UnityEngine;

namespace Runtime.PlayerLogic
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private Transform _playerTransform;
		
		[SerializeField] private float _lateralMoveSpeed;
		[SerializeField] private float _straightMoveSpeed;

		[SerializeField] private bool _isMoving;

		private void Update()
		{
			if (_isMoving)
			{
				StraightMove();
				LateralMove();
			}
		}

		private void StraightMove()
		{
			_playerTransform.Translate(Vector3.forward * _straightMoveSpeed * Time.deltaTime);
		}

		private void LateralMove()
		{
			if(Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);
				float halfScreen = Screen.width / 2;
				float xPosition = (touch.position.x - halfScreen) / halfScreen;

				_playerTransform.localPosition = new Vector3(xPosition * _lateralMoveSpeed, _playerTransform.localPosition.y, _playerTransform.localPosition.z);
			}
		}
	}
}
