using Newtonsoft.Json;
using ProyectoRefriPolar.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRefriPolar.Services
{
    class CategoriaProfesionalService
    {
        //GET
        public ObservableCollection<CategoriaProfesional> GetCategoriasProfesionales()
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("categoriasprofesionales", Method.Get);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<ObservableCollection<CategoriaProfesional>>(response.Content);
        }
        //POST
        public RestResponse PostCliente(CategoriaProfesional categoriaActualizar)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("categoriasprofesionales", Method.Post);
            string data = JsonConvert.SerializeObject(categoriaActualizar);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }

        //PUT
        public RestResponse PutEncargo(CategoriaProfesional categoriaActualizar)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("categoriasprofesionales", Method.Put);
            string data = JsonConvert.SerializeObject(categoriaActualizar);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }

        //DELETE
        public RestResponse DeleteEncargo(string cod)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"categoriasprofesionales/{cod}", Method.Delete);
            var response = client.Execute(request);
            return response;
        }
    }
}
