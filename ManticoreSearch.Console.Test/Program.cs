using ManticoreSearch.Client.Api;
using ManticoreSearch.Client.Model;
using System;
using System.Collections.Generic;

namespace ManticoreSearch.ConsoleApp.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var util = new UtilsApi();
                var searchApi = new SearchApi();
                var indexApi = new IndexApi();

                Dictionary<string, object> result;
                try
                {
                    result = util.Sql(@"query=select * from products");
                    foreach (var item in result)
                    {
                        Console.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }

                var rs = util.Sql("mode=raw&query=create table products(title text, price float) morphology='stem_en'");

                Console.WriteLine("Create result "  + rs.Count + Environment.NewLine);

                rs = util.Sql("mode=raw&query=SELECT * FROM products");

                Console.WriteLine("Select result " + rs.Count + Environment.NewLine);

                var newdoc = new InsertDocumentRequest();
                Dictionary<string, object> doc = new Dictionary<string, object>();
                doc.Add("title", "Crossbody Bag with Tassel");
                doc.Add("price", 19.85);

                newdoc.Index("products").Id(0).SetDoc(doc);
                var insertResult = indexApi.Insert(newdoc);

                Console.WriteLine(insertResult + Environment.NewLine);

                newdoc = new InsertDocumentRequest();
                doc = new Dictionary<string, object>();

                doc.Add("title", "microfiber sheet set");
                doc.Add("price", 19.99);
                newdoc.Index("products").Id(0).SetDoc(doc);
                insertResult = indexApi.Insert(newdoc);

                Console.WriteLine(insertResult + Environment.NewLine);

                newdoc = new InsertDocumentRequest();
                doc = new Dictionary<string, object>();
                doc.Add("title", "Pet Hair Remover Glove");
                doc.Add("price", 7.99);
                newdoc.Index("products").Id(0L).SetDoc(doc);
                insertResult = indexApi.Insert(newdoc);

                Console.WriteLine(insertResult + Environment.NewLine);

                var query = new Dictionary<string, object>();
                var match = new Dictionary<string, object>() { { "title", "crossbody"} };
                query.Add("match", match);
                var searchRequest = new SearchRequest();
                searchRequest.SetIndex("products");
                searchRequest.SetQuery(query);
                Dictionary<string, object> highlight = new Dictionary<string, object>();
                highlight.Add("fields", new string[] { "title" });
                searchRequest.SetHighlight(highlight);
                var searchResponse = searchApi.Search(searchRequest);

                Console.WriteLine(searchResponse + Environment.NewLine);

                UpdateDocumentRequest updateRequest = new UpdateDocumentRequest();
                doc = new Dictionary<string, object>();
                doc.Add("price", 17.5);
                updateRequest.Index("products").Id(2L).SetDoc(doc);
                var updResult = indexApi.Update(updateRequest);

                Console.WriteLine(updResult + Environment.NewLine);

                DeleteDocumentRequest deleteRequest = new DeleteDocumentRequest();
                var condition = new Dictionary<string, object>() { {"lte", 10 } };
                var field = new Dictionary<string, object>() { { "price", condition } };
                query = new Dictionary<string, object>() { { "range", field } };

                deleteRequest.Index("products").SetQuery(query);
                var deleteResult = indexApi.Delete(deleteRequest);

                Console.WriteLine(deleteResult + Environment.NewLine);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }
        }
    }
}
