using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZombieParty_Models;

namespace ZombieParty_DataAccess.Data
{
  public class ZombiePartyDbContext: DbContext
  {
    public ZombiePartyDbContext(DbContextOptions<ZombiePartyDbContext> options) : base(options)
    {

    }

    public DbSet<Zombie> Zombie { get; set; }
    public DbSet<ZombieType> ZombieType { get; set; }
    public DbSet<HuntingLog> HuntingLog { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

      //// ZombieHuntingLog: clé composée (composite key)
      //modelBuilder.Entity<ZombieHuntingLog>().HasKey(zh => new { zh.Zombie_Id, zh.HuntingLog_Id });

      //// WeaponHunter: clé composée (composite key)
      //modelBuilder.Entity<WeaponHunter>().HasKey(wh => new { wh.Weapon_Id, wh.Hunter_Id });
    }
  }
}
