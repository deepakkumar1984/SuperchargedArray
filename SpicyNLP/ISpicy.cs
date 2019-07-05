using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyNLP
{
    public interface ISpicy
    {
        void ToDisk(string path);

        ISpicy FromDisk(string path);

        byte[] ToBytes();

        ISpicy FromBytes(byte[] data);
    }
}
