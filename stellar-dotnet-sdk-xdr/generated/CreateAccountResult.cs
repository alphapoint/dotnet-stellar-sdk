// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
using System;

namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================

    //  union CreateAccountResult switch (CreateAccountResultCode code)
    //  {
    //  case CREATE_ACCOUNT_SUCCESS:
    //      void;
    //  default:
    //      void;
    //  };

    //  ===========================================================================
    public class CreateAccountResult
    {
        public CreateAccountResult() { }

        public CreateAccountResultCode Discriminant { get; set; } = new CreateAccountResultCode();

        public static void Encode(XdrDataOutputStream stream, CreateAccountResult encodedCreateAccountResult)
        {
            stream.WriteInt((int)encodedCreateAccountResult.Discriminant.InnerValue);
            switch (encodedCreateAccountResult.Discriminant.InnerValue)
            {
                case CreateAccountResultCode.CreateAccountResultCodeEnum.CREATE_ACCOUNT_SUCCESS:
                    break;
                default:
                    break;
            }
        }
        public static CreateAccountResult Decode(XdrDataInputStream stream)
        {
            CreateAccountResult decodedCreateAccountResult = new CreateAccountResult();
            CreateAccountResultCode discriminant = CreateAccountResultCode.Decode(stream);
            decodedCreateAccountResult.Discriminant = discriminant;
            switch (decodedCreateAccountResult.Discriminant.InnerValue)
            {
                case CreateAccountResultCode.CreateAccountResultCodeEnum.CREATE_ACCOUNT_SUCCESS:
                    break;
                default:
                    break;
            }
            return decodedCreateAccountResult;
        }
    }
}
