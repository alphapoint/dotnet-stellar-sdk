﻿// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================
    //  struct FeeBumpTransactionEnvelope
    //  {
    //      FeeBumpTransaction tx;
    //      /* Each decorated signature is a signature over the SHA256 hash of
    //       * a TransactionSignaturePayload */
    //      DecoratedSignature signatures<20>;
    //  };
    //  ===========================================================================
    public class FeeBumpTransactionEnvelope
    {
        public FeeBumpTransactionEnvelope() { }
        public FeeBumpTransaction Tx { get; set; }
        public DecoratedSignature[] Signatures { get; set; }

        public static void Encode(XdrDataOutputStream stream, FeeBumpTransactionEnvelope encodedFeeBumpTransactionEnvelope)
        {
            FeeBumpTransaction.Encode(stream, encodedFeeBumpTransactionEnvelope.Tx);
            int signaturessize = encodedFeeBumpTransactionEnvelope.Signatures.Length;
            stream.WriteInt(signaturessize);
            for (int i = 0; i < signaturessize; i++)
            {
                DecoratedSignature.Encode(stream, encodedFeeBumpTransactionEnvelope.Signatures[i]);
            }
        }
        public static FeeBumpTransactionEnvelope Decode(XdrDataInputStream stream)
        {
            FeeBumpTransactionEnvelope decodedFeeBumpTransactionEnvelope = new FeeBumpTransactionEnvelope();
            decodedFeeBumpTransactionEnvelope.Tx = FeeBumpTransaction.Decode(stream);
            int signaturessize = stream.ReadInt();
            decodedFeeBumpTransactionEnvelope.Signatures = new DecoratedSignature[signaturessize];
            for (int i = 0; i < signaturessize; i++)
            {
                decodedFeeBumpTransactionEnvelope.Signatures[i] = DecoratedSignature.Decode(stream);
            }
            return decodedFeeBumpTransactionEnvelope;
        }
    }
}
