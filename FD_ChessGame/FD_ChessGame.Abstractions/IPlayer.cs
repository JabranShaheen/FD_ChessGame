﻿namespace FD_ChessGame.Abstractions
{
    public interface IPlayer
    {
        Position Position { get; }
        void MoveUp();
        void MoveDown();
        void MoveLeft();
        void MoveRight();
    }
}
