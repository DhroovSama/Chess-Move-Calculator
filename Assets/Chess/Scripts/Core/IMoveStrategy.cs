using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core
{
    public interface IMoveStrategy
    {
        List<Vector2Int> GetPossibleMoves(int row, int column, ChessPiece[,] boardState, Team team);
    }
}
