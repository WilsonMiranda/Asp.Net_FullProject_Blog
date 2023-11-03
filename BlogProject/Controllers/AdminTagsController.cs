using BlogProject.Data;
using BlogProject.Models.Domain;
using BlogProject.Models.ViewModels;
using BlogProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogProject.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly ITagRepository tagRepository;

        //ctor to creat a constructor
        public AdminTagsController(ITagRepository tagRepository)
        {
            this.tagRepository = tagRepository;
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

            await tagRepository.AddAsync(tag);

            return RedirectToAction("List");
        }

        [HttpGet]
        [ActionName("List")]
        //asyncronous function
        public async Task<IActionResult> List()
        { 
            //use dbContext from TagRepository to read the tags
            var tags = await tagRepository.GetAllAsync();
        
            return View(tags);
        }

        [HttpGet]
        //asyncronous function
        public async Task<IActionResult>  Edit(Guid id)
        {

            var tag = await tagRepository.GetAsync(id);

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
        //asyncronous function
        public async Task<ActionResult>  Edit(EditTagRequest editTagRequest) 
        {
           var tag = new Tag
            {
                Id = editTagRequest.Id,
                Name = editTagRequest.Name,
                DisplayName = editTagRequest.DisplayName
            };

           var updatedTag = await tagRepository.UpdateAsync(tag);

            if(updatedTag != null)
            {
                //show a success notification
            }
            else
            {
                //show a error notification
            }

            return RedirectToAction("List", new {id = editTagRequest.Id});

        }

        [HttpPost]
        //asyncronous function
        public async Task<ActionResult> Delete(EditTagRequest editTagRequest)
        {
        
            var deletedTag = await tagRepository.DeleteAsync(editTagRequest.Id);

            if (deletedTag != null)
            {
                //show a success notification
                return RedirectToAction("List");
            }
         
            //show a error notification
            return RedirectToAction("List", new {id = editTagRequest.Id});
        }

    }
}
