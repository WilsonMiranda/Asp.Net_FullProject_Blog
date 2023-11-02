using BlogProject.Data;
using BlogProject.Models.Domain;
using BlogProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Controllers
{
    public class AdminTagsController : Controller
    {
        //create a private field to hold the context
        private readonly BlogDbContext blogDbContext;

        //ctor to creat a constructor
        public AdminTagsController(BlogDbContext blogDbContext)
        {
            this.blogDbContext = blogDbContext;
        }

        [HttpGet]
        //the name of the view need to be the same as the name of the method in this case  Add
        public IActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        [ActionName("Add")]
        //make the funcion asyncronous using async and Task
        public async Task<IActionResult> Add(AddTagRequest addTagRequest)
        {
            //mapping AddTagRequest to Tag domain model
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName
            };


            //acess the Tags property with async await and add the tag
            await blogDbContext.Tags.AddAsync(tag);
            await blogDbContext.SaveChangesAsync(); //save changes to the DB


            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        //asyncronous function
        public async Task<IActionResult> List()
        { 
            //use dbContext to read the tags
            var tags = await blogDbContext.Tags.ToListAsync();
        
            return View(tags);
        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {

            var tag = blogDbContext.Tags.FirstOrDefault(x => x.Id == id);

            if (tag != null)
            {
                var editTagRequest = new EditTagRequest
                {
                    Id = tag.Id,
                    Name = tag.Name,
                    DisplayName = tag.DisplayName
                };

                return View(editTagRequest);
            }


            return View(null);
        }

        [HttpPost]
        public ActionResult Edit(EditTagRequest editTagRequest) 
        {
            var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

           var existingTag = blogDbContext.Tags.Find(tag.Id);

            if (existingTag != null)
            {
                existingTag.Name = tag.Name;
                existingTag.DisplayName = tag.DisplayName;

                //save changes
                blogDbContext.SaveChanges();

                //[TODO LATER]:show success notification
                return RedirectToAction("List", new { id = editTagRequest.Id});
            }

            //[TODO LATER]:show error notification
            return RedirectToAction("Edit", new {id = editTagRequest.Id});

        }

        [HttpPost]
        public IActionResult Delete(EditTagRequest editTagRequest)
        {
            var tag = blogDbContext.Tags.Find(editTagRequest.Id);

            if (tag != null)
            {
                blogDbContext.Tags.Remove(tag);
                blogDbContext.SaveChanges();

                //[TODO LATER]show a success notification
                return RedirectToAction("List");
            }

            //[TODO LATER]show a error notification
            return RedirectToAction("List", new {id = editTagRequest.Id});
        }

    }
}
