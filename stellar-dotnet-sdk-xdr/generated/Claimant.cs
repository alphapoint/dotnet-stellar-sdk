﻿// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================
    //  union Claimant switch (ClaimantType type)
    //  {
    //  case CLAIMANT_TYPE_V0:
    //      struct
    //      {
    //          AccountID destination;    // The account that can use this condition
    //          ClaimPredicate predicate; // Claimable if predicate is true
    //      } v0;
    //  };
    //  ===========================================================================
    public class Claimant
    {
        public Claimant() { }
        public ClaimantType Discriminant { get; set; } = new ClaimantType();
        public ClaimantV0 V0 { get; set; }
        public static void Encode(XdrDataOutputStream stream, Claimant encodedClaimant)
        {
            stream.WriteInt((int)encodedClaimant.Discriminant.InnerValue);
            switch (encodedClaimant.Discriminant.InnerValue)
            {
                case ClaimantType.ClaimantTypeEnum.CLAIMANT_TYPE_V0:
                    ClaimantV0.Encode(stream, encodedClaimant.V0);
                    break;
            }
        }
        public static Claimant Decode(XdrDataInputStream stream)
        {
            Claimant decodedClaimant = new Claimant();
            ClaimantType discriminant = ClaimantType.Decode(stream);
            decodedClaimant.Discriminant = discriminant;
            switch (decodedClaimant.Discriminant.InnerValue)
            {
                case ClaimantType.ClaimantTypeEnum.CLAIMANT_TYPE_V0:
                    decodedClaimant.V0 = ClaimantV0.Decode(stream);
                    break;
            }
            return decodedClaimant;
        }

        public class ClaimantV0
        {
            public ClaimantV0() { }
            public AccountID Destination { get; set; }
            public ClaimPredicate Predicate { get; set; }

            public static void Encode(XdrDataOutputStream stream, ClaimantV0 encodedClaimantV0)
            {
                AccountID.Encode(stream, encodedClaimantV0.Destination);
                ClaimPredicate.Encode(stream, encodedClaimantV0.Predicate);
            }
            public static ClaimantV0 Decode(XdrDataInputStream stream)
            {
                ClaimantV0 decodedClaimantV0 = new ClaimantV0();
                decodedClaimantV0.Destination = AccountID.Decode(stream);
                decodedClaimantV0.Predicate = ClaimPredicate.Decode(stream);
                return decodedClaimantV0;
            }

        }
    }
}
