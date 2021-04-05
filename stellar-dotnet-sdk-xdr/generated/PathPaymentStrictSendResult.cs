// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
using System;

namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================

    //  union PathPaymentStrictSendResult switch (PathPaymentStrictSendResultCode code)
    //  {
    //  case PATH_PAYMENT_STRICT_SEND_SUCCESS:
    //      struct
    //      {
    //          ClaimOfferAtom offers<>;
    //          SimplePaymentResult last;
    //      } success;
    //  case PATH_PAYMENT_STRICT_SEND_NO_ISSUER:
    //      Asset noIssuer; // the asset that caused the error
    //  default:
    //      void;
    //  };

    //  ===========================================================================
    public class PathPaymentStrictSendResult
    {
        public PathPaymentStrictSendResult() { }

        public PathPaymentStrictSendResultCode Discriminant { get; set; } = new PathPaymentStrictSendResultCode();

        public PathPaymentStrictSendResultSuccess Success { get; set; }
        public Asset NoIssuer { get; set; }
        public static void Encode(XdrDataOutputStream stream, PathPaymentStrictSendResult encodedPathPaymentStrictSendResult)
        {
            stream.WriteInt((int)encodedPathPaymentStrictSendResult.Discriminant.InnerValue);
            switch (encodedPathPaymentStrictSendResult.Discriminant.InnerValue)
            {
                case PathPaymentStrictSendResultCode.PathPaymentStrictSendResultCodeEnum.PATH_PAYMENT_STRICT_SEND_SUCCESS:
                    PathPaymentStrictSendResultSuccess.Encode(stream, encodedPathPaymentStrictSendResult.Success);
                    break;
                case PathPaymentStrictSendResultCode.PathPaymentStrictSendResultCodeEnum.PATH_PAYMENT_STRICT_SEND_NO_ISSUER:
                    Asset.Encode(stream, encodedPathPaymentStrictSendResult.NoIssuer);
                    break;
                default:
                    break;
            }
        }
        public static PathPaymentStrictSendResult Decode(XdrDataInputStream stream)
        {
            PathPaymentStrictSendResult decodedPathPaymentStrictSendResult = new PathPaymentStrictSendResult();
            PathPaymentStrictSendResultCode discriminant = PathPaymentStrictSendResultCode.Decode(stream);
            decodedPathPaymentStrictSendResult.Discriminant = discriminant;
            switch (decodedPathPaymentStrictSendResult.Discriminant.InnerValue)
            {
                case PathPaymentStrictSendResultCode.PathPaymentStrictSendResultCodeEnum.PATH_PAYMENT_STRICT_SEND_SUCCESS:
                    decodedPathPaymentStrictSendResult.Success = PathPaymentStrictSendResultSuccess.Decode(stream);
                    break;
                case PathPaymentStrictSendResultCode.PathPaymentStrictSendResultCodeEnum.PATH_PAYMENT_STRICT_SEND_NO_ISSUER:
                    decodedPathPaymentStrictSendResult.NoIssuer = Asset.Decode(stream);
                    break;
                default:
                    break;
            }
            return decodedPathPaymentStrictSendResult;
        }

        public class PathPaymentStrictSendResultSuccess
        {
            public PathPaymentStrictSendResultSuccess() { }
            public ClaimOfferAtom[] Offers { get; set; }
            public SimplePaymentResult Last { get; set; }

            public static void Encode(XdrDataOutputStream stream, PathPaymentStrictSendResultSuccess encodedPathPaymentStrictSendResultSuccess)
            {
                int offerssize = encodedPathPaymentStrictSendResultSuccess.Offers.Length;
                stream.WriteInt(offerssize);
                for (int i = 0; i < offerssize; i++)
                {
                    ClaimOfferAtom.Encode(stream, encodedPathPaymentStrictSendResultSuccess.Offers[i]);
                }
                SimplePaymentResult.Encode(stream, encodedPathPaymentStrictSendResultSuccess.Last);
            }
            public static PathPaymentStrictSendResultSuccess Decode(XdrDataInputStream stream)
            {
                PathPaymentStrictSendResultSuccess decodedPathPaymentStrictSendResultSuccess = new PathPaymentStrictSendResultSuccess();
                int offerssize = stream.ReadInt();
                decodedPathPaymentStrictSendResultSuccess.Offers = new ClaimOfferAtom[offerssize];
                for (int i = 0; i < offerssize; i++)
                {
                    decodedPathPaymentStrictSendResultSuccess.Offers[i] = ClaimOfferAtom.Decode(stream);
                }
                decodedPathPaymentStrictSendResultSuccess.Last = SimplePaymentResult.Decode(stream);
                return decodedPathPaymentStrictSendResultSuccess;
            }

        }
    }
}
