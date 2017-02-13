using System;
using System.Collections.Generic;

namespace GenoomApi.Extensions
{
    public interface IListModelResponse<TModel> : IResponse
    {
        Int32 PageSize { get; set; }

        Int32 PageNumber { get; set; }

        IEnumerable<TModel> Model { get; set; }
    }

    public class ListModelResponse<TModel> : IListModelResponse<TModel>
    {
        public String Message { get; set; }

        public Boolean DidError { get; set; }

        public String ErrorMessage { get; set; }

        public Int32 PageSize { get; set; }

        public Int32 PageNumber { get; set; }

        public IEnumerable<TModel> Model { get; set; }
    }
}
