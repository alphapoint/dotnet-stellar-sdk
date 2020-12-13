﻿// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================
    //  union SetOptionsResult switch (SetOptionsResultCode code)
    //  {
    //  case SET_OPTIONS_SUCCESS:
    //      void;
    //  default:
    //      void;
    //  };
    //  ===========================================================================
    public class SetOptionsResult
    {
        public SetOptionsResult() { }
        public SetOptionsResultCode Discriminant { get; set; } = new SetOptionsResultCode();
        public static void Encode(XdrDataOutputStream stream, SetOptionsResult encodedSetOptionsResult)
        {
            stream.WriteInt((int)encodedSetOptionsResult.Discriminant.InnerValue);
            switch (encodedSetOptionsResult.Discriminant.InnerValue)
            {
                case SetOptionsResultCode.SetOptionsResultCodeEnum.SET_OPTIONS_SUCCESS:
                    break;
                default:
                    break;
            }
        }
        public static SetOptionsResult Decode(XdrDataInputStream stream)
        {
            SetOptionsResult decodedSetOptionsResult = new SetOptionsResult();
            SetOptionsResultCode discriminant = SetOptionsResultCode.Decode(stream);
            decodedSetOptionsResult.Discriminant = discriminant;
            switch (decodedSetOptionsResult.Discriminant.InnerValue)
            {
                case SetOptionsResultCode.SetOptionsResultCodeEnum.SET_OPTIONS_SUCCESS:
                    break;
                default:
                    break;
            }
            return decodedSetOptionsResult;
        }
    }
}
