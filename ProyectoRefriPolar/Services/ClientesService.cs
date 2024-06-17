using ProyectoRefriPolar.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    class ClientesService
    {
        //GET
        public ObservableCollection<Clientes> GetClientes()
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("clientes", Method.Get);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<ObservableCollection<Clientes>>(response.Content);
        }
        public Clientes GetCliente(int id)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"clientes/{id}", Method.Get);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Clientes>(response.Content);
        }
        public int GetMaxId()
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("clientes/maxid", Method.Get);
            var response = client.Execute(request);
            JArray jsonArray = JArray.Parse(response.Content);
            int maxId = (int)jsonArray[0]["maxid"];
            return maxId;
        }
        //POST
        public RestResponse PostCliente(Clientes clienteNuevo)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("clientes", Method.Post);
            string data = JsonConvert.SerializeObject(clienteNuevo);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }

        //PUT
        public RestResponse PutCliente(Clientes clienteActualizar)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("clientes", Method.Put);
            string data = JsonConvert.SerializeObject(clienteActualizar);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.ExecutePut(request);
            return response;
        }

        //DELETE
        public RestResponse DeleteCliente(int id)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"clientes/{id}", Method.Delete);
            var response = client.Execute(request);
            return response;
        }
    }
}
