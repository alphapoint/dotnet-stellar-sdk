﻿using Newtonsoft.Json;

namespace stellar_dotnet_sdk.responses.operations
{
    /// <summary>
    /// Represents CreateAccount operation response.
    /// See: https://www.stellar.org/developers/horizon/reference/resources/operation.html
    /// <seealso cref="requests.OperationsRequestBuilder"/>
    /// <seealso cref="Server"/>
    /// </summary>
    public class CreateAccountOperationResponse : OperationResponse
    {
        public override int TypeId => 0;

        [JsonProperty(PropertyName = "account")]
        [JsonConverter(typeof(KeyPairTypeAdapter))]
        public KeyPair Account { get; private set; }

        [JsonProperty(PropertyName = "funder")]
        [JsonConverter(typeof(KeyPairTypeAdapter))]
        public KeyPair Funder { get; private set; }

        [JsonProperty(PropertyName = "starting_balance")]
        public string StartingBalance { get; private set; }

        public CreateAccountOperationResponse()
        {

        }

        public CreateAccountOperationResponse(KeyPair account, KeyPair funder, string startingBalance)
        {
            Account = account;
            Funder = funder;
            StartingBalance = startingBalance;
        }
    }
}