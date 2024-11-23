using System.Collections.Generic;
using UnityEngine;

namespace Chess.Scripts.Core
{
    public class BishopMoveStrategy : IMoveStrategy
    {
        public List<Vector2Int> GetPossibleMoves(int row, int column, ChessPiece[,] boardState, Team team)
        {
            var moves = new List<Vector2Int>();
            Vector2Int[] directions = {
                new Vector2Int(-1, -1), // Up Left
                new Vector2Int(-1, 1),  // Up Right
                new Vector2Int(1, -1),  // Down Left
                new Vector2Int(1, 1)    // Down Right
            };

            foreach (var dir in directions)
            {
                int currentRow = row;
                int currentCol = column;

                while (true)
                {
                    currentRow += dir.x;
                    currentCol += dir.y;

                    if (!IsInsideBoard(currentRow, currentCol))
                        break;

                    ChessPiece targetPiece = boardState[currentRow, currentCol];
                    if (targetPiece == null)
                    {
                        moves.Add(new Vector2Int(currentRow, currentCol));
                    }
                    else
                    {
                        if (targetPiece.Team != team)
                        {
                            moves.Add(new Vector2Int(currentRow, currentCol));
                        }
                        break; // Can't move beyond this piece
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
