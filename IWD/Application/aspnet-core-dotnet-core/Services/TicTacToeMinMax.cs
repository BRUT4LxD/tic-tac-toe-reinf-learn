using System;
using System.Collections.Generic;

internal class TicTacToeMinMax
{
    private readonly char _ai;
    private readonly char _player;
    private readonly char _empty;

    // istotne z pkt widzenia integracji !!!
    // w konstruktorze ustawiamy znaki tablicy podawanej do zapytania
    // zwracany wynik najlepszego ruchu dla AI to obiekt klasy Move

    public TicTacToeMinMax(char ai, char player, char empty)
    {
        _ai = ai;
        _player = player;
        _empty = empty;
    }

    private bool IsMovesLeft(IReadOnlyList<char[]> board)
    {
        for (var i = 0; i < 3; i++)
            for (var j = 0; j < 3; j++)
                if (board[i][j] == _empty)
                    return true;

        return false;
    }

    private int Evaluate(char[][] board)
    {
        if (board == null) throw new ArgumentNullException(nameof(board));

        for (var row = 0; row < 3; row++)
        {
            if (board[row][0] != board[row][1] || board[row][1] != board[row][2]) continue;

            if (board[row][0] == _ai)
                return +10;

            if (board[row][0] == _player)
                return -10;
        }

        for (var col = 0; col < 3; col++)
        {
            if (board[0][col] != board[1][col] || board[1][col] != board[2][col]) continue;
            if (board[0][col] == _ai)
                return +10;

            if (board[0][col] == _player)
                return -10;
        }

        if (board[0][0] == board[1][1] && board[1][1] == board[2][2])
        {
            if (board[0][0] == _ai)
                return +10;
            if (board[0][0] == _player)
                return -10;
        }

        if (board[0][2] == board[1][1] && board[1][1] == board[2][0])
        {
            if (board[0][2] == _ai)
                return +10;
            if (board[0][2] == _player)
                return -10;
        }

        return 0;
    }

    private int Minimax(char[][] board, int depth, bool isMax)
    {
        var score = Evaluate(board);

        if (score == 10)
            return score;

        if (score == -10)
        {
            return score;
        }

        if (!IsMovesLeft(board))
            return 0;

        if (isMax)
        {
            var best = -1000;

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (board[i][j] != _empty) continue;

                    board[i][j] = _ai;

                    best = Math.Max(best, Minimax(board, depth + 1, !isMax));

                    board[i][j] = _empty;
                }
            }

            return best;
        }

        else
        {
            var best = 1000;

            for (var i = 0; i < 3; i++)
            {
                for (var j = 0; j < 3; j++)
                {
                    if (board[i][j] != _empty) continue;

                    board[i][j] = _player;

                    best = Math.Min(best, Minimax(board, depth + 1, !isMax));

                    board[i][j] = _empty;
                }
            }

            return best;
        }
    }

    public Move FindBestMove(char[][] board)
    {
        var bestVal = -1000;
        var bestMove = new Move(-1, -1);

        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                if (board[i][j] == _empty)
                {
                    board[i][j] = _ai;

                    var moveVal = Minimax(board, 0, false);

                    board[i][j] = _empty;
                    if (moveVal > bestVal)
                    {
                        bestMove.Row = i;
                        bestMove.Column = j;
                        bestVal = moveVal;
                    }
                }
            }
        }

        return bestMove;
    }
}