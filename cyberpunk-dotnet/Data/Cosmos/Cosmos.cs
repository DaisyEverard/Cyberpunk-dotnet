//using cyberpunk_dotnet.Data.Interfaces;
//using Azure.Identity;
//using Microsoft.Azure.Cosmos;

//namespace cyberpunk_dotnet.Data.Cosmos
//{
//    public class Cosmos : ICharacterRepository
//    {
//        CosmosClient _client;
//        ICosmosDatabase _database;

//        public Cosmos()
//        {
//            _client = new CosmosClient(
//                accountEndpoint: "endpoint",
//                TokenCredentialDiagnosticsOptions: new DefaultAzureCredential()
//            );
//            _database = _client.GetDatabase("cyberpunk");
//        }
//    }
//}
