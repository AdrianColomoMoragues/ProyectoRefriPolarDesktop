using CommunityToolkit.Mvvm.ComponentModel;
using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ProyectoRefriPolar.Model;

namespace ProyectoRefriPolar.Services
{
    class EmpleadosService
    {
        //GET
        public ObservableCollection<Empleados> GetEmpleados()
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("empleados", Method.Get);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<ObservableCollection<Empleados>>(response.Content);
        }
        public Empleados GetEmpleado(int id)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"empleados/{id}", Method.Get);
            var response = client.Execute(request);
            return JsonConvert.DeserializeObject<Empleados>(response.Content);
        }
        public int GetMaxId()
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("empleados/maxid", Method.Get);
            var response = client.Execute(request);
            JArray jsonArray = JArray.Parse(response.Content);
            int maxId = (int)jsonArray[0]["maxid"];
            return maxId;
        }
        //POST
        public RestResponse PostEmpleado(Empleados empleadoNuevo)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("empleados", Method.Post);
            string data = JsonConvert.SerializeObject(empleadoNuevo);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }

        //PUT
        public RestResponse PutEmpleado(Empleados empleadoActualizar)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest("empleados", Method.Put);
            string data = JsonConvert.SerializeObject(empleadoActualizar);
            request.AddParameter("application/json", data, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response;
        }

        //DELETE
        public RestResponse DeleteEmpleado(int id)
        {
            var client = new RestClient(Properties.Settings.Default.endpoint);
            var request = new RestRequest($"empleados/{id}", Method.Delete);
            var response = client.Execute(request);
            return response;
        }
    }
}
