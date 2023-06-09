using System.Threading.Tasks;
using RestSharp;

namespace TravelClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/v2/reviews", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    //trying pagination below
    public static async Task<string> GetPage(int pageNumber, int pageSize)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/v2/reviews?pageNumber={pageNumber}&pageSize={pageSize}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }
    //end pagination

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/v2/reviews/{id}", Method.Get);
      RestResponse response = await client.GetAsync(request);
      return response.Content;
    }

    public static async void Post(string newReview)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/v2/reviews", Method.Post);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newReview);
      await client.PostAsync(request);
    }

    public static async void Put(int id, string newReview)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/v2/reviews/{id}", Method.Put);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newReview);
      await client.PutAsync(request);
    }

    public static async void Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/");
      RestRequest request = new RestRequest($"api/v2/reviews/{id}", Method.Delete);
      request.AddHeader("Content-Type", "application/json");
      await client.DeleteAsync(request);
    }
  }
}