using aspnet_core_dotnet_core.Models;
using aspnet_core_dotnet_core.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace aspnet_core_dotnet_core.Controllers
{
    [EnableCors("AllowAllOrigins")]
    [Produces("application/json")]
    [Route("api/Game")]
    public class GameController : Controller
    {
        private static readonly char[][] board = { new[] { '_', '_', '_' }, new[] { '_', '_', '_' }, new[] { '_', '_', '_' } };

        // POST: api/game
        [HttpPost]
        public async Task<MapModel> Post([FromBody] GameRequest gameRequest)
        {
            var aiSign = gameRequest.AiSign.Equals("X") ? 'X' : 'O';
            var playerSign = gameRequest.AiSign.Equals("X") ? 'O' : 'X';
            const char emptySign = '_';
            Move bestMove;

            switch (gameRequest.ChosenAlgorithm)
            {
                case "MinMax":
                    var ticTacToeMinMax = new TicTacToeMinMax(aiSign, playerSign, emptySign);

                    Mapper.FillBoardRequest(gameRequest, board, emptySign);
                    bestMove = ticTacToeMinMax.FindBestMove(board);
                    Mapper.MapAiMove(bestMove, gameRequest, aiSign);

                    return gameRequest.MapModel;
                case "Q-Learning":
                    string response;
                    if (Game.BoardIsEmpty(gameRequest, emptySign))
                    {
                        response = await QLearning.AIStart();
                    }
                    else
                    {
                        var position = Mapper.FindCurrentMovePosition(gameRequest, board, emptySign);
                        response = await QLearning.Move(position);
                    }

                    Mapper.PythonResponseToMapModel(response, gameRequest.MapModel);

                    if (Game.BoardIsFull(gameRequest, emptySign))
                    {
                        await QLearning.Start();
                    }

                    Mapper.FillBoardRequest(gameRequest, board, emptySign);

                    return gameRequest.MapModel;
                case "Monkey":
                    var ticTacToeMonkeyAI = new TicTacToeMonkeyAI(emptySign);

                    Mapper.FillBoardRequest(gameRequest, board, emptySign);
                    bestMove = ticTacToeMonkeyAI.FindBestMove(board);
                    Mapper.MapAiMove(bestMove, gameRequest, aiSign);

                    return gameRequest.MapModel;
                default:
                    return Simulator.Simulate(gameRequest);
            }
        }
    }
}