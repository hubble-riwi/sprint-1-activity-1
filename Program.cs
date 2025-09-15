double discount = 0;
double price = 10000;

void ShowSummary(string typeMovie, double price, double discount)
{
    double finalPrice = price * (1 - discount);
    Console.WriteLine($"Tipo de película: {typeMovie}");
    Console.WriteLine($"Descuento aplicado: {discount * 100}%");
    Console.WriteLine($"Precio final: {finalPrice:F2}");
}

Console.WriteLine("Bienvenido al cine intergalactico, vas a comprar una entrada, vamos a registrarla: ");
Console.WriteLine("Ingresa tu edad: ");
int age = int.Parse(Console.ReadLine()!);

Console.WriteLine("Ingresa el tipo de pelicula que vas a ver: \n estreno \n clasico \n 3D \n maraton \n especial");
string typeMovie = Console.ReadLine()!.ToLower();

Console.WriteLine(
    "Ingresa el dia que vas a ver la pelicula: \n lunes \n martes \n miercoles \n jueves \n viernes \n sabado \n domingo");
string day = Console.ReadLine()!.ToLower();

Console.WriteLine("Ingresa el horario en el que veras la pelicula: \n mañana \n tarde \n noche");
string time = Console.ReadLine()!.ToLower();

Console.WriteLine("Ingresa el tipo de membresia que tienes: \n ninguna \n silver \n gold \n platino");
string membership = Console.ReadLine()!.ToLower();

Console.WriteLine("¿Tienes alguna promocion activa?: \n si \n no ");
string active_promo = Console.ReadLine()!.ToLower();

Console.WriteLine("¿Eres estudiante?: \n si \n no ");
string student = Console.ReadLine()!.ToLower();

Console.WriteLine("¿Vas en pareja?: \n si \n no ");
string couple = Console.ReadLine()!.ToLower();

if (day == "miercoles" && typeMovie != "especial")
{
    discount = 0.2;
}
else if ((day == "viernes" || day == "sabado") && time == "noche")
{
    membership = "ninguna";
}

if (typeMovie == "estreno")
{
    if (student == "si")
    {
        discount = 0.15;
    }

    if (membership == "silver" && !(day == "sabado" && time == "noche"))
    {
        discount = 0.35;
    }
}
else if (typeMovie == "3d")
{
    discount *= 1.10;
}
else if (typeMovie == "maraton")
{
    if (age >= 60)
    {
        discount = 0.5;
        ShowSummary(typeMovie, price, discount);
        return;
    }
    else
    {
        discount = 0.2;
    }
}
else if (typeMovie == "especial")
{
    if (age >= 18)
    {
        price = 10000;
    }
    else
    {
        Console.WriteLine("Eres menor de edad, no puedes ver este tipo de peliculas");
        return;
    }
}

if (age < 12)
{
    if ((day == "lunes" || day == "miercoles") && typeMovie == "clasico")
    {
        Console.WriteLine("La entrada es gratis");
        Console.WriteLine("Precio final: $0");
        return;
    }

    if (typeMovie == "3d" && time != "noche")
    {
        discount += 0.3;
    }
}
else if (age < 18)
{
    if (typeMovie == "estreno")
    {
        price = 10000;
    }

    if (typeMovie == "clasico" && day == "miercoles")
    {
        discount += 0.5;
    }

    if (membership == "silver" && typeMovie == "3d" && day != "domingo")
    {
        discount += 0.2;
    }
}
else if (age <= 59)
{
    if (typeMovie == "estreno" || typeMovie == "especial")
    {
        price = 10000;
    }

    if (membership == "gold")
    {
        if (typeMovie == "clasico" && !((day == "viernes" || day == "sabado") && time == "noche"))
        {
            discount += 0.25;
        }
        else if (day != "domingo" && typeMovie == "3d")
        {
            discount += 0.15;
        }
    }
    else if (membership == "platino")
    {
        if (!(typeMovie == "estreno" && day == "sabado" && time == "noche"))
        {
            discount += 0.35;
        }
    }
}
else
{
    if (day == "domingo" && active_promo == "si")
    {
        discount = 0.7;
    }
    else
    {
        discount = 0.40;
    }
}

if (couple == "si" && day != "domingo")
{
    if (typeMovie == "maraton")
    {
        discount = 0.5;
    }
    else
    {
        price += (price / 2);
    }
}

if (student == "si" && (day == "lunes" || day == "miercoles"))
{
    discount += 0.1;
}

if (active_promo == "si")
{
    if (day == "domingo")
    {
        if (typeMovie != "especial")
        {
            discount *= 0.90;
        }
    }
    else
    {
        if (membership != "ninguna")
        {
            discount *= 0.95;
        }
    }
}

ShowSummary(typeMovie, price, discount);
