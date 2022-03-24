using DotNetCore6WebMVCPractice.Data;
using DotNetCore6WebMVCPractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore6WebMVCPractice.Controllers;

public class CategoryController : Controller{

    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db){
        _db = db;
    }
    public IActionResult Index(){
        IEnumerable<Category> objCategoryList = _db.Categories;
        return View(objCategoryList );
    }

    //Get
    public IActionResult Create(){
        return View();
    }
    //Post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category obj){
        if(obj.Name == obj.DisplayOrder.ToString()){
            //custom validation error messages
            ModelState.AddModelError("CustomError", "The display order cannot be same as the name.");
        }
        if(ModelState.IsValid){
            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created!";
            return RedirectToAction("Index"); 
        }
         return View(obj); 
    }

    //get
    public IActionResult Edit(int? id){
        if(id == null || id == 0){
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u=>u.Id==id);
        return View(categoryFromDb); 
    }

    //post
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Category obj){
        if(obj.Name == obj.DisplayOrder.ToString()){
            //custom validation error messages
            ModelState.AddModelError("CustomError", "The display order cannot be same as the name.");
        }
        if(ModelState.IsValid){
            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["success"] = "Category updated!";
            return RedirectToAction("Index"); 
        }
         return View(obj); 
    }

      public IActionResult Delete(int? id){
        if(id == null || id == 0){
            return NotFound();
        }
        var categoryFromDb = _db.Categories.Find(id);
        //var categoryFromDbFirst = _db.Categories.FirstOrDefault(u=>u.Id==id);
        //var categoryFromDbSingle = _db.Categories.SingleOrDefault(u=>u.Id==id);
        return View(categoryFromDb); 
    }

    //post
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(Category obj){
            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted!";
            return RedirectToAction("Index"); 
    }
}