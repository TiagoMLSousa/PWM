﻿using System;
using System.Linq;
using System.Web.Security;
using System.Web.Services;
using Newtonsoft.Json;
using System.Web;
using System.Web.UI.WebControls;

namespace PersonalWorkManagerWeb
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        [WebMethod]
        public static string LoginJSON(string Login, string Password, bool Persistable) {
            using (var objctx = new PWMEntities()) {
                var resource = (from u in objctx.Resource
                                where (u.Login.ToLower() == Login.ToLower()) && (u.Password == Password)
                                select new {
                                    Id = u.Id,
                                    Login = u.Login,
                                    Name = u.Name,
                                    IdStatus = u.IdStatus
                                });
                string json = null;
                if (resource.ToList().Count() > 0) {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Login, DateTime.Now, DateTime.Now.AddMinutes(60), Persistable, "member");
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    json = JsonConvert.SerializeObject(resource.ToList()[0]);
                }
                return json;
            }
        }

    }
}
