﻿using System;
using System.Collections.Generic;

string validacion;

// Entradas
//Pedir edad
Console.Write("Ingresa la edad: ");
validacion = Console.ReadLine();

if (!int.TryParse((validacion), out int edad)) 
{
    Console.WriteLine("La edad es invalida!");
    return;
}

//Pedir el tipo de pelicula
Console.Write("Ingrese el tipo de pelicula: ");
string tipo_pelicula = Console.ReadLine();
if (! new List<string> {"estreno", "clasico", "3D", "maraton", "funcion_especial"}.Contains(tipo_pelicula))
{
    Console.WriteLine("Elija una pelicula valida!");
    return;
}

//Pedir dia de hoy
Console.Write("Ingresa el día de hoy: ");
string dia = Console.ReadLine();
if(! new List <string> {"lunes", "martes", "miercoles", "jueves", "viernes", "sabado", "domingo"}.Contains(dia))
{
    Console.WriteLine("Ingrese un dia valido!");
    return;
}

//Preguntar por la hora del dia
Console.WriteLine("Ingrese la hora del dia (mañana, tarde noche): ");
string hora = Console.ReadLine();
if (!new List<string> {"mañana", "tarde", "noche"}.Contains(hora))
{
    Console.WriteLine("El hora del dia es invalido!");
} 

//Pedir el tipo membresia
Console.Write("Ingrese su membresia, si no posee alguna oprima escriba 'ninguna': ");
string membresia = Console.ReadLine();

if (!new List<string> {"", "ninguna", "silver", "gold", "platino"}.Contains(membresia))
{
    Console.WriteLine("El una membresia valida!");
    return;
}

//Preguntar si es un estudiante
Console.Write("¿Es usted un estudiante?(y/n) ");
bool estudiante;
validacion = Console.ReadLine();
if (validacion == "y" || validacion == "n")
{
    if (validacion == "y")
    {
        estudiante = true;
    }
    else
    {
        estudiante = false;
    }
}
else
{
    Console.WriteLine("Ingrese una opcion valida!");
    return;
}

//Preguntar si va con pareja
Console.Write("¿Usted va con su pareja?(y/n) ");
bool pareja;
validacion = Console.ReadLine();
if (validacion == "y" || validacion == "n")
{
    if (validacion == "y")
    {
        pareja = true;
    }
    else
    {
        pareja = false;
    }
}
else
{
    Console.WriteLine("Ingrese una opcion valida!");
    return;
}

//Preguntar si hay promo activa
Console.Write("¿Hay promocion activa?(y/n) ");
bool promo_activa;
validacion = Console.ReadLine();
if (validacion == "y" || validacion == "n")
{
    if (validacion == "y")
    {
        promo_activa = true;
    }
    else
    {
        promo_activa = false;
    }
}
else
{
    Console.WriteLine("Ingrese una opcion valida!");
    return;
}

//Calculate the price with discount

        double precio_base = 10000;

        double precio_final = precio_base;
        List<string> descuentos = new List<string>();

        // 1. Reglas por edad
        if (edad < 12) // Niños
        {
            if (tipo_pelicula == "clasico" && (dia == "lunes" || dia == "miercoles"))
            {
                precio_final = 0;
                descuentos.Add("Niño: gratis en clásicos lunes/miércoles");
            }
            else if (tipo_pelicula == "3D" && (hora == "mañana" || hora == "tarde"))
            {
                precio_final *= 0.3;
                descuentos.Add("Niño: paga 30% en 3D antes de 6pm");
            }
            else if (tipo_pelicula == "funcion_especial")
            {
                Console.WriteLine("Niños no pueden entrar a funciones especiales.");
                return;
            }
        }
        else if (edad <= 17) // Adolescentes
        {
            if (tipo_pelicula == "estreno")
            {
                // Pagan completo, sin cambios
                descuentos.Add("Adolescente: paga completo en estrenos");
            }
            else if (tipo_pelicula == "clasico" && dia == "miercoles")
            {
                precio_final *= 0.5;
                descuentos.Add("Adolescente: 50% en clásicos los miércoles");
            }
            else if (tipo_pelicula == "3D" && membresia == "silver" && dia != "domingo")
            {
                precio_final *= 0.8;
                descuentos.Add("Adolescente + Silver: 20% en 3D (no domingos)");
            }
        }
        else if (edad <= 59) // Adultos
        {
            if (tipo_pelicula == "estreno" || tipo_pelicula == "funcion_especial")
            {
                // Pagan completo
                descuentos.Add("Adulto: paga completo en estrenos y especiales");
            }
            else if (membresia == "gold")
            {
                if (tipo_pelicula == "clasico" && !(dia == "viernes" && hora == "noche") && !(dia == "sabado" && hora == "noche"))
                {
                    precio_final *= 0.75;
                    descuentos.Add("Adulto + Gold: 25% en clásicos");
                }
                else if (tipo_pelicula == "3D" && dia != "domingo")
                {
                    precio_final *= 0.85;
                    descuentos.Add("Adulto + Gold: 15% en 3D (no domingo)");
                }
            }
            else if (membresia == "platino")
            {
                if (!(tipo_pelicula == "estreno" && dia == "sabado" && hora == "noche"))
                {
                    precio_final *= 0.65;
                    descuentos.Add("Adulto + Platino: 35% general");
                }
                else
                {
                    descuentos.Add("Platino bloqueado en estreno sábado noche");
                }
            }
        }
        else // Seniors 60+
        {
            if (tipo_pelicula == "maraton")
            {
                precio_final *= 0.5;
                descuentos.Add("Senior: 50% fijo en maratón");
            }
            else if (dia == "domingo" && promo_activa)
            {
                precio_final *= 0.3;
                descuentos.Add("Senior: 70% descuento domingo con promo");
            }
            else
            {
                precio_final *= 0.6;
                descuentos.Add("Senior: 40% descuento");
            }
        }

        // 2. Día de la semana
        if (dia == "miercoles" && tipo_pelicula != "funcion_especial")
        {
            precio_final *= 0.8;
            descuentos.Add("Miércoles global: 20% descuento");
        }

        // Bloqueo de membresía en viernes/sábado noche
        bool bloqueaMembresia = (dia == "viernes" || dia == "sabado") && hora == "noche";

        // 3. Tipo de película
        if (tipo_pelicula == "3D")
        {
            precio_final *= 1.1; // recargo
            descuentos.Add("3D: +10% recargo");
        }
        else if (tipo_pelicula == "maraton" && edad < 60) // seniors ya tienen regla fija
        {
            precio_final *= 0.8;
            descuentos.Add("Maratón: 20% descuento general");
        }
        else if (tipo_pelicula == "funcion_especial" && edad < 18)
        {
            Console.WriteLine("Prohibido: menores no pueden entrar a función especial.");
            return;
        }

        // 4. Extras
        if (estudiante)
        {
            if (tipo_pelicula == "estreno")
            {
                precio_final *= 0.85;
                descuentos.Add("Estudiante: 15% en estreno");
            }
            if (dia == "lunes" || dia == "miercoles")
            {
                precio_final *= 0.9;
                descuentos.Add("Estudiante: 10% extra lunes/miércoles");
            }
        }

        if (pareja && dia != "domingo")
        {
            descuentos.Add("Pareja: segundo boleto al 50% (aplicar en cálculo grupal)");
        }

        if (promo_activa)
        {
            if (dia == "domingo" && tipo_pelicula != "funcion_especial")
            {
                precio_final *= 0.9;
                descuentos.Add("Promo domingo: 10% extra");
            }
            else if (membresia != "ninguna" && membresia != "")
            {
                precio_final *= 0.95;
                descuentos.Add("Promo + membresía: 5% extra");
            }
        }

        // Resultados
        Console.WriteLine($"Precio base: {precio_base}");
        Console.WriteLine("Descuentos aplicados:");
        foreach (var d in descuentos)
        {
            Console.WriteLine($"- {d}");
        }
        Console.WriteLine($"Precio final: {precio_final}");
