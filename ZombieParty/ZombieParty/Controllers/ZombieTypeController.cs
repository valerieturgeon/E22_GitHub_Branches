using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieParty_Models;
using ZombieParty_DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace ZombieParty.Controllers
{
  public class ZombieTypeController : Controller
  {
        private readonly ZombiePartyDbContext _db;

        public ZombieTypeController(ZombiePartyDbContext zombiePartyDbContext, IWebHostEnvironment webHostEnvironment)
    {
      _db = zombiePartyDbContext;
    }


    public async Task<IActionResult> Index()
    {
     
      IEnumerable<ZombieType> objList = await _db.ZombieType.ToListAsync();
      return View(objList);
    }

    //GET CREATE
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(ZombieType zombieType)
    {
      if (ModelState.IsValid)
      {
       await _db.ZombieType.AddAsync(zombieType);
       await _db.SaveChangesAsync(); // pour que les changements soient appliqués dans BD

        return RedirectToAction("Index");
      }
      return View(zombieType);
    }


    //GET - EDIT
    public async Task<IActionResult> Edit(int? id)
    {
      //retrouver le bon enr selon le id et le passer à la view, si il existe
      if (id == null || id == 0)
      {
        return NotFound();
      }
      // _db.ZombieType retourne tous les enregistrements
      // Find() cherche avec la clé primaire
      var obj = await _db.ZombieType.FindAsync(id.GetValueOrDefault());
      if (obj == null)
      {
        return NotFound();
      }
      return View(obj);
    }


    //POST EDIT
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> Edit(ZombieType zombieType)
    {
      {
        if (ModelState.IsValid)
        {
          _db.Update(zombieType);
          await _db.SaveChangesAsync();

          return RedirectToAction("Index");
        }
        return View(zombieType);
      }
    }

    //GET DELETE
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || id == 0)
        {
          return NotFound();
        }

        var obj = await _db.ZombieType.FindAsync(id.GetValueOrDefault());
        if (obj == null)
        {
          return NotFound();
        }

        return View(obj);
      }

    //POST DELETE
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public async Task<IActionResult> DeletePost(int? id)
    {
        var obj = await _db.ZombieType.FindAsync(id.GetValueOrDefault());
        if (obj == null)
        {
          return NotFound();
        }

            _db.ZombieType.Remove(obj);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
      }

  }
}
