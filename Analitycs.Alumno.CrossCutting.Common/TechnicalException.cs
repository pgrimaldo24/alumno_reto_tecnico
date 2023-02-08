using Microsoft.VisualBasic;
using System.Runtime.Serialization;

namespace Analitycs.Alumno.CrossCutting.Common
{
    public class TechnicalException : Exception, ISerializable
    {
        public string TransactionId { get; }
        public int ErrorCode { get; }
        public dynamic Data { get; set; }

        public TechnicalException(string message) : base(message)
        {
            this.ErrorCode = 400;
            this.TransactionId = DateTime.Now.ToString("yyyyMMddHHmmssFFF");
        }
    }
}
