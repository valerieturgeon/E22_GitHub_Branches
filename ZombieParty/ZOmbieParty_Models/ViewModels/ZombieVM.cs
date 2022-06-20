using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ZombieParty_Models.ViewModels
{
  public class ZombieVM
  {
    public Zombie Zombie { get; set; }
    public IEnumerable<SelectListItem> ZombieTypeSelectList { get; set; }

  }
}
