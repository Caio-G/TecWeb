using System;  
using System.Collections.Generic;  
using System.Diagnostics;  
using System.Linq;  
using System.Threading.Tasks;  
using Microsoft.AspNetCore.Mvc;  
using MVCAdoDemo.Models;    

namespace MVCAdoDemo.Controllers  
{      
    public class EmpregadoController : Controller      
    {          
        EmpregadoDataAccessLayer objempregado = new EmpregadoDataAccessLayer();            
        public IActionResult Index()          
        {              
            List<Empregado> lstEmpregado = new List<Empregado>();              
            lstEmpregado = objempregado.GetAllEmpregados().ToList();                
            return View(lstEmpregado);          
        }

        [HttpGet]  public IActionResult Create()  
    {      
        return View();  
    }    
    [HttpPost]  [ValidateAntiForgeryToken]  public IActionResult Create([Bind] Empregado empregado)  
    {      
        if (ModelState.IsValid)      
        {          
            objempregado.AddEmpregado(empregado);          
            return RedirectToAction("Index");      
        }      
        return View(empregado);  
    }

    [HttpGet]  public IActionResult Edit(int id)  
    {      
        if (id == null)      
        {          
            return NotFound();     
        }      
        Empregado empregado = objempregado.GetEmpregadoData(id);        
        if (empregado == null)      
        {          
            return NotFound();      
        }      
        return View(empregado);  
    }    
    [HttpPost]  [ValidateAntiForgeryToken]  public IActionResult Edit(int id, [Bind]Empregado empregado)  
    {      
        if (id != empregado.ID)      
        {          
            return NotFound();      
        }      
        if (ModelState.IsValid)      
        {          
            objempregado.UpdateEmpregado(empregado);          
            return RedirectToAction("Index");      
        }      
        return View(empregado);  
    }

    [HttpGet]  public IActionResult Details(int id)  
    {      
        if (id == null)      
        {          
            return NotFound();      
        }      
        Empregado empregado = objempregado.GetEmpregadoData(id);        
        if (empregado == null)      
        {          
            return NotFound();      
        }      
        return View(empregado);  
    }

    [HttpGet]  public IActionResult Delete(int id)  
    {      
        if (id == null)      
        {          
            return NotFound();      
        }      
        Empregado empregado = objempregado.GetEmpregadoData(id);        
        if (empregado == null)      
        {          
            return NotFound();      
        }      
        return View(empregado);  
    }    
    [HttpPost, ActionName("Delete")]  [ValidateAntiForgeryToken]  public IActionResult DeleteConfirmed(int id)  
    {      
        objempregado.DeleteEmpregado(id);      
        return RedirectToAction("Index");  
    }       
    }
}  
    



