using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProyectoRefriPolar.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProyectoRefriPolar.Services
{
    class EncargosService
    {
        //GET
        public ObservableCollection<Encargos> GetEncargos()
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("encargos", Method.Get);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<ObservableCollection<Encargos>>(response.Content);
        }
        public Encargos GetEncargo(int id)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"encargos/{id}", Method.Get);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Encargos>(response.Content);
        }
        public int GetMaxId()
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("encargos/maxid", Method.Get);
            var response = client.Execute(request);
            JArray jsonArray = JArray.Parse(response.Content);
            int maxId = (int)jsonArray[0]["maxid"];
            return maxId;
        }

        //POST
        public RestResponse PostEncargo(Encargos encargoNuevo)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("encargos", Method.Post);
            string data = JsonConvert.SerializeObject(encargoNuevo);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }

        //PUT
        public RestResponse PutEncargo(Encargos encargoActualizar)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("encargos", Method.Put);
            if(encargoActualizar.idEncargado == null)
            {
                encargoActualizar.idEncargado = GetEncargo(encargoActualizar.id).idEncargado;
            }
            string data = JsonConvert.SerializeObject(encargoActualizar);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }

        //DELETE
        public RestResponse DeleteEncargo(int id)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"encargos/{id}", Method.Delete);
            var response = client.Execute(request);
            return response;
        }
    }
}
