using System.Numerics;

public static class TelemetryBuffer
{
    public static byte[] AppropriateNegativeDataType(long neg)
    {
        var result = new byte[9];
        for (int i = 0; i < 9; i++)
        {
            result[i] = 0x0;
        }

        if (neg >= -32_768)
        {
            result[0] = 256 - 2;
            BitConverter.GetBytes((short)neg).CopyTo(result, 1);
        }
        else if (neg >= -2_147_483_648)
        {
            result[0] = 256 - 4;
            BitConverter.GetBytes((int)neg).CopyTo(result, 1);
        }
        else if (neg >= -9_223_372_036_854_775_808)
        {
            result[0] = 256 - 8;
            BitConverter.GetBytes((long)neg).CopyTo(result, 1);
        }

        return result;
    }

    public static byte[] AppropriateDataType(long pos)
    {
        var result = new byte[9];
        if (pos <= 65_535)
        {
            result[0] = 2;
            BitConverter.GetBytes((ushort)pos).CopyTo(result, 1);
        }
        else if (pos <= 2_147_483_647) // <-- Added this missing signed int range!
        {
            result[0] = 252; // 256 - 4
            BitConverter.GetBytes((int)pos).CopyTo(result, 1);
        }
        else if (pos <= 4_294_967_295)
        {
            result[0] = 4;
            BitConverter.GetBytes((uint)pos).CopyTo(result, 1);
        }
        else if (pos > 4_294_967_295)
        {
            result[0] = 256 - 8;
            BitConverter.GetBytes((ulong)pos).CopyTo(result, 1);
        }

        return result;
    }
    public static byte[] ToBuffer(long reading)
    {
        if (reading < 0)
        {
            return AppropriateNegativeDataType(reading);
        }

        return AppropriateDataType(reading);
    }

    public static long FromBuffer(byte[] buffer)
    {
        
        if (buffer[0] == 2)
        {
            return BitConverter.ToUInt16(buffer, 1);
        }
        else if (buffer[0] == 254)
        {
            return BitConverter.ToInt16(buffer, 1);
        }
        else if (buffer[0] == 4)
        {
            return BitConverter.ToUInt32(buffer, 1);
        }
        else if (buffer[0] == 252)
        {
            return BitConverter.ToInt32(buffer, 1);
        }
        else if (buffer[0] == 248)
        {
            return BitConverter.ToInt64(buffer, 1);
        }
        else if (buffer[0] == 8)
        {
            return (long)BitConverter.ToUInt64(buffer, 1);
        }
        else
        {
            return 0;
        }
    }
}
