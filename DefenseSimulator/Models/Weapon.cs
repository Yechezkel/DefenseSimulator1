using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
namespace DefenseSystem.Data.Models
{
    public class Weapon
    {
        //public Weapon(int weaponId, WeaponType type)
        //{
        //    WeaponId = weaponId;
        //    switch (type)
        //    {
        //        case WeaponType.BallisticMissile:
        //            Speed = 10; 
        //            Radius = 1; 
        //            Counter = CounterType.InterceptorMissile;
        //            break;
        //        case WeaponType.Drone:
        //            Speed = 7; 
        //            Radius = 30; 
        //            Counter = CounterType.ElectronicJamming;
        //            break;
        //        case WeaponType.Rocket:
        //            Speed = 20; 
        //            Radius = 100; 
        //            Counter = CounterType.AntiAirSystem;
        //            break;
        //        default:
        //            throw new ArgumentException("Invalid weapon type", nameof(type));
        //    }
        //}

        [Key]
        public int WeaponId { get; set; }
        [Required]
        public WeaponType Type { get; set; }
        public int Speed { get; set; }
        public int Radius { get; set; }
        [Required]
        public CounterType Counter { get; set; }
        
    }
    public enum WeaponType
    {
        BallisticMissile,
        Drone,
        Rocket
    }
    public enum CounterType
    {
        ElectronicJamming,
        AntiAirSystem,
        InterceptorMissile
    }
    

    public static class EnumServices
    {
        public static SelectList GetEnumSelectList<TEnum>() where TEnum : Enum
        {
            var values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();
            var selectListItems = values.Select(e => new SelectListItem { Value = e.ToString(),Text = e.ToString()}).ToList();
            return new SelectList(selectListItems, "Value", "Text");
        }
    }

}








    

