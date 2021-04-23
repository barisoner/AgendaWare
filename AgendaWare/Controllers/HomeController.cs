using AgendaWare.Models;
using AgendaWareData.Entities;
using AgendaWareData.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaWareUI.Controllers
{
    public class HomeController : Controller
    {
        private IEventRepository _eventRepository;

        public HomeController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event entity)
        {
            if (ModelState.IsValid)
            {
                _eventRepository.CreateEvent(entity);
                return RedirectToAction("Index");
            }
            else
            {
                return View(entity);
            }
        }

        public IActionResult AllEvents()
        {
            var events = _eventRepository.Events.ToList();
            
            return new JsonResult(events);
        }

        public IActionResult Delete(int id)
        {
            _eventRepository.DeleteEvent(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(_eventRepository.GetById(id));
        }

        [HttpPost]
        public IActionResult Details(Event entity)
        {
            if (ModelState.IsValid)
            {
                _eventRepository.UpdateEvent(entity);
                return RedirectToAction("Index");
            }
            else
            {
                return View(entity);
            }
        }
    }
}
