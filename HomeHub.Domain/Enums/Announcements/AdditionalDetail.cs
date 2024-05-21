using System.Collections.Generic;

namespace HomeHub.Domain.Enums.Announcements;

public enum AdditionalDetailEnum
{
    Internet = 1,
    CableTv = 2,
    Phone = 3,
    AntiBurglaryBlinds = 4,
    Monitoring = 5,
    AntiBurglaryDoors = 6,
    AntiBurglaryWindows = 7,
    AlarmSystem = 8,
    EntryPhone = 9,
    Videophone = 10,
    ClosedArea = 11,
    Furniture = 12,
    Fridge = 13,
    Tv = 14,
    WashingMachine = 15,
    Cooker = 16,
    Dishwasher = 17,
    Oven = 18,
    Balcony = 19,
    Basement = 20,
    Elevator = 21,
    AirConditioning = 22,
    UtilityRoom = 23,
    Garden = 24,
    TwoStory = 25,
    Garage = 26,
    ParkingSpace = 27,
    Terrace = 28,
    SeparateKitchen = 29
}

public class AdditionalDetailNames
{
    public static IReadOnlyDictionary<long, string> Names = new Dictionary<long, string>
    {
        { (long)AdditionalDetailEnum.Internet, "Internet" },
        { (long)AdditionalDetailEnum.CableTv, "CableTv" },
        { (long)AdditionalDetailEnum.Phone, "Phone" },
        { (long)AdditionalDetailEnum.AntiBurglaryBlinds, "AntiBurglaryBlinds" },
        { (long)AdditionalDetailEnum.Monitoring, "Monitoring" },
        { (long)AdditionalDetailEnum.AntiBurglaryDoors, "AntiBurglaryDoors" },
        { (long)AdditionalDetailEnum.AntiBurglaryWindows, "AntiBurglaryWindows" },
        { (long)AdditionalDetailEnum.AlarmSystem, "AlarmSystem" },
        { (long)AdditionalDetailEnum.EntryPhone, "EntryPhone" },
        { (long)AdditionalDetailEnum.Videophone, "Videophone" },
        { (long)AdditionalDetailEnum.ClosedArea, "ClosedArea" },
        { (long)AdditionalDetailEnum.Furniture, "Furniture" },
        { (long)AdditionalDetailEnum.Fridge, "Fridge" },
        { (long)AdditionalDetailEnum.Tv, "Tv" },
        { (long)AdditionalDetailEnum.WashingMachine, "WashingMachine" },
        { (long)AdditionalDetailEnum.Cooker, "Cooker" },
        { (long)AdditionalDetailEnum.Dishwasher, "Dishwasher" },
        { (long)AdditionalDetailEnum.Oven, "Oven" },
        { (long)AdditionalDetailEnum.Balcony, "Balcony" },
        { (long)AdditionalDetailEnum.Basement, "Basement" },
        { (long)AdditionalDetailEnum.Elevator, "Elevator" },
        { (long)AdditionalDetailEnum.AirConditioning, "AirConditioning" },
        { (long)AdditionalDetailEnum.UtilityRoom, "UtilityRoom" },
        { (long)AdditionalDetailEnum.Garden, "Garden" },
        { (long)AdditionalDetailEnum.TwoStory, "TwoStory" },
        { (long)AdditionalDetailEnum.Garage, "Garage" },
        { (long)AdditionalDetailEnum.ParkingSpace, "ParkingSpace" },
        { (long)AdditionalDetailEnum.Terrace, "Terrace" },
        { (long)AdditionalDetailEnum.SeparateKitchen, "SeparateKitchen" }
    };
}

public class AdditionalDetailGroups
{
    public static IReadOnlyDictionary<long, long> Groups = new Dictionary<long, long>
    {
        { (long)AdditionalDetailEnum.Internet, (long)DetailsGroupEnum.Media },
        { (long)AdditionalDetailEnum.CableTv, (long)DetailsGroupEnum.Media },
        { (long)AdditionalDetailEnum.Phone, (long)DetailsGroupEnum.Media },
        { (long)AdditionalDetailEnum.AntiBurglaryBlinds, (long)DetailsGroupEnum.Security },
        { (long)AdditionalDetailEnum.Monitoring, (long)DetailsGroupEnum.Security },
        { (long)AdditionalDetailEnum.AntiBurglaryDoors, (long)DetailsGroupEnum.Security },
        { (long)AdditionalDetailEnum.AntiBurglaryWindows, (long)DetailsGroupEnum.Security },
        { (long)AdditionalDetailEnum.AlarmSystem, (long)DetailsGroupEnum.Security },
        { (long)AdditionalDetailEnum.EntryPhone, (long)DetailsGroupEnum.Security },
        { (long)AdditionalDetailEnum.Videophone, (long)DetailsGroupEnum.Security },
        { (long)AdditionalDetailEnum.ClosedArea, (long)DetailsGroupEnum.Security },
        { (long)AdditionalDetailEnum.Furniture, (long)DetailsGroupEnum.Equipment },
        { (long)AdditionalDetailEnum.Fridge, (long)DetailsGroupEnum.Equipment },
        { (long)AdditionalDetailEnum.Tv, (long)DetailsGroupEnum.Equipment },
        { (long)AdditionalDetailEnum.WashingMachine, (long)DetailsGroupEnum.Equipment },
        { (long)AdditionalDetailEnum.Cooker, (long)DetailsGroupEnum.Equipment },
        { (long)AdditionalDetailEnum.Dishwasher, (long)DetailsGroupEnum.Equipment },
        { (long)AdditionalDetailEnum.Oven, (long)DetailsGroupEnum.Equipment },
        { (long)AdditionalDetailEnum.Balcony, (long)DetailsGroupEnum.Additional },
        { (long)AdditionalDetailEnum.Basement, (long)DetailsGroupEnum.Additional },
        { (long)AdditionalDetailEnum.Elevator, (long)DetailsGroupEnum.Additional },
        { (long)AdditionalDetailEnum.AirConditioning, (long)DetailsGroupEnum.Additional },
        { (long)AdditionalDetailEnum.UtilityRoom, (long)DetailsGroupEnum.Additional },
        { (long)AdditionalDetailEnum.Garden, (long)DetailsGroupEnum.Additional },
        { (long)AdditionalDetailEnum.TwoStory, (long)DetailsGroupEnum.Additional },
        { (long)AdditionalDetailEnum.Garage, (long)DetailsGroupEnum.Additional },
        { (long)AdditionalDetailEnum.ParkingSpace, (long)DetailsGroupEnum.Additional },
        { (long)AdditionalDetailEnum.Terrace, (long)DetailsGroupEnum.Additional },
        { (long)AdditionalDetailEnum.SeparateKitchen, (long)DetailsGroupEnum.Additional }
    };
}