using MN_WEB.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;

namespace MN_WEB.Models
{
    public class CursoModel
    {
        string urlWebApi = ConfigurationManager.AppSettings["urlWebApi"].ToString();

        public List<CursoEnt> ConsultarCursos()
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ConsultarCursos";
                string token = HttpContext.Current.Session["TokenSesion"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<List<CursoEnt>>().Result;
                }

                return new List<CursoEnt>();
            }
        }

        public CursoEnt ConsultarCurso(long q)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ConsultarCurso?q=" + q;
                string token = HttpContext.Current.Session["TokenSesion"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage resp = client.GetAsync(url).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<CursoEnt>().Result;
                }

                return null;
            }
        }

        public long RegistrarCurso(CursoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/RegistrarCurso";
                string token = HttpContext.Current.Session["TokenSesion"].ToString();
                JsonContent body = JsonContent.Create(entidad); //serializar

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage resp = client.PostAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<long>().Result;
                }

                return 0;
            }
        }

        public int ActualizarCurso(CursoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ActualizarCurso";
                string token = HttpContext.Current.Session["TokenSesion"].ToString();
                JsonContent body = JsonContent.Create(entidad); //serializar

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage resp = client.PutAsync(url, body).Result;

                if (resp.IsSuccessStatusCode)
                {
                    return resp.Content.ReadFromJsonAsync<int>().Result;
                }

                return 0;
            }
        }        

        public void ActualizarRuta(CursoEnt entidad)
        {
            using (var client = new HttpClient())
            {
                string url = urlWebApi + "api/ActualizarRuta";
                string token = HttpContext.Current.Session["TokenSesion"].ToString();
                JsonContent body = JsonContent.Create(entidad); //serializar

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage resp = client.PutAsync(url, body).Result;
            }
        }
        

    }
}