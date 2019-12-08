using System;

namespace aspnet_core_dotnet_core.Models
{
    public class GameRequest
    {
        public MapModel MapModel { get; set; }
        public String AiSign { get; set; }
        public String ChosenAlgorithm { get; set; }
    }
}
