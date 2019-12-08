using System;
using System.Collections.Generic;

internal class TicTacToeMonkeyAI
{
    private readonly char _empty;

    // istotne z pkt widzenia integracji !!!
    // w konstruktorze ustawiamy znaki tablicy podawanej do zapytania
    // zwracany wynik najlepszego ruchu dla AI to obiekt klasy Move

    public TicTacToeMonkeyAI(char empty)
    {
        _empty = empty;
    }

    public Move FindBestMove(IReadOnlyList<char[]> board)
    {
        var movesList = new List<Move>();

        for (var i = 0; i < 3; i++)
        {
            for (var j = 0; j < 3; j++)
            {
                if (board[i][j] == _empty)
                {
                    movesList.Add(new Move(j, i));
                }
            }
        }

        var random = new Random();

        return movesList[random.Next(movesList.Count)];
    }
}