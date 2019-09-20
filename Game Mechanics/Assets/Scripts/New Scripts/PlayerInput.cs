using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComandPattern
{
    public class PlayerInput : MonoBehaviour
    {
        public Transform player;
        private Command buttonW, buttonA, buttonS, buttonD, buttonShift;
        public static List<Command> oldCommands = new List<Command>();

        void Start()
        {
            buttonW = new MoveForward();
            buttonA = new MoveLeft();
            buttonS = new MoveReverse();
            buttonD = new MoveRight();
            buttonShift = new MoveForwardSprint();
        }

        void Update()
        {
            HandleInput();
        }

        public void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                buttonW.Execute(player, buttonW);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                buttonA.Execute(player, buttonA);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                buttonS.Execute(player, buttonS);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                buttonD.Execute(player, buttonD);
            }
            else if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                buttonShift.Execute(player, buttonShift);
            }
        }
    }
}

