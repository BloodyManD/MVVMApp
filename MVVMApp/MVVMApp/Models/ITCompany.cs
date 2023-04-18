using System;

namespace MVVMApp.Models
{
    [Serializable]
    public class ITCompany
    {
        public string Filename { get; set; } 
        public string Name { get; set; }
        public string Geolocation { get; set; }
        public string FieldOfActivity { get; set; }
        public string NumberOfEmployees { get; set; }
        public string Scale { get; set; }
    }
}