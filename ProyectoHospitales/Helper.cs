namespace ProyectoHospitales
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Globalization;

    public class ValoresDia
    {
        public string ValorDia = "1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31";
    }

    public class CorrectCedula : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string message = string.Empty;
            if (Convert.ToString(value).Length == 11)
                return ValidationResult.Success;
            message = "Cedula not valid";
            return new ValidationResult(message);
        }
        
    }

    public class CorrectPhone : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string message = string.Empty;
            if (Convert.ToString(value).Length == 10)
                return ValidationResult.Success;
            message = "Phone not valid";
            return new ValidationResult(message);
        }
    }

    

    public class Horas
    {
        public string Hora;
        public string Min;

        

        public string Stringify()
        {
            return Hora + Min;
        }
    }

    public class Provincias
    {
        public string provincias = "Azua,Bahoruco,Barahona,Dajabón,Distrito Nacional,Duarte,Elías Piña,El Seibo,Espaillat,Hato Mayor,Hermanas Mirabal,Independencia,La Altagracia,La Romana,La Vega,María Trinidad Sánchez,Monseñor Nouel,Monte Cristi,Monte Plata,Pedernales,Peravia,Puerto Plata,Samaná,Sánchez Ramírez,San Cristóbal,San José de Ocoa,San Juan,San Pedro de Macorís,Santiago,Santiago Rodríguez,Santo Domingo,Valverde";
    }
    

    public enum Genero
    {
        Masculino,
        Femenino,
    }


    public enum ValoresMes
    {
        Enero = 1,
        Febrero = 2,
        Marzo = 3,
        Abril = 4,
        Mayo = 5,
        Junio = 6,
        Julio = 7,
        Agosto = 8,
        Septiembre = 9,
        Octubre = 10,
        Noviembre = 11,
        Diciembre = 12
    }
}