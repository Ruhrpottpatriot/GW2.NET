using System;

namespace GW2DotNET.V1.Core
{
    public class ApiException : Exception
    {
        public ApiException(int error, int product, int module, int line, string text)
            : this(error, product, module, line, text, null) { }

        public ApiException(int error, int product, int module, int line, string text, Exception innerException)
            : base(text, innerException)
        {
            this.Error = error;
            this.Product = product;
            this.Module = module;
            this.Line = line;
        }

        public int Error { get; private set; }

        public int Product { get; private set; }

        public int Module { get; private set; }

        public int Line { get; private set; }

    }
}
