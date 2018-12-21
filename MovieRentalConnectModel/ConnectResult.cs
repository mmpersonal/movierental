using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace MovieRental.DataModel.Connect
{
    [DataContract]
    public class ConnectResult
    {
        public static readonly ConnectResult Success = new ConnectResult(ConnectStatusCode.Success);
        public static readonly ConnectResult Unauthorized = new ConnectResult(ConnectStatusCode.Unauthorized);
        public static readonly ConnectResult ClientError = new ConnectResult(ConnectStatusCode.ClientError);
        public static readonly ConnectResult ServerError = new ConnectResult(ConnectStatusCode.ServerError);      

        [DataMember]
        public ConnectStatusCode StatusCode { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; } = string.Empty;
        

        public ConnectResult(ConnectStatusCode status)
        {
            StatusCode = status;
        }

       
        public ConnectResult(Exception exc)
        {
           StatusCode = ConnectStatusCode.ServerError;
           ErrorMessage = exc.Message;
        }
    }


}
