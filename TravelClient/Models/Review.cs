using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models
{
  public class Review
  {
    public int ReviewId { get; set; }
    public string Destination { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string UserName { get; set; }
    [Required]
    [Range(1, 10, ErrorMessage = "Please enter a valid rating (1-10).")]
    public int Rating { get; set; }
    public string Description { get; set; }
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime Date { get; set; }

    public static List<Review> GetReviews()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Review> reviewList = JsonConvert.DeserializeObject<List<Review>>(jsonResponse.ToString());

      return reviewList;
    }

    //pagination below
    public static List<Review> GetPages(int pageNumber, int pageSize)
    {
      var apiCallTask = ApiHelper.GetPage(pageNumber, pageSize);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Review> reviewList = JsonConvert.DeserializeObject<List<Review>>(jsonResponse.ToString());

      return reviewList;
    }
    //end pagination

    public static Review GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Review review = JsonConvert.DeserializeObject<Review>(jsonResponse.ToString());

      return review;
    }

    public static void Post(Review review)
    {
      string jsonReview = JsonConvert.SerializeObject(review);
      ApiHelper.Post(jsonReview);
    }

    public static void Put(Review review)
    {
      string jsonReview = JsonConvert.SerializeObject(review);
      ApiHelper.Put(review.ReviewId, jsonReview);
    }

    public static void Delete(int id)
    {
      ApiHelper.Delete(id);
    }
  }
}