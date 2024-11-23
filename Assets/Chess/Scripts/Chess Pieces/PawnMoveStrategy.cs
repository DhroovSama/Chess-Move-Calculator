using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core
{
    public class PawnMoveStrategy : IMoveStrategy
    {
        public List<Vector2Int> GetPossibleMoves(int row, int column, ChessPiece[,] boardState, Team team)
        {
            var moves = new List<Vector2Int>();
            int direction = team == Team.White ? -1 : 1; 


            int nextRow = row + direction;
            if (IsInsideBoard(nextRow, column) && boardState[nextRow, column] == null)
            {
                moves.Add(new Vector2Int(nextRow, column));

                // Double Move on First Move
                if ((team == Team.White && row == 6) || (team == Team.Black && row == 1))
                {
                    int doubleNextRow = row + 2 * direction;
                    if (boardState[doubleNextRow, column] == null)
                    {
                        moves.Add(new Vector2Int(doubleNextRow, column));
                    }
                }
            }

            int[] captureOffsets = { -1, 1 };
            foreach (int colOffset in captureOffsets)
            {
                int captureCol = column + colOffset;
                if (IsInsideBoard(nextRow, captureCol))
                {
                    ChessPiece targetPiece = boardState[nextRow, captureCol];
                    if (targetPiece != null && targetPiece.Team != team)
                    {
                        moves.Add(new Vector2Int(nextRow, captureCol));
                    }
                }
            }

            return moves;
        }

        private bool IsInsideBoard(int row, int column)
        {
            return row >= 0 && row < 8 && column >= 0 && column < 8;
        }
    }
}
