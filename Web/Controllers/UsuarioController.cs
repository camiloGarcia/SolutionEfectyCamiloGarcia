using Domain;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            List<UsuarioViewModel> usuarios=GetUsers();
            return View(usuarios);
        }

        private List<UsuarioViewModel> GetUsers()
        {
            List<UsuarioViewModel> result = new List<UsuarioViewModel>();
            try
            {
                var client = new RestClient("https://localhost:44358/api/Usuarios");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                if (response!=null && !string.IsNullOrEmpty(response.Content))
                {
                    result = JsonConvert.DeserializeObject<List<UsuarioViewModel>>(response.Content);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}{Environment.NewLine}{e.StackTrace}");
            }
            return result;
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View(new UsuarioViewModel());
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(usuarioViewModel);
                }
                if (!SaveUser(usuarioViewModel))
                {
                    ModelState.AddModelError("", "Error al guardar el usuario");
                }                    
                return RedirectToAction("Index");

            }
            catch
            {
                return View();
            }
        }

        private bool SaveUser(UsuarioViewModel usuarioViewModel)
        {
            var result = false;
            try
            {
                var client = new RestClient("https://localhost:44358/api/Usuarios");
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                var body = JsonConvert.SerializeObject(usuarioViewModel);
                request.AddParameter("application/json", body, ParameterType.RequestBody);
                IRestResponse response = client.Execute(request);
                if (response.StatusCode==System.Net.HttpStatusCode.OK)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"{e.Message}{Environment.NewLine}{e.StackTrace}");
            }
            return result;
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
