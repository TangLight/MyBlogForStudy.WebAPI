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

        private Result(int code, string msg)
        {
            Code = code;
            Msg = msg;
            Data = null;
        }

        private Result(int code, string msg, object data)
        {
            Code = code;
            Msg = msg;
            Data = data;
        }

        public static Result Ok(string msg, object data)
        {
            return new Result(200, msg, data);
        }

        public static Result Ok(string msg)
        {
            return new Result(200, msg);
        }

        public static Result Error(string msg)
        {
            return new Result(500, msg);
        }

        public static Result Error()
        {
            return new Result(500, "异常错误");
        }

        public static Result Create(int code, string msg, object data)
        {
            return new Result(code, msg, data);
        }

        public static Result Create(int code, string msg)
        {
            return new Result(code, msg);
        }
    }
}
