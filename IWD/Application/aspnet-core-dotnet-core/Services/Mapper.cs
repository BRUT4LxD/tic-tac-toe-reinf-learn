using aspnet_core_dotnet_core.Models;

public static class Mapper
{
    public static GameRequest MapAiMove(Move bestMove, GameRequest gameRequest, char aiSign)
    {
        if (bestMove.Row.Equals(0) && bestMove.Column.Equals(0))
        {
            gameRequest.MapModel.FirstRow.FirstColumn = aiSign.ToString();
        }
        else if (bestMove.Row.Equals(0) && bestMove.Column.Equals(1))
        {
            gameRequest.MapModel.FirstRow.SecondColumn = aiSign.ToString();
        }
        else if (bestMove.Row.Equals(0) && bestMove.Column.Equals(2))
        {
            gameRequest.MapModel.FirstRow.ThirdColumn = aiSign.ToString();
        }
        else if (bestMove.Row.Equals(1) && bestMove.Column.Equals(0))
        {
            gameRequest.MapModel.SecondRow.FirstColumn = aiSign.ToString();
        }
        else if (bestMove.Row.Equals(1) && bestMove.Column.Equals(1))
        {
            gameRequest.MapModel.SecondRow.SecondColumn = aiSign.ToString();
        }
        else if (bestMove.Row.Equals(1) && bestMove.Column.Equals(2))
        {
            gameRequest.MapModel.SecondRow.ThirdColumn = aiSign.ToString();
        }
        else if (bestMove.Row.Equals(2) && bestMove.Column.Equals(0))
        {
            gameRequest.MapModel.ThirdRow.FirstColumn = aiSign.ToString();
        }
        else if (bestMove.Row.Equals(2) && bestMove.Column.Equals(1))
        {
            gameRequest.MapModel.ThirdRow.SecondColumn = aiSign.ToString();
        }
        else if (bestMove.Row.Equals(2) && bestMove.Column.Equals(2))
        {
            gameRequest.MapModel.ThirdRow.ThirdColumn = aiSign.ToString();
        }

        return gameRequest;
    }

    public static char[][] FillBoardRequest(GameRequest gameRequest, char[][] board, char emptySign)
    {
        for (var i = 0; i < 3; i++)
        {
            board[i] = new char[3];
        }

        board[0][0] = gameRequest.MapModel.FirstRow.FirstColumn.Equals("")
            ? emptySign
            : gameRequest.MapModel.FirstRow.FirstColumn[0];
        board[0][1] = gameRequest.MapModel.FirstRow.SecondColumn.Equals("")
            ? emptySign
            : gameRequest.MapModel.FirstRow.SecondColumn[0];
        board[0][2] = gameRequest.MapModel.FirstRow.ThirdColumn.Equals("")
            ? emptySign
            : gameRequest.MapModel.FirstRow.ThirdColumn[0];
        board[1][0] = gameRequest.MapModel.SecondRow.FirstColumn.Equals("")
            ? emptySign
            : gameRequest.MapModel.SecondRow.FirstColumn[0];
        board[1][1] = gameRequest.MapModel.SecondRow.SecondColumn.Equals("")
            ? emptySign
            : gameRequest.MapModel.SecondRow.SecondColumn[0];
        board[1][2] = gameRequest.MapModel.SecondRow.ThirdColumn.Equals("")
            ? emptySign
            : gameRequest.MapModel.SecondRow.ThirdColumn[0];
        board[2][0] = gameRequest.MapModel.ThirdRow.FirstColumn.Equals("")
            ? emptySign
            : gameRequest.MapModel.ThirdRow.FirstColumn[0];
        board[2][1] = gameRequest.MapModel.ThirdRow.SecondColumn.Equals("")
            ? emptySign
            : gameRequest.MapModel.ThirdRow.SecondColumn[0];
        board[2][2] = gameRequest.MapModel.ThirdRow.ThirdColumn.Equals("")
            ? emptySign
            : gameRequest.MapModel.ThirdRow.ThirdColumn[0];

        return board;
    }

    public static string FindCurrentMovePosition(GameRequest gameRequest, char[][] previousBoard, char emptySign)
    {
        var position = 0;
        var currentBoard = new char[3][];
        FillBoardRequest(gameRequest, currentBoard, emptySign);

        for (var i = 0; i < currentBoard.Length; i++)
        {
            for (var j = 0; j < currentBoard[i].Length; j++)
            {
                position++;
                if (previousBoard[i][j] != currentBoard[i][j])
                    return position.ToString();
            }
        }

        return position.ToString();
    }

    public static MapModel PythonResponseToMapModel(string pythonResponse, MapModel mapModel)
    {
        mapModel.FirstRow.FirstColumn = pythonResponse[0].ToString();
        mapModel.FirstRow.SecondColumn = pythonResponse[1].ToString();
        mapModel.FirstRow.ThirdColumn = pythonResponse[2].ToString();

        mapModel.SecondRow.FirstColumn = pythonResponse[3].ToString();
        mapModel.SecondRow.SecondColumn = pythonResponse[4].ToString();
        mapModel.SecondRow.ThirdColumn = pythonResponse[5].ToString();

        mapModel.ThirdRow.FirstColumn = pythonResponse[6].ToString();
        mapModel.ThirdRow.SecondColumn = pythonResponse[7].ToString();
        mapModel.ThirdRow.ThirdColumn = pythonResponse[8].ToString();

        return mapModel;
    }
}