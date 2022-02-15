using System;
using System.Collections.Generic;
using System.Linq;
namespace Task03_GenericInterfaces
{
    public abstract class BinaryToStringEncoder : IEncrypted<byte[], string>
    {
        protected abstract Dictionary<string, byte[]> GetDictionary();

        public byte[] Encode(string u)
        {
            var dict = GetDictionary();
            return dict.GetValueOrDefault(u);
        }

        public string Decode(byte[] t)
        {
            if(this is WindEncoder && t.Length < 3)
            {
                Array.Resize(ref t, 3);
                Array.Reverse(t);
            }
            else if (this is SideOfTheWorldEncoder && t.Length < 2)
            {
                Array.Resize(ref t, 2);
                Array.Reverse(t);
            }
            foreach (var key in GetDictionary().Keys)
            {
                if (t.SequenceEqual(GetDictionary()[key]))
                {
                    return key;
                }
            }
            return "В данном кодировщике не может быть такого значения";
        }
    }

}