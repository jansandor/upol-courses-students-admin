using Microsoft.EntityFrameworkCore.Migrations;

namespace cv8_mvc.Migrations
{
    public partial class RebuildAndInsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                columns: new[] { "CourseName", "Description" },
                values: new object[] { "Paradigmata programování 4", "Znalosti nástrojů a technik paralelního programování patří v současné době, vzhledem k vývoji hardware (vícejádrové procesory, stovky procesorů na grafických kartách použitelných pro výpočty), k základním požadavkům kladeným na kvalitního programátora. V kurzu studenti poznají jak výhody tak i problémy vznikající u paralelních programů se sdílenou pamětí, na klasických synchronizačních problémech i na úlohách z praxe, a naučí se je řešit pomocí metod synchronizace. Programuje se v jazycích C/C# pomocí rozhraní poskytovaných operačními systémy a také v jazyce Common Lisp, ve kterém jsou představena rozšíření pro paralelní programování, která se v poslední době dostávají do moderních programovacích jazyků." });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                columns: new[] { "CourseName", "Description" },
                values: new object[] { "Databázové systémy 1", "Úvod do DBS. Pojmy, data a jejich abstraktní modely. Architektura DBS. Modely DBS.   Relační model DBS, jeho vlastnosti, relační struktura dat, jazyk relačního DBS. Úvod do jazyka SQL. SQL, vytvoření a naplnění tabulky, dotazy (s podmínkami, sloupcové funkce).   Agregace, vnořené dotazy, manipulace s daty. Referenční integrita, integritní omezení, primární a sekundární klíč.   Spojení tabulek. Cizí klíč. Modifikace struktury tabulky. Množinové operace, kvantifikátory.   Analýza a návrh relační DB. Konceptuální modelování. ER model. Transformace do relačního modelu. Konstrukce složitějších dotazů.   Další prvky relačních DBS a SQL. Tranzitivní uzávěr tabulky. Pohledy, triggery a indexy. Spolupráce SQL s jinými jazyky. Základy administrace relačních DBS.   Transakční zpracování dat. Základní principy transakčního zpracování. Ochrana proti porušení konzistence dat. Paralelní zpracování transakcí. Paralelní zpracování transakcí, uzamykací protokoly, uváznutí (deadlock), dvoufázový protokol, časová razítka.   Teoretické základy relačních DBS. Formalizace tabulky, relační algebra, relační logika a kalkuly, dotazovací systémy.   Funkční závislosti, Armstrongovy axiomy, uzávěr, pokrytí.   Normální formy. První, druhá a třetí normální forma. Boyce-Coddova normální forma. Normalizace dekompozicí relačních schémat." });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3,
                columns: new[] { "CourseName", "Description" },
                values: new object[] { "Operační systémy 1", "Probírána je celková struktura a principy fungování OS a jeho jednotlivých součástí. Konkrétní způsoby řešení některých úkolů OS a technologie použité v moderních OS jsou ukázány na OS Microsoft Windows NT a GNU/Linux (jako zástupce unixových OS). Obsahem cvičení je úvod do programování v jazyce C a v jazyce symbolických adres (assembler), ve kterém jsou implementovány kritické součásti OS závislé na hardware.  Probíraná témata: John von Neumannova architektura, CPU, strojové instrukce a jejich vykonávání, programování v assembleru. Řízení výpočtu, volání funkcí, přerušení. Operační paměť, zobrazení informací v operační paměti, cache paměť. Funkce a význam operačních systémů, historický přehled. Správa procesů a procesoru, proces a jeho životní cyklus, přidělování procesoru, procesy a vlákna. Synchronizace procesů a vláken, aktivní a pasivní čekání. Implementace v OS Linux a Windows." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                columns: new[] { "CourseName", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                columns: new[] { "CourseName", "Description" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3,
                columns: new[] { "CourseName", "Description" },
                values: new object[] { null, null });
        }
    }
}
