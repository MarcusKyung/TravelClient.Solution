using Microsoft.AspNetCore.Mvc;
using TravelClient.Models;

namespace TravelClient.Controllers;

public class ReviewsController : Controller
{
  public IActionResult Index()
  {
    List<Review> reviews = Review.GetReviews();
    return View(reviews);
  }

  //pagination below
  public IActionResult Page1()
  {
      List<Review> reviews = Review.GetPages(1,5);
      return View(reviews);
  }

  public IActionResult Page2()
  {
      List<Review> reviews = Review.GetPages(2,5);
      return View(reviews);
  }

  public IActionResult Page3()
  {
      List<Review> reviews = Review.GetPages(3,5);
      return View(reviews);
  }
  //end pagination

  public IActionResult Details(int id)
  {
    Review review = Review.GetDetails(id);
    return View(review);
  }

  public ActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public ActionResult Create(Review review)
  {
    Review.Post(review);
    return RedirectToAction("Index");
  }

  public ActionResult Edit(int id)
  {
    Review review = Review.GetDetails(id);
    return View(review);
  }

  [HttpPost]
  public ActionResult Edit(Review review)
  {
    Review.Put(review);
    return RedirectToAction("Details", new { id = review.ReviewId});
  }

  public ActionResult Delete(int id)
  {
    Review review = Review.GetDetails(id);
    return View(review);
  }

  [HttpPost, ActionName("Delete")]
  public ActionResult DeleteConfirmed(int id)
  {
    Review.Delete(id);
    return RedirectToAction("Index");
  }
}