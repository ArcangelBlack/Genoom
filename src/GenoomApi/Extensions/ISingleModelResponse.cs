﻿using System;

namespace GenoomApi.Extensions
{
    public interface ISingleModelResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }

    public class SingleModelResponse<TModel> : ISingleModelResponse<TModel>
    {
        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }

        public TModel Model { get; set; }
    }
}
