// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
using System;

namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================

    //  union CreateClaimableBalanceResult switch (
    //      CreateClaimableBalanceResultCode code)
    //  {
    //  case CREATE_CLAIMABLE_BALANCE_SUCCESS:
    //      ClaimableBalanceID balanceID;
    //  default:
    //      void;
    //  };

    //  ===========================================================================
    public class CreateClaimableBalanceResult
    {
        public CreateClaimableBalanceResult() { }

        public CreateClaimableBalanceResultCode Discriminant { get; set; } = new CreateClaimableBalanceResultCode();

        public ClaimableBalanceID BalanceID { get; set; }
        public static void Encode(XdrDataOutputStream stream, CreateClaimableBalanceResult encodedCreateClaimableBalanceResult)
        {
            stream.WriteInt((int)encodedCreateClaimableBalanceResult.Discriminant.InnerValue);
            switch (encodedCreateClaimableBalanceResult.Discriminant.InnerValue)
            {
                case CreateClaimableBalanceResultCode.CreateClaimableBalanceResultCodeEnum.CREATE_CLAIMABLE_BALANCE_SUCCESS:
                    ClaimableBalanceID.Encode(stream, encodedCreateClaimableBalanceResult.BalanceID);
                    break;
                default:
                    break;
            }
        }
        public static CreateClaimableBalanceResult Decode(XdrDataInputStream stream)
        {
            CreateClaimableBalanceResult decodedCreateClaimableBalanceResult = new CreateClaimableBalanceResult();
            CreateClaimableBalanceResultCode discriminant = CreateClaimableBalanceResultCode.Decode(stream);
            decodedCreateClaimableBalanceResult.Discriminant = discriminant;
            switch (decodedCreateClaimableBalanceResult.Discriminant.InnerValue)
            {
                case CreateClaimableBalanceResultCode.CreateClaimableBalanceResultCodeEnum.CREATE_CLAIMABLE_BALANCE_SUCCESS:
                    decodedCreateClaimableBalanceResult.BalanceID = ClaimableBalanceID.Decode(stream);
                    break;
                default:
                    break;
            }
            return decodedCreateClaimableBalanceResult;
        }
    }
}
