//Ukol - Obratte poradi stringu
string palindrom = "Kuna nese nanuk";
var reversed = new string(palindrom.Reverse().ToArray());
Console.WriteLine(reversed);

//Ukol - Napiste funkci, ktera umi detekovat, ze se jedna o palindrom (zatim jen u slov) a pak z pole vypiste jen palindromy
string[] slova = {"kajak", "program", "rotor", "Czechitas", "madam", "Jarda", "radar", "nepotopen"};
slova.Where(IsPalindrome).ToList().ForEach(Console.WriteLine);

//Ukol - opravte v tomto textu omylem zapnuty Caps Lock
string capsLock = "jAK mICROSCOFT wORD POZNA ZAPNUTY cAPSLOCK";
var fixedText = new string(capsLock.Select(ToggleCase).ToArray());
Console.WriteLine(fixedText);

//Ukol - rozsifrujte tuto zpravu - text byl zasifrovan tak, ze jsme kazde pismeno posunuli o jedno doprava: 'a' -> 'b'.
string sifra = "Wzcpsob!qsbdf!.!hsbuvmvkj!b!ktfn!ob!Ufcf!qztoz";
var decrypted = new string(sifra.Select(c => ShiftChar(c, -1)).ToArray());
Console.WriteLine(decrypted);

Console.ReadLine();

static bool IsPalindrome(string str) => str.Equals(new string(str.Reverse().ToArray()), StringComparison.Ordinal);
static char ToggleCase(char c) => char.IsLower(c) ? char.ToUpperInvariant(c) : char.ToLower(c);
static char ShiftChar(char c, int shiftOffset) => (char)(c+shiftOffset);