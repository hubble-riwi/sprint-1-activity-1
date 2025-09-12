List<string> discounts = new List<string>();

Console.WriteLine("Bienvenido al Cine intergaláctico");
Console.WriteLine("A continuación ingresa los siguientes datos");

Console.WriteLine("Dame tu edad: ");
int age = int.Parse(Console.ReadLine());

Console.WriteLine("Selecciona el tipo de película:\n1. Estreno\n2. Clásico\n3. 3D\n4. Maratón\n5. Función especial");
string type = Console.ReadLine();

Console.WriteLine("Qué día es hoy:\n1. Lunes\n2. Martes\n3. Miércoles\n4. Jueves\n5. Viernes\n6. Sábado\n7. Domingo");
string day = Console.ReadLine();

Console.WriteLine("Qué hora es:\n1. Mañana\n2. Tarde\n3. Noche");
string hour = Console.ReadLine();

Console.WriteLine("Membresía:\n1. Ninguna\n2. Silver\n3. Gold\n4. Platino");
string membership = Console.ReadLine();

Console.WriteLine("¿Hay una promo activa? (S/N): ");
string promotion = Console.ReadLine().ToLower();

Console.WriteLine("¿Estudiante? (S/N): ");
string student = Console.ReadLine().ToLower();

Console.WriteLine("¿Combo de pareja? (S/N): ");
string couple = Console.ReadLine().ToLower();

double price = 10000;
double totalPrice = price;
double originalPrice = price;
bool isWeekendNight = ((day == "5" || day == "6") && hour == "3");
bool isWednesday = day == "3";
bool isSunday = day == "7";
bool promoActive = promotion == "s";
bool isStudent = student == "s";
bool isCouple = couple == "s";

// Validacion edad
if (age < 12)
{
    if ((day == "1" || day == "3") && type == "2")
    {
        Console.WriteLine("La entrada es gratis para niños en clásicos lunes o miércoles.");
        return;
    }

    if (type == "5")
    {
        Console.WriteLine("Niños no pueden entrar a funciones especiales.");
        return;
    }

    if (type == "3" && (hour == "1" || hour == "2"))
    {
        totalPrice *= 0.3;
        discounts.Add("Niño 30% en 3D antes de 6pm");
    }
}
else if (age >= 12 && age <= 17)
{
    if (type == "1")
    {
        // Estreno, paga completo
    }

    if (type == "2" && isWednesday)
    {
        totalPrice *= 0.5;
        discounts.Add("Adolescente 50% en clásico miércoles");
    }

    if (membership == "2" && type == "3" && !isSunday)
    {
        totalPrice *= 0.8;
        discounts.Add("Membresía Silver 20% en 3D");
    }
}
else if (age >= 18 && age < 60)
{
    if ((type == "1" || type == "5") && !(membership == "4" && type == "1" && isWeekendNight))
    {
        // paga completo
    }

    if (membership == "3")
    {
        if (type == "2" && !isWeekendNight)
        {
            totalPrice *= 0.75;
            discounts.Add("Membresía Gold 25% en clásico");
        }

        if (type == "3" && !isSunday)
        {
            totalPrice *= 0.85;
            discounts.Add("Membresía Gold 15% en 3D");
        }
    }

    if (membership == "4")
    {
        if (!(type == "1" && isWeekendNight))
        {
            totalPrice *= 0.65;
            discounts.Add("Membresía Platino 35% descuento");
        }
    }
}
else if (age >= 60)
{
    if (type == "4")
    {
        totalPrice *= 0.5;
        discounts.Add("Senior 50% en maratón");
    }
    else if (isSunday && promoActive)
    {
        totalPrice *= 0.3;
        discounts.Add("Senior 70% en domingo con promo");
    }
    else
    {
        totalPrice *= 0.6;
        discounts.Add("Senior 40% descuento");
    }
}

// Día miércoles
if (isWednesday && type != "5")
{
    totalPrice *= 0.8;
    discounts.Add("Miércoles de descuento global 20%");
}

// Tipo película
if (type == "1")
{
    if (isStudent)
    {
        totalPrice *= 0.85;
        discounts.Add("Estudiante 15% en estreno");
    }
    if (membership == "4" && !(day == "6" && hour == "3"))
    {
        totalPrice *= 0.65;
        discounts.Add("Platino 35% en estreno");
    }
}

if (type == "3")
{
    // Recargo del 10% al final
}

if (type == "4" && age < 60)
{
    totalPrice *= 0.8;
    discounts.Add("Maratón 20% descuento");
}

if (type == "5")
{
    if (age < 18)
    {
        Console.WriteLine("Solo adultos y seniors pueden entrar a funciones especiales.");
        return;
    }
    // No hay descuentos
}

// Validaciones extras
if (isStudent && (day == "1" || day == "3"))
{
    totalPrice *= 0.9;
    discounts.Add("Estudiante lunes o miércoles extra 10%");
}

if (isCouple && !isSunday)
{
    double parejaTotal = totalPrice + (totalPrice * 0.5);
    discounts.Add("Combo de pareja (segundo al 50%)");
    totalPrice = parejaTotal;
}

if (promoActive)
{
    if (isSunday && type != "5")
    {
        totalPrice *= 0.9;
        discounts.Add("Promo activa en domingo 10%");
    }
    else if ((membership == "2" || membership == "3" || membership == "4") && type != "5")
    {
        totalPrice *= 0.95;
        discounts.Add("Promo activa + membresía 5%");
    }
}

// Recargo 3d
if (type == "3")
{
    totalPrice *= 1.10;
    discounts.Add("Recargo 10% por 3D");
}

// Salida
Console.WriteLine("\n--- RESUMEN DE COMPRA ---");
Console.WriteLine("Precio base: $" + originalPrice);
Console.WriteLine("Descuentos aplicados:");
foreach (string d in discounts)
{
    Console.WriteLine("- " + d);
}
Console.WriteLine("Total a pagar: $" + Math.Round(totalPrice, 2));