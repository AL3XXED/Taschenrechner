
/*## Beschreibung
Schreibe ein C#-Programm, das:
1. Zwei Zahlen vom Benutzer einliest und auf ihre Gültigkeit überprüft.
2. Den Benutzer eine Rechenoperation (Addition, Subtraktion, Multiplikation, Division) auswählen lässt.
3. Eine Division durch 0 verhindert.

Das Programm soll sich wiederholen, bis der Benutzer die Beenden-Option wählt.

## Anforderungen

1. Erlaube dem Benutzer, eine der folgenden Rechenoperationen auszuwählen:
   -Addition(`+`)
   - Subtraktion(`-`)
   - Multiplikation(`*`)
   - Division(`/`), wobei eine Division durch 0 abgefangen werden muss.
2. Gib das Ergebnis der Rechenoperation aus.

---

### Optionale Erweiterungen
+ Verwende eine `do-while`-Schleife, um die Benutzereingaben zu validieren und das Programm zu wiederholen.
+ Nutze die Methode `int.TryParse`, um sicherzustellen, dass nur gültige Ganzzahlen akzeptiert werden.
*/

Console.WriteLine("=== Einfacher Taschenrechner ===");

while (true)
{
    // Zahl 1 einlesen
    decimal zahl1 = EingabeZahl("Zahl1");

    // Zahl 2 einlesen
    decimal zahl2 = EingabeZahl("Zahl2");

    // Operation auswählen
    char operation = OperationAuswählen();

    if (operation == 'x')
    {
        Console.WriteLine("Programm wird beendet. Auf Wiedersehen!");
        break;
    }

    // Berechnung durchführen
    try
    {
        decimal ergebnis = Berechnen(zahl1, zahl2, operation);
        Console.WriteLine($"Ergebnis: {zahl1} {operation} {zahl2} = {ergebnis}");
    }
    catch (DivideByZeroException)
    {
        Console.WriteLine("Fehler: Division durch Null ist nicht erlaubt!");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ein Fehler ist aufgetreten: {ex.Message}");
    }

    Console.WriteLine("----------------------------");
}

static decimal EingabeZahl(string zahlName)
{
    decimal zahl = 0;
    bool zahlOk = false;

    do
    {
        Console.Write($"{zahlName}: ");
        string eingabe = Console.ReadLine();
        zahlOk = decimal.TryParse(eingabe, out zahl);

        if (!zahlOk)
        {
            Console.WriteLine("Eingabe ungültig! Bitte geben Sie eine gültige Zahl ein.");
        }
    } while (!zahlOk);

    return zahl;
}

static char OperationAuswählen()
{
    Console.WriteLine("Wählen Sie eine Operation:");
    Console.WriteLine("+ : Addition");
    Console.WriteLine("- : Subtraktion");
    Console.WriteLine("* : Multiplikation");
    Console.WriteLine("/ : Division");
    Console.WriteLine("x : Programm beenden");

    char operation;
    do
    {
        Console.Write("Ihre Wahl: ");
        operation = Console.ReadKey().KeyChar;
        Console.WriteLine();

        if (!"+-*/x".Contains(operation))
        {
            Console.WriteLine("Ungültige Eingabe! Bitte wählen Sie eine der angegebenen Operationen.");
        }
    } while (!"+-*/x".Contains(operation));

    return operation;
}

static decimal Berechnen(decimal zahl1, decimal zahl2, char operation)
{
    switch (operation)
    {
        case '+': return zahl1 + zahl2;
        case '-': return zahl1 - zahl2;
        case '*': return zahl1 * zahl2;
        case '/':
            if (zahl2 == 0)
                throw new DivideByZeroException();
            return zahl1 / zahl2;
        default:
            throw new ArgumentException("Ungültige Operation");
    }
}

