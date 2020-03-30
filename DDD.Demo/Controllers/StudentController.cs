using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD.Application.Interface;
using DDD.Application.ViewModel;
using DDD.Domain.Notification;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DDD.Demo.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentAppService _studentAppService;
        private readonly DomainNotificationHandler _notifications;
        public StudentController(IStudentAppService studentAppService, INotificationHandler<DomainNotification> notifications)
        {
            _studentAppService = studentAppService;
            _notifications = notifications as DomainNotificationHandler;
        }

        public IActionResult Index()
        {
            return View(_studentAppService.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentViewModel studentViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(studentViewModel);
                
                _studentAppService.Register(studentViewModel);

                if (!_notifications.HasNotifications())
                    ViewBag.Success = "Student Registered!";

                return View(studentViewModel);
            }
            catch (Exception e)
            {
                return View(e.Message);
            }
        }
    }
}