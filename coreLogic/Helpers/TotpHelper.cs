using System;
using System.Security.Cryptography;
using System.Text;

namespace coreLogic.Helpers;

public static class TotpHelper
{
    // Generates a 6-digit TOTP code for the given secret and time
    public static string GenerateTotp(string base32Secret, DateTime? timestamp = null, int step = 30, int digits = 6)
    {
        var secret = Base32Decode(base32Secret);
        var unixTime = (long)Math.Floor(((timestamp ?? DateTime.UtcNow) - DateTime.UnixEpoch).TotalSeconds);
        var timestep = unixTime / step;
        var timestepBytes = BitConverter.GetBytes(timestep);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(timestepBytes);

        using var hmac = new HMACSHA1(secret);
        var hash = hmac.ComputeHash(timestepBytes);
        int offset = hash[^1] & 0x0F;
        int binaryCode = ((hash[offset] & 0x7F) << 24)
                      | ((hash[offset + 1] & 0xFF) << 16)
                      | ((hash[offset + 2] & 0xFF) << 8)
                      | (hash[offset + 3] & 0xFF);
        int otp = binaryCode % (int)Math.Pow(10, digits);
        return otp.ToString(new string('0', digits));
    }

    // Validates a TOTP code for the given secret
    public static bool ValidateTotp(string base32Secret, string code, int step = 30, int digits = 6, int allowedDrift = 1)
    {
        var now = DateTime.UtcNow;
        for (int i = -allowedDrift; i <= allowedDrift; i++)
        {
            var testTime = now.AddSeconds(i * step);
            if (GenerateTotp(base32Secret, testTime, step, digits) == code)
                return true;
        }
        return false;
    }

    // Generates a random 20-byte secret and encodes it in base32
    public static string GenerateBase32Secret(int length = 20)
    {
        var bytes = new byte[length];
        RandomNumberGenerator.Fill(bytes);
        return Base32Encode(bytes);
    }

    // Base32 encode/decode helpers
    private const string Base32Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ234567";
    public static string Base32Encode(byte[] data)
    {
        var sb = new StringBuilder();
        int bits = 0, value = 0;
        foreach (var b in data)
        {
            value = (value << 8) | b;
            bits += 8;
            while (bits >= 5)
            {
                sb.Append(Base32Chars[(value >> (bits - 5)) & 31]);
                bits -= 5;
            }
        }
        if (bits > 0)
            sb.Append(Base32Chars[(value << (5 - bits)) & 31]);
        return sb.ToString();
    }
    public static byte[] Base32Decode(string base32)
    {
        base32 = base32.TrimEnd('=');
        int byteCount = base32.Length * 5 / 8;
        var bytes = new byte[byteCount];
        int bits = 0, value = 0, index = 0;
        foreach (var c in base32.ToUpperInvariant())
        {
            if (c < 'A' || (c > 'Z' && c < '2') || c > '7') continue;
            value = (value << 5) | Base32Chars.IndexOf(c);
            bits += 5;
            if (bits >= 8)
            {
                bytes[index++] = (byte)((value >> (bits - 8)) & 0xFF);
                bits -= 8;
            }
        }
        return bytes;
    }
}
