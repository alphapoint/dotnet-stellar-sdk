// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
using System;

namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================

    //  typedef opaque UpgradeType<128>;

    //  ===========================================================================
    public class UpgradeType
    {
        public byte[] InnerValue { get; set; } = default(byte[]);

        public UpgradeType() { }

        public UpgradeType(byte[] value)
        {
            InnerValue = value;
        }

        public static void Encode(XdrDataOutputStream stream, UpgradeType encodedUpgradeType)
        {
            int UpgradeTypesize = encodedUpgradeType.InnerValue.Length;
            stream.WriteInt(UpgradeTypesize);
            stream.Write(encodedUpgradeType.InnerValue, 0, UpgradeTypesize);
        }
        public static UpgradeType Decode(XdrDataInputStream stream)
        {
            UpgradeType decodedUpgradeType = new UpgradeType();
            int UpgradeTypesize = stream.ReadInt();
            decodedUpgradeType.InnerValue = new byte[UpgradeTypesize];
            stream.Read(decodedUpgradeType.InnerValue, 0, UpgradeTypesize);
            return decodedUpgradeType;
        }
    }
}
