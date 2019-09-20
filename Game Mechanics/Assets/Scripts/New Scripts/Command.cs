using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ComandPattern
{
    public abstract class Command
    {
        protected float moveDistance = 1f;
        public abstract void Execute(Transform player, Command command);
        public virtual void Move(Transform player) { }
        public virtual void Undo(Transform player) { }
    }

    public class MoveForward : Command
    {
        public override void Execute(Transform player, Command command)
        {
            Move(player);

            PlayerInput.oldCommands.Add(command);
        }

        public override void Undo(Transform player)
        {
            player.Translate(-player.forward * moveDistance);
        }

        public override void Move(Transform player)
        {
            player.Translate(player.forward * moveDistance);
        }
    }

    public class MoveReverse : Command
    {
        public override void Execute(Transform player, Command command)
        {
            Move(player);

            PlayerInput.oldCommands.Add(command);
        }

        public override void Undo(Transform player)
        {
            player.Translate(player.forward * moveDistance);
        }

        public override void Move(Transform player)
        {
            player.Translate(-player.forward * moveDistance);
        }
    }

    public class MoveLeft : Command
    {
        public override void Execute(Transform player, Command command)
        {
            Move(player);

            PlayerInput.oldCommands.Add(command);
        }

        public override void Undo(Transform player)
        {
            player.Translate(player.right * moveDistance);
        }

        public override void Move(Transform player)
        {
            player.Translate(-player.right * moveDistance);
        }
    }

    public class MoveRight : Command
    {
        public override void Execute(Transform player, Command command)
        {
            Move(player);

            PlayerInput.oldCommands.Add(command);
        }

        public override void Undo(Transform player)
        {
            player.Translate(-player.right * moveDistance);
        }

        public override void Move(Transform player)
        {
            player.Translate(player.right * moveDistance);
        }
    }

    public class MoveForwardSprint : Command
    {
        public override void Execute(Transform player, Command command)
        {
            Move(player);

            PlayerInput.oldCommands.Add(command);
        }

        public override void Undo(Transform player)
        {
            player.Translate((-player.forward * moveDistance) * 2);
        }

        public override void Move(Transform player)
        {
            player.Translate((player.forward * moveDistance) * 2);
        }
    }
}

