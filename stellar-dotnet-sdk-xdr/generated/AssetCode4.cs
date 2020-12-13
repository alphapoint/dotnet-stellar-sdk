﻿// Automatically generated by xdrgen
// DO NOT EDIT or your changes may be overwritten
namespace stellar_dotnet_sdk.xdr
{

    // === xdr source ============================================================
    //  typedef opaque AssetCode4[4];
    //  ===========================================================================
    public class AssetCode4
    {
        public byte[] InnerValue { get; set; } = default(byte[]);
        public AssetCode4() { }
        public AssetCode4(byte[] value)
        {
            InnerValue = value;
        }
        public static void Encode(XdrDataOutputStream stream, AssetCode4 encodedAssetCode4)
        {
            int AssetCode4size = encodedAssetCode4.InnerValue.Length;
            stream.Write(encodedAssetCode4.InnerValue, 0, AssetCode4size);
        }
        public static AssetCode4 Decode(XdrDataInputStream stream)
        {
            AssetCode4 decodedAssetCode4 = new AssetCode4();
            int AssetCode4size = 4;
            decodedAssetCode4.InnerValue = new byte[AssetCode4size];
            stream.Read(decodedAssetCode4.InnerValue, 0, AssetCode4size);
            return decodedAssetCode4;
        }
    }
}
