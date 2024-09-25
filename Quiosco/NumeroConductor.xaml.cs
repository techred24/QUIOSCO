﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quiosco
{
    public partial class NumeroConductor : Page
    {
        private ApiClient apiClient;
        public record class Todo(
            int? UserId = null,
            int? Id = null,
            string? Title = null,
            bool? Completed = null);
        //UserControl loaderComponent;
        
        public NumeroConductor()
        {
            InitializeComponent();
            apiClient = new ApiClient();
        }
        //private static HttpClient sharedClient = new()
        //{
        //    BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
        //};
        //private String token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiI1ZDg5NzY0MzZkMjgxZDRlYzMwNTk1N2EiLCJyb2wiOnsiY29kaWdvIjoiOTkifSwiaWF0IjoxNzI1NzY1NDcyfQ.3LxcohkqWeVYiANLvhAL_OjvMqsCnhLRH4vkvtkRa7I";
        //private static HttpClient baseUrl = new()
        //{
        //    BaseAddress = new Uri("https://demo.bustrack.mx/smg/"),
        //};
        
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Detalle detallePage = new Detalle();
            //this.NavigationService.Navigate(detallePage);
            //var that = this;

            UserControl loaderComponent = new Loader();
            //loader.Content = loaderComponent;


            ////using HttpResponseMessage response = await sharedClient.GetAsync("todos/3");
            //var todos = await sharedClient.GetFromJsonAsync<List<Todo>>("todos?userId=1&completed=false");
            ////todos?.ForEach(todo => label.Content =  todo);

            //using StringContent jsonContent = new(
            //    JsonSerializer.Serialize(new
            //    {
            //        usuario = "soporteadmin",
            //        contrasena = "RinRanRun2020"
            //    }),
            //    Encoding.UTF8,
            //    "application/json");

            ////using HttpResponseMessage loginResponse = await baseUrl.PostAsync("api/usuario/loginV2/", jsonContent);
            ////using HttpResponseMessage login = await baseUrl.PostAsJsonAsync("api/usuario/loginV2/", jsonContent);
            ////var jsonLoginResponse = await loginResponse.Content.ReadAsStringAsync();
            //var jsonBody = new
            //{
            //    usuario = "soporteadmin",
            //    contrasena = "RinRanRun2020"
            //};
            //baseUrl.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            //using HttpResponseMessage responseForLogin = await baseUrl.PostAsJsonAsync("api/usuario/loginV2/", jsonBody);
            //var stringResponseForLogin = await responseForLogin.Content.ReadAsStringAsync();            
            ////label.Content = jsonLoginResponse;
            //label.Content = stringResponseForLogin;

            //var jsonResponse = await response.Content.ReadAsStringAsync();
            //ingresar.Content = $"{jsonResponse.Length}";
            //label.Content = todos;
            //Console.WriteLine($"{jsonResponse}\n");
            Console.WriteLine($"IMPRIMIENDO EN LA CONSOLA");

            //using HttpResponseMessage rolesResponse = await baseUrl.GetAsync("api/roles/");
            //var stringResponseForRoles = await rolesResponse.Content.ReadAsStringAsync();
            //label.Content = stringResponseForRoles;
            string rolesResponse = await apiClient.GetAsync("api/roles/");
            //label.Content = rolesResponse;



            //await Task.Delay(3500);
            //loader.Content = null;
            //this.NavigationService.Navigate(detallePage);
        }
        private void Button_Click_Hide(object sender, RoutedEventArgs e)
        {
            //loader.Content = null;
        }
    }
}
