﻿namespace PersonalWorkManagerWeb
{

    using System.Linq;
    using System.Web.Services;
    using Newtonsoft.Json;

    /// <summary>
    /// Summary description for SiteMaster1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class SiteMaster1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string SearchAllJSON(string Text)
        {
            using (var objCtx = new PWMEntities())
            {
                var text = Text.ToLower();

                /*var records = (from p in objCtx.Project
                               where p.Code.ToLower().Contains(text)
                                  || p.Name.ToLower().Contains(text)
                                  || p.Description.ToLower().Contains(text)
                               select new
                               {
                                   Type = "Projecto",
                                   Id = String.Join("Projecto_", p.Id),  <-- Does not work
                                   Name = p.Name,
                                   Description = p.Description
                               })
                              .Union
                              (from p in objCtx.Parameter
                               where p.Name.ToLower().Contains(text)
                                  || p.Value.ToLower().Contains(text)
                                  || p.Description.ToLower().Contains(text)
                               select new
                               {
                                   Type = "Parametro",
                                   Id = String.Join("Parametro_", p.Id),
                                   Name = p.Name,
                                   Description = p.Description
                               });*/

                var records = objCtx.Project.ToList()
                    .Where(p => p.Code.ToLower().Contains(text)
                             || p.Name.ToLower().Contains(text)
                             || (p.Description != null && p.Description.ToLower().Contains(text)))
                    .Select(p => new
                    {
                        Type = "Projecto",
                        Id = "Projecto_" + p.Id.ToString(),
                        Name = p.Code + " " + p.Name,
                        Description = p.Description
                    })
                    .Union(objCtx.Parameter.ToList()
                    .Where(p => p.Name.ToLower().Contains(text)
                            || (p.Value == null || p.Value.ToLower().Contains(text))
                            || (p.Description != null && p.Description.ToLower().Contains(text)))
                    .Select(p => new
                    {
                        Type = "Parametro",
                        Id = "Parametro_" + p.Id.ToString(),
                        Name = p.Name,
                        Description = p.Description
                    }))
                    .Union(objCtx.Resource.ToList()
                    .Where(p => p.Name.ToLower().Contains(text)
                             || p.Login.ToLower().Contains(text))
                    .Select(p => new
                    {
                        Type = "Recurso",
                        Id = "Recurso_" + p.Id.ToString(),
                        Name = p.Name,
                        Description = p.Login
                    }))
                    .Union(objCtx.Status.ToList()
                    .Where(p => p.Name.ToLower().Contains(text)
                             || p.Description.ToLower().Contains(text))
                    .Select(p => new
                    {
                        Type = "Estado",
                        Id = "Estado_" + p.Id.ToString(),
                        Name = p.Name,
                        Description = p.Description
                    }));

                string json = JsonConvert.SerializeObject(records);
                return json;
            }
        }

    }
}
