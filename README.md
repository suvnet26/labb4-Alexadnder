# Unittestlab

Två delar:

1. En del där du ska bygga ut den existerande PasswordResetService med ny funktionalitet enligt TDD-principer.
2. Analysera Videoteket-uppgiften för att undersöka testbarheten i projektet samt prova att skriva tester för valda delar. **Svara på några korta frågor i slutet av detta dokument!**

## Del 1: Implementera ny funktionalitet i PasswordResetService med TDD

Din uppgift är att med hjälp av TDD-principer implementera minst en av följande funktionaliteter i PasswordResetService:

1. Det ska bara gå att begära en lösenordsåterställning om e-postadressen redan är registrerad i systemet.
2. Det ska gå att begära högst tre lösenordsåterställningar per e-postadress. Den fjärde begäran för samma adress ska nekas.
3. AVANCERAD: Om du gjort övningen PasswordValidator, integrera användandet av den i PasswordResetService så att nya lösenord måste uppfylla valideringsreglerna. Dvs, en metod för att sätta lösenordet för en viss användare (identifierad utifrån e-postadress) ska implementeras i PasswordResetService. Denna metod ska validera att lösenordet är korrekt enligt PasswordValidator SAMT att det finns en giltig `token` associerad med e-postadressen.

Vad som ska hända när en begäran nekas får du välja själv. Tre rimliga alternativ:

* `SendResetEmail` kastar ett exception.
* `SendResetEmail` returnerar en `bool` som talar om ifall mejlet skickades.
* Inget mejl skickas, utan att anroparen får veta något.

Välj ett av dem och låt dina tester beskriva det beteendet.

> Tips för TDD-arbetet. Skriv gärna först en kort lista över de testfall du kommer på, och jobba sedan i korta varv med ett test i taget:
>
> 1. **Red:** Skriv ett test som beskriver nästa lilla bit av beteendet. Kör det och se att det misslyckas (att koden inte kompilerar räknas också som rött).
> 2. **Green:** Skriv enklast möjliga kod som får testet att gå igenom.
> 3. **Refactor:** Städa i både produktionskoden och testkoden medan alla tester är gröna. Kör testerna igen efteråt.
>
> Samtliga funktionaliteter ovan kräver nya interfaces som kan ersättas med fejkade implementationer i testerna. Skapa dem när testet du skriver behöver dem, och låt testet styra vilka metoder de får.
>
> När PasswordResetService får fler beroenden växer Arrange-delen i varje test. Ett bra refactor-steg är då att bryta ut skapandet av `sut` och fejkarna till testklassens konstruktor eller en hjälpmetod.
>
> `FakeEmailProvider.SentEmails` innehåller alla mejl som skickats. Med `Assert.Empty(fakeEmailProvider.SentEmails)` kan du kontrollera att inget mejl skickades.

Lite tips för de olika funktionaliteterna:

1. För att kontrollera om en e-postadress är registrerad, skapa ett nytt interface `IUserRepository` med en metod `bool IsEmailRegistered(string email)`, samt en metod för att lägga till en användare: `void AddUser(string email, string password)`. Använd sedan detta interface i PasswordResetService för att kontrollera om e-postadressen är registrerad. Gör sedan en fejkad implementation av detta i dina tester. Kan vara supersimpel! Spara bara e-postadresserna i en lista eller något.
2. Denna går att göra på lite olika sätt, men ett sätt är att låta PasswordResetService använda ett interface till en klass som håller reda på hur många begäranden som gjorts för varje e-postadress. Skapa ett interface `IResetRequestLog` med två metoder: `int GetRequestCount(string email)` som svarar på hur många begäranden som registrerats för adressen, och `void RegisterRequest(string email)` som PasswordResetService anropar när ett mejl faktiskt har skickats. Gör sedan en fejkad implementation i dina tester som bara räknar, t.ex. med en `Dictionary<string, int>`. Själva regeln (högst tre) ska ligga i PasswordResetService, inte i fejken. Tänk på testfall som: den tredje begäran går igenom, den fjärde nekas, och begäranden för en adress påverkar inte en annan.
3. I nuläget sparas den genererade token inte någonstans, den mejlas bara iväg. För att kunna kontrollera att en token är giltig för en viss e-postadress behöver den sparas, så det kan vara bra att börja med ett interface för det, t.ex. `ITokenStore` med metoder för att spara en token för en e-postadress och för att kontrollera om en token är giltig.

## Del 2: Analysera testbarheten i Videoteket

**Fråga 1:**
Identifierade du någon del av koden i Videoteket som direkt gick att testa? Vilken/vilka och varför?

**Fråga 2:**
Identifierade du någon del av koden i Videoteket som var svår eller omöjlig att testa? Vilken/vilka och varför?

**Fråga 3:**
Om du identifierade delar som var svåra eller omöjliga att testa, hur skulle du kunna ändra koden för att göra den mer testbar?

**Fråga 4:**
Ändrade du någon kod i Videoteket för att göra den testbar? I så fall, vad ändrade du och hur påverkade det testbarheten?
