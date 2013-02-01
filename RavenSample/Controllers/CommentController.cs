using Raven.Client;
using Raven.Client.Embedded;
using Raven.Client.Linq;
using RavenSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RavenSample.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/

        public ActionResult Index()
        {
            IRavenQueryable<Comment> query = null;

            using (IDocumentStore instance = new EmbeddableDocumentStore { DataDirectory = @"~\Database" })
            {
                instance.Initialize();

                using (IDocumentSession session = instance.OpenSession())
                {
                    query = session.Query<Comment>();
                }
            }

            return View(query.ToList());
        }

        public ActionResult Add()
        {
            using (IDocumentStore instance = new EmbeddableDocumentStore { DataDirectory = @"~\Database" })
            {
                instance.Initialize();

                using (IDocumentSession session = instance.OpenSession())
                {
                    var comment = new Comment
                    {
                        Content = "test",
                        Commenter = "hogehoge",
                        CreateAt = DateTime.Now,
                    };

                    session.Store(comment);
                    session.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
