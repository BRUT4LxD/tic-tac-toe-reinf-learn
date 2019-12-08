using aspnet_core_dotnet_core.Models;

public static class Game
{
    public static bool BoardIsFull(GameRequest gameRequest, char emptySign)
    {
        var board = new char[3][];
        Mapper.FillBoardRequest(gameRequest, board, emptySign);

        foreach (var t in board)
        {
            foreach (var t1 in t)
            {
                if (t1 == emptySign || t1 == ' ')
                {
                    return false;
                }
            }
        }

        return true;
    }

    public static bool BoardIsEmpty(GameRequest gameRequest, char emptySign)
    {
        var board = new char[3][];
        Mapper.FillBoardRequest(gameRequest, board, emptySign);
        foreach (var t in board)
        {
            foreach (var t1 in t)
            {
                if (t1 != emptySign && t1 != ' ')
                {
                    return false;
                }
            }

        }

        return true;
    }
}