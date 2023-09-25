using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTocToe.Model.Core.Concrete
{
    public class ResultModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public ResultModel()
        {

        }

        public ResultModel(bool success, string message = null, List<string> errors = null)
        {
            Success = success;
            Message = message;
            Errors = errors;
        }

        public ResultModel(bool success, string message, Exception ex)
        {
            Success = success;
            Message = message;
            Errors = new List<string> { ex.GetBaseException().Message };
        }
    }

    public class ResultModel<TData> : ResultModel
    {
        public TData Data { get; set; }

        public ResultModel()
        {

        }

        public ResultModel(bool success, TData data, string message = null, List<string> errors = null)
            : base(success, message, errors)
        {
            Data = data;
        }

        public ResultModel(bool success, TData data, string message, Exception ex)
            : base(success, message, ex)
        {
            Data = data;
        }

        public ResultModel(bool success, string message, Exception ex)
            : base(success, message, ex)
        {

        }
    }
}
