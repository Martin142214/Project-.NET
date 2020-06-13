using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CommentsController : Controller
    {
        private ICommentRepository _commentRepository;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public CommentsController(ICommentRepository commentRepository, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _commentRepository = commentRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IActionResult> ProductComments(string searchString)
        {

            var comment = _commentRepository.GetAllComments();

            if (!String.IsNullOrEmpty(searchString))
            {
                comment = comment.Where(p => p.Title.Contains(searchString));
            }

            return View(comment);
        }

        public IActionResult Find(string searchString)
        {

            var comments = from p in _commentRepository.GetAllComments()
                           select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                comments = comments.Where(p => p.Title.Contains(searchString));
            }
            return View(comments);
        }

        [HttpGet]

        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CommentCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Comments comment = new Comments
                {
                    Title = model.Title,
                    Content = model.Content,
                    Product = model.Product,
                    User = model.User
                };
                Comments newComment = _commentRepository.Add(comment);
                return RedirectToAction("ProductDetails", new { id = newComment.ID });
            }

            return View();
        }       
        
    }
}