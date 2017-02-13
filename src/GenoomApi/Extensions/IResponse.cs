using System;

namespace GenoomApi.Extensions
{
    public interface IResponse
    {
        String Message { get; set; }

        Boolean DidError { get; set; }

        String ErrorMessage { get; set; }
    }
}
