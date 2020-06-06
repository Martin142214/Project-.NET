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

        public CommentsController(ICommentRepository commentRepository, UserManager<IdentityUser> userManager)
        {
            _commentRepository = commentRepository;
            this.userManager = userManager;
        }

        public IActionResult Comments(string searchString)
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

        [HttpGet]

        public new ActionResult Delete(int? id)

        {

            var allComments = _commentRepository.GetAllComments();

            Comments currentComment = allComments.Where(x => x.ID == id).FirstOrDefault();

            var allUsers = userManager.Users;

            IdentityUser currentUser = allUsers.Where(x => x.id == currentComment.ID).FirstOrDefault();

            if (currentUser.ID != SessionDTO.ID && SessionDTO.IsAdmin == false)
            {
                return new ViewResult { ViewName = "InsufficientPermission" };
            }

            else

            {

                return base.Delete(id);

            }

        }

        [HttpPost]

        public new ActionResult Delete(int id)

        {

            List<Comments> allComments = UnitOfWork.UOW.CommentRepository.GetAll();

            Comments currentComment = allComments.Where(x => x.ID == id).FirstOrDefault();

            List<Users> allUsers = UnitOfWork.UOW.UserRepository.GetAll();

            Users currentUser = allUsers.Where(x => x.ID == currentComment.User.ID).FirstOrDefault();

            if (currentUser.ID != SessionDTO.ID && SessionDTO.IsAdmin == false)

            {

                return new ViewResult { ViewName = "InsufficientPermission" };

            }

            else

            {

                List<News> allNews = UnitOfWork.UOW.NewsRepository.GetAll();

                News currentNews = allNews.Where(x => x.ID == NewsDTO.NewsID).FirstOrDefault();

                UnitOfWork.UOW.CommentRepository.Delete(id);

                UnitOfWork.UOW.Save();

                return RedirectToAction("Details", "News", currentNews);

            }

        }
    }
}