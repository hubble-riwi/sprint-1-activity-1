
double ticket_price = 10000;
double discount_price = 10000;
double discount = 0;
string discounts_applied = string.Empty;
bool prom = true;
bool is_student = true;
bool discount_couple = true;


Console.WriteLine("Ingresa tu edad");
int age = int.Parse(Console.ReadLine());

Console.WriteLine("Ingresa el tipo de pelicula:\n 1. estreno \n 2. clasico \n 3. 3d \n 4. maraton \n 5. especial \n POR FAVOR ESCRIBA EXACTAMENTE LA OPCION QUE DESEA");
string type_movie = Console.ReadLine();

if (type_movie == "especial" && age<18 )
{
    Console.WriteLine("Lo lamentamos, no puede entrar a la funcion especial por la edad");
    return;
}

Console.WriteLine("ingresa el dia de la semana que deseas ver la pelicula (lunes, martes, miercoles ...)\n");
string day_movie = Console.ReadLine();
Console.WriteLine("Ingrese a que hora desea ver la pelicula (mañana, tarde o noche)");
string hour_movie = Console.ReadLine();
Console.WriteLine("Ingrese que tipo de membresía tiene \n 1. ninguna \n 2. gold \n 3. Platino \n 4. silver");
string client_membership = Console.ReadLine();
Console.WriteLine("Es un estudiante? (si/no)");
string student =  Console.ReadLine();
Console.WriteLine("compran boleta en pareja?");
string couple = Console.ReadLine();
Console.WriteLine("Promo activa? (si/no)");
string active_promotion = Console.ReadLine();

if (student == "si")
{
    is_student = true;
}
else
{
    is_student = false;
}

if (active_promotion == "si")
{
    prom = true;
}
else
{
    prom = false;
}

if (couple == "si")
{
    prom = true;
}
else
{
    prom = false;
}

if (age < 12 && type_movie == "clasico" && day_movie == "lunes" && day_movie == "miercoles")
{
    discount_price = 0;
    discounts_applied = discounts_applied + "desc menores de 12 lun y mierc";
}
else if (type_movie == "3d" && hour_movie == "mañana" && hour_movie == "tarde")
{
    discount_price = discount_price * 0.3;
    discounts_applied = discounts_applied + "desc menores de 12 3d antes 6pm";
    
}

if (age >= 12 && age <= 17 && type_movie == "clasico" && day_movie == "miercoles")
{
    discount_price = discount_price * 0.5;
    discounts_applied = discounts_applied + "desc jovenes de 12 a 13  tip peli clasica mierc";

}

if (age >= 12 && age <= 17 && client_membership == "silver" && day_movie != "domingo")
{
    discount = discount_price * 0.2;
    discount_price = discount_price - discount;
    discounts_applied = discounts_applied + "desc 20% por miembro silver";
}

if (age >= 18 && age <= 59 && client_membership == "gold" && ((day_movie != "viernes" && hour_movie != "noche") ||
                                                              (day_movie != "sabado" && hour_movie != "noche")))
{
    discount_price = discount_price * 0.25;
    discounts_applied = discounts_applied + "paga 25% por miembro gold edad 18-59";
}

if (age >= 18 && age <= 59 && client_membership == "gold" && type_movie == "3d" && day_movie != "domingo" && !( day_movie == "sabado" || day_movie == "viernes" && hour_movie != "noche" ))
{
    discount_price = discount_price * 0.15; 
    discounts_applied = discounts_applied + "paga 15% por miembro gold y pelic 3d  edad 18-59";

}

if (age >= 18 && age <= 59 && client_membership == "platino" && !( day_movie == "viernes" || day_movie == "sabado" && hour_movie == "noche"  && type_movie == "estreno"   ))
{
    discount = discount_price * 0.35;
    discount_price = discount_price - discount;
    discounts_applied = discounts_applied + "desc 35% por miembro platino edad 18-59";
}

if (age >= 60)
{
    discount = discount_price * 0.4;
    discount_price = discount_price - discount;
    discounts_applied = discounts_applied + "desc 35% por edad +60";
}

if (age >= 60 && day_movie == "domingo" && prom == true)
{
    discount = discount_price * 0.7;
    discount_price = discount_price - discount;
    discounts_applied = discounts_applied + "desc 70% por edad +60 domingo";
}

if (age >= 60 && type_movie == "maraton")
{
    discount_price = discount_price * 0.5;
}

if (day_movie == "miercoles" && type_movie != "especial")
{
    discount_price = discount_price * 0.8;
    discounts_applied = discounts_applied + "paga 80% del descuento por miercoles";

}

if (type_movie == "estreno" && is_student == true )
{
    discount =  discount_price * 0.15;
    discount_price = discount_price - discount;
    discounts_applied = discounts_applied + "descuento 15% por ser estudiante en estreno";
    
}else if (client_membership == "platino" && !(day_movie == "sabado" && hour_movie == "noche"))
{
    discount =  discount_price * 0.15;
    discount_price = discount_price - discount;
    discounts_applied = discounts_applied + "descuento 35% por ser platino";
    
}

if (type_movie == "3d")
{
    discount = discount_price * 0.1;
    discount_price = discount_price + discount;
    discounts_applied = discounts_applied + "+ 10% por ser 3d";

    
}

if (type_movie == "maraton" && age < 60)
{
    discount = discount_price * 0.2;
    discount_price = discount_price - discount;
    discounts_applied = discounts_applied + "- 20% por ser maraton y edad < 60";

    
}

if (type_movie == "maraton" && age >= 60)
{
    discount = discount_price * 0.5;
    discount_price = discount_price - discount;
    discounts_applied = discounts_applied + "- 50% por ser maraton y edad >= 60";

}

if (is_student == true && day_movie == "lunes" || day_movie == "miercoles")
{
    discount = discount_price * 0.1;
    discount_price = discount_price - discount;
    discounts_applied = discounts_applied + "-10% de descuento por ser lunes/miercoles y estudiante";   
    
}

if (discount_couple == true && day_movie != "domingo")
{
    ticket_price = ticket_price + 10000;
    discount_price = discount_price + 5000;
}




Console.WriteLine("------------------------ \n Precio Base: $"+ticket_price + "\n Precio con el descuento $"+ discount_price + " \nDescuentos aplicados: "+ discounts_applied);











