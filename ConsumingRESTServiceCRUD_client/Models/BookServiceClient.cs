using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace ConsumingRESTServiceCRUD_client.Models
{
    public class BookServiceClient
    {
        String BASE_URL = "http://localhost:51170/BookServices.svc";

        public List<Book> getAllBook()
        {
            var syncClient = new WebClient();
            var content = syncClient.DownloadString(BASE_URL + "/Book");
            var json_serializer = new JavaScriptSerializer();
            return json_serializer.Deserialize<List<Book>>(content);
        }
    }
}