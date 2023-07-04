using UnityEngine;

namespace Runtime.PlayerLogic
{
	public class PlayerController : MonoBehaviour
	{
		[SerializeField] private Player _player;
		
		[SerializeField] private float _lateralMoveSpeed;
		[SerializeField] private float _straightMoveSpeed;

		[SerializeField] private bool _isMoving;

		private void OnEnable()
		{
			_player.OnInteractiveWithEnemies += SwitchIsMoving;
		}

		private void OnDisable()
		{
			_player.OnInteractiveWithEnemies -= SwitchIsMoving;
		}

		private void Update()
		{
			if (_isMoving)
			{
				StraightMove();
				LateralMove();
			}
		}

		private void SwitchIsMoving()
		{
			if(_isMoving)
			{
				_isMoving = false;
			}
			else
			{
				_isMoving = true;
			}
		}

		private void StraightMove()
		{
			_player.transform.Translate(Vector3.forward * _straightMoveSpeed * Time.deltaTime);
		}

		private void LateralMove()
		{
			if(Input.touchCount > 0)
			{
				Touch touch = Input.GetTouch(0);
				float halfScreen = Screen.width / 2;
				float xPosition = (touch.position.x - halfScreen) / halfScreen;

				_player.transform.localPosition = new Vector3(xPosition * _lateralMoveSpeed, _player.transform.localPosition.y, _player.transform.localPosition.z);
			}
		}
	}
}
