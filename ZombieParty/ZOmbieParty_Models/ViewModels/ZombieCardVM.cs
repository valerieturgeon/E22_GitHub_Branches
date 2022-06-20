using System;
using System.Collections.Generic;
using System.Text;

namespace ZombieParty_Models.ViewModels
{
 public class ZombieCardVM
  {
    public IEnumerable<Zombie> Zombies { get; set; }
    public IEnumerable<ZombieType> ZombieTypes { get; set; }
  }
}
