using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using WebApplication9.Models;


namespace WebApplication9.Controllers
{
	public class HomeController : Controller
	{
		private Model1 db = new Model1();
		public ActionResult Index()
		{
			return View();
		}
		[Authorize]
		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}
		[Authorize]
		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		public ActionResult Login(FormCollection values)
		{
			var user1=User.Identity.GetUserName();
			var role = values["role"].ToString();
			var user = values["username"].ToString();
				if (role == "user")
				{
				if (user1 == user)
				{
					Session["user"] = user;
					Session["role"] = "user";
					return Redirect("/Home/home");
				}
				else
				{
					return View("Index");
				}
					
				}
				else 
				{
					if (user == null)
					{
						return View("Index");
					}
					else
					{
					if (user1 == user)
					{
						Session["user"] = user;
						Session["role"] = "admin";
						return Redirect("/Home/admin");
					}
					else {
						return View("Index");
					}
				}
				}
				
		}

		public ActionResult home()
		{
			var sel = db.Election;
			if (Session["role"] == null)
				return View("Index");

			var a = Session["role"].ToString();
			
				return View(sel.ToList());
			
		}
		public ActionResult select(int id)
		{
			var query = db.State.Where(i1 => i1.ElectionId.Equals(id));
			var t = db.Election.Where(i1 => i1.ElectionId.Equals(id)).FirstOrDefault();

			var m = t.ElectionType;
			string p = m.ToString();
			ViewBag.message = p;
			return View(query.ToList());
		}
		public ActionResult details(int id)
		{
			var query = db.Election.Where(i1 => i1.ElectionId.Equals(id)).FirstOrDefault();
			return View(query);
		}
		public ActionResult Selected(int id)
		{
			var t = db.State.Where(i1 => i1.StateId.Equals(id)).FirstOrDefault();
			var m = t.StateName;
			string p = m.ToString();
			ViewBag.message = p;
			var query = db.Politics.Where(i1 => i1.StateId.Equals(id));
			return View(query.ToList());
		}
		public ActionResult detailss(int id)
		{
			var query = db.Politics.Where(i1 => i1.PoliticsId.Equals(id)).FirstOrDefault();
			int i = query.StateId;
			var q1 = db.State.Where(i1 => i1.StateId.Equals(i)).FirstOrDefault();
			var m = q1.StateName;
			string p = m.ToString();
			ViewBag.message = p;
			return View(query);
		}

		public ActionResult admin()
		{
			return View();
		}


	}
}