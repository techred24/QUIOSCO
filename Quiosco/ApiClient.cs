using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class ApiClient
{
    private static  HttpClient? _httpClient;
    private readonly string _token;

    // Constructor para inicializar el HttpClient y el token
    public ApiClient()
    {
        _httpClient = new HttpClient { BaseAddress = new Uri("https://demo.bustrack.mx/smg/") };
        _token = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJzdWIiOiI1ZDg5NzY0MzZkMjgxZDRlYzMwNTk1N2EiLCJyb2wiOnsiY29kaWdvIjoiOTkifSwiaWF0IjoxNzI3NzM1MDQyfQ.9XHL1qzNKvFUGI7_MFGmK66NwfIc0WyoXeIzojvZlnM";

        // Configurar la cabecera de Authorization con Bearer token
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
    }

    // Método para hacer solicitudes GET
    //public async Task<string> GetAsync(string endpoint)
    public async Task<HttpResponseMessage> GetAsync(string endpoint)
    {
        //using HttpResponseMessage? response = await _httpClient.GetAsync(endpoint);
        HttpResponseMessage? response = await _httpClient.GetAsync(endpoint);
        return response;
        // Lanzar excepción si el estado no es exitoso (opcional)
        //response.EnsureSuccessStatusCode();

        // Devolver el contenido de la respuesta como string
        //return await response.Content.ReadAsStringAsync();
    }

    // Método para hacer solicitudes POST con cuerpo de datos
    public async Task<string> PostAsync<T>(string endpoint, T data)
    {
        using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(endpoint, data);

        // Lanzar excepción si el estado no es exitoso (opcional)
        response.EnsureSuccessStatusCode();

        // Devolver el contenido de la respuesta como string
        return await response.Content.ReadAsStringAsync();
    }

    // Puedes agregar otros métodos como PUT o DELETE si los necesitas
}
