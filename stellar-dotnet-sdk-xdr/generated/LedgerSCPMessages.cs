﻿// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================
    //  struct LedgerSCPMessages
    //  {
    //      uint32 ledgerSeq;
    //      SCPEnvelope messages<>;
    //  };
    //  ===========================================================================
    public class LedgerSCPMessages
    {
        public LedgerSCPMessages() { }
        public Uint32 LedgerSeq { get; set; }
        public SCPEnvelope[] Messages { get; set; }

        public static void Encode(XdrDataOutputStream stream, LedgerSCPMessages encodedLedgerSCPMessages)
        {
            Uint32.Encode(stream, encodedLedgerSCPMessages.LedgerSeq);
            int messagessize = encodedLedgerSCPMessages.Messages.Length;
            stream.WriteInt(messagessize);
            for (int i = 0; i < messagessize; i++)
            {
                SCPEnvelope.Encode(stream, encodedLedgerSCPMessages.Messages[i]);
            }
        }
        public static LedgerSCPMessages Decode(XdrDataInputStream stream)
        {
            LedgerSCPMessages decodedLedgerSCPMessages = new LedgerSCPMessages();
            decodedLedgerSCPMessages.LedgerSeq = Uint32.Decode(stream);
            int messagessize = stream.ReadInt();
            decodedLedgerSCPMessages.Messages = new SCPEnvelope[messagessize];
            for (int i = 0; i < messagessize; i++)
            {
                decodedLedgerSCPMessages.Messages[i] = SCPEnvelope.Decode(stream);
            }
            return decodedLedgerSCPMessages;
        }
    }
}
