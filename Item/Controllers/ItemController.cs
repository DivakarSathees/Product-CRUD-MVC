using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Item.Models;

namespace Item.Controllers
{
    public class ItemController : Controller
{
    private static List<ItemModel> _items = new List<ItemModel>();
    // private static List<Person> _persons = new List<Person>();

    public IActionResult Index()
    {
        return View(_items);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(ItemModel item)
    {
        // Console.WriteLine(item);
        // item.Id = _items.Count + 1;
        // _items.Add(item);
        // return RedirectToAction("Index");
    //     int newId = _items.Max(i => i.Id) + 1; // generate new unique Id
    // item.Id = newId;
    // _items.Add(item);

    // return RedirectToAction("Index", newItems);
    //   var newItems = new List<ItemModel>(_items);


    // int newId = _items.Max(i => i.Id) + 1; // generate new unique Id
    // item.Id = newId;
    // _items.Add(item);
    // return View("Index", _items);

    item.Id = _items.Count + 1;
        _items.Add(item);
        // return RedirectToAction(nameof(Index));
        return View("Index", _items);

    }

    // public IActionResult Edit(int id)
    // {
    //     var item = _items.FirstOrDefault(i => i.Id == id);
    //     if (item == null)
    //     {
    //         return NotFound();
    //     }
    //     return View(item);
    // }

    // [HttpPost]
    // public IActionResult Edit(ItemModel item)
    // {
    //     var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
    //     if (existingItem == null)
    //     {
    //         return NotFound();
    //     }
    //     existingItem.Name = item.Name;
    //     existingItem.Quantity = item.Quantity;
    //     return RedirectToAction("Index", _items);
    // }

    public IActionResult Edit(int id)
{
    var item = _items.FirstOrDefault(i => i.Id == id);
    if (item == null)
    {
        return NotFound();
    }
    return View(item);
}

[HttpPost]
public IActionResult Edit(ItemModel item)
{
    var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
    if (existingItem == null)
    {
        return NotFound();
    }
    
    Console.WriteLine($"Existing Item: Id={existingItem.Id}, Name={existingItem.Name}, Quantity={existingItem.Quantity}");
    Console.WriteLine($"New Item: Id={item.Id}, Name={item.Name}, Quantity={item.Quantity}");
Console.WriteLine(existingItem.Id - 1);
    existingItem.Name = item.Name;
    existingItem.Quantity = item.Quantity;
    _items[existingItem.Id - 1].Name=item.Name;
    _items[existingItem.Id - 1].Quantity=item.Quantity;
    Console.WriteLine( _items[existingItem.Id - 1].Name);

    return RedirectToAction("Index", _items);
}

    public IActionResult Delete(int id)
    {
        var item = _items.FirstOrDefault(i => i.Id == id);
        if (item == null)
        {
            return NotFound();
        }
        _items.Remove(item);
        return RedirectToAction("Index");
    }
}

}
