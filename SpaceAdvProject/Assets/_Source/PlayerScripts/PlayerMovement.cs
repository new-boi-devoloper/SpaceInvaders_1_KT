using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovement
    {
        public void Move(Rigidbody2D playerRb, float moveDirection, float playerSpeed)
        {
            playerRb.position += new Vector2(moveDirection * (playerSpeed * Time.deltaTime), 0);
        }
    }
}