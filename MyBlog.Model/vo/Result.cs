using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Model.vo
{
    public class Result
    {
        public int Code { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }

        public static Result Ok(string message, object data = null)
        {
            return new Result
            {
                Code = 200,
                Msg = message,
                Data = data
            };
        }

        public static Result Create(int code, string message)
        {
            return new Result
            {
                Code = code,
                Msg = message,
                Data = null
            };
        }
    }
}
