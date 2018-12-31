﻿using Newtonsoft.Json;
using System;

namespace stellar_dotnet_sdk.responses
{
    /// <summary>
    ///
    /// </summary>
    public class AssetResponse : Response, IPagingToken
    {
        /// <summary>
        ///
        /// </summary>
        [JsonProperty(PropertyName = "_links")]
        public AssetResponseLinks Links { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty(PropertyName = "asset_type")]
        public string AssetType { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty(PropertyName = "asset_code")]
        public string AssetCode { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty(PropertyName = "asset_issuer")]
        public string AssetIssuer { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty(PropertyName = "paging_token")]
        public string PagingToken { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty(PropertyName = "ammount")] //TODO: This looks like a spelling error to me. Quick test don't reveal an issue though, which is strange.
        public string Amount { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty(PropertyName = "num_accounts")]
        public long NumAccounts { get; set; }

        /// <summary>
        ///
        /// </summary>
        [JsonProperty(PropertyName = "flags")]
        public AssetResponseFlags Flags { get; set; }

        /// <summary>
        ///
        /// </summary>
        public Asset Asset
        {
            get { return Asset.Create(AssetType, AssetCode, AssetIssuer); }
        }

        public AssetResponse(String assetType, String assetCode, String assetIssuer, String pagingToken, String amount, int numAccounts, AssetResponseFlags flags, AssetResponseLinks links)
        {
            AssetType = assetType;
            AssetCode = assetCode;
            AssetIssuer = assetIssuer;
            PagingToken = pagingToken;
            Amount = amount;
            NumAccounts = numAccounts;
            Flags = flags;
            Links = links;
        }
    }
}