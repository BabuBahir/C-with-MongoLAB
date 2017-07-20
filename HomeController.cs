using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
      public class HomeController : Controller
      {
            public async System.Threading.Tasks.Task<ActionResult> Index()
            {
                    try
                    {
                        string connectionString = "mongodb://test:test@ds059306.mlab.com:59306/angular";
                        var client = new MongoClient(connectionString);
                        var database = client.GetDatabase("angular");
                        var collection = database.GetCollection<BsonDocument>("artists");

                        //await collection.InsertOneAsync(new BsonDocument("name", "Rohitas"));
                        await collection.DeleteOneAsync(new BsonDocument("name", "Rohitas"));

                        //var list = await collection.Find(new BsonDocument("shortname", "Hillary_Goldwynn")).ToListAsync();
                        var list = await collection.Find(new BsonDocument()).ToListAsync();

                        foreach (var document in list)
                        {
                            Response.Write(document["name"] + "<br/>");
                        }                
                    }
                     catch (Exception ex)
                    {
                        Response.Write(ex);
                    };
                     return View();
            }          
       }
}
