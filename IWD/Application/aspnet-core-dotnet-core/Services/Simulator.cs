using aspnet_core_dotnet_core.Models;

namespace aspnet_core_dotnet_core.Services
{
    public class Simulator
    {
        public static MapModel Simulate(GameRequest requestJson)
        {
            if (requestJson.MapModel.FirstRow.FirstColumn.Equals(""))
            {
                requestJson.MapModel.FirstRow.FirstColumn = requestJson.AiSign;
            }
            else if (requestJson.MapModel.FirstRow.SecondColumn.Equals(""))
            {
                requestJson.MapModel.FirstRow.SecondColumn = requestJson.AiSign;
            }
            else if (requestJson.MapModel.FirstRow.ThirdColumn.Equals(""))
            {
                requestJson.MapModel.FirstRow.ThirdColumn = requestJson.AiSign;
            }
            else if (requestJson.MapModel.SecondRow.FirstColumn.Equals(""))
            {
                requestJson.MapModel.SecondRow.FirstColumn = requestJson.AiSign;
            }
            else if (requestJson.MapModel.SecondRow.SecondColumn.Equals(""))
            {
                requestJson.MapModel.SecondRow.SecondColumn = requestJson.AiSign;
            }
            else if (requestJson.MapModel.SecondRow.ThirdColumn.Equals(""))
            {
                requestJson.MapModel.SecondRow.ThirdColumn = requestJson.AiSign;
            }
            else if (requestJson.MapModel.ThirdRow.FirstColumn.Equals(""))
            {
                requestJson.MapModel.ThirdRow.FirstColumn = requestJson.AiSign;
            }
            else if (requestJson.MapModel.ThirdRow.SecondColumn.Equals(""))
            {
                requestJson.MapModel.ThirdRow.SecondColumn = requestJson.AiSign;
            }
            else if (requestJson.MapModel.ThirdRow.ThirdColumn.Equals(""))
            {
                requestJson.MapModel.ThirdRow.ThirdColumn = requestJson.AiSign;
            }

            return requestJson.MapModel;
        }

    }
}
