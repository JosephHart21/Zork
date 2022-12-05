using System;
namespace Final.Common
{
    public interface OutputAPI
    {
        void Write(object obj);

        void Write(string message);

        void WriteLine(object obj);

        void WriteLine(string message);

    }
}
