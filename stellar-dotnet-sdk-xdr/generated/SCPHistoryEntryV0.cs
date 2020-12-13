﻿// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================
    //  struct SCPHistoryEntryV0
    //  {
    //      SCPQuorumSet quorumSets<>; // additional quorum sets used by ledgerMessages
    //      LedgerSCPMessages ledgerMessages;
    //  };
    //  ===========================================================================
    public class SCPHistoryEntryV0
    {
        public SCPHistoryEntryV0() { }
        public SCPQuorumSet[] QuorumSets { get; set; }
        public LedgerSCPMessages LedgerMessages { get; set; }

        public static void Encode(XdrDataOutputStream stream, SCPHistoryEntryV0 encodedSCPHistoryEntryV0)
        {
            int quorumSetssize = encodedSCPHistoryEntryV0.QuorumSets.Length;
            stream.WriteInt(quorumSetssize);
            for (int i = 0; i < quorumSetssize; i++)
            {
                SCPQuorumSet.Encode(stream, encodedSCPHistoryEntryV0.QuorumSets[i]);
            }
            LedgerSCPMessages.Encode(stream, encodedSCPHistoryEntryV0.LedgerMessages);
        }
        public static SCPHistoryEntryV0 Decode(XdrDataInputStream stream)
        {
            SCPHistoryEntryV0 decodedSCPHistoryEntryV0 = new SCPHistoryEntryV0();
            int quorumSetssize = stream.ReadInt();
            decodedSCPHistoryEntryV0.QuorumSets = new SCPQuorumSet[quorumSetssize];
            for (int i = 0; i < quorumSetssize; i++)
            {
                decodedSCPHistoryEntryV0.QuorumSets[i] = SCPQuorumSet.Decode(stream);
            }
            decodedSCPHistoryEntryV0.LedgerMessages = LedgerSCPMessages.Decode(stream);
            return decodedSCPHistoryEntryV0;
        }
    }
}
