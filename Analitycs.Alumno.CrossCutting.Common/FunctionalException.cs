using Microsoft.VisualBasic;
using System.Runtime.Serialization;

namespace Analitycs.Alumno.CrossCutting.Common
{
    [Serializable()]
    public class FunctionalException : Exception, ISerializable
    {
        public string TransactionId { get; }
        public int FuntionalCode { get; }
        public dynamic Data { get; set; }

        public FunctionalException(int status, string message) : base(message)
        {
            this.FuntionalCode = status;
            this.TransactionId = DateTime.Now.ToString("yyyyMMddHHmmssFFF");
        }
        public FunctionalException(int status, string message, dynamic data) : base(message)
        {
            this.FuntionalCode = status;
            this.TransactionId = DateTime.Now.ToString("yyyyMMddHHmmssFFF");
            this.Data = data;
        }
        public FunctionalException(string message) : base(message)
        {
            this.FuntionalCode = 400;
            this.TransactionId = DateTime.Now.ToString("yyyyMMddHHmmssFFF");
        }
    }
}
