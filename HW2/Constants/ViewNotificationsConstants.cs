using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewLayer.Constants
{
    public static class ViewNotificationsConstants
    {
        public static readonly string NewGameInfo = "Vítám vás ve hře šachu.\nDoufám, že si hru užijete stejně jako já její programování.\nPro pokračování stiskněte jakékoliv tlačítko.";
        public static readonly string NewRoundInfo = "Začalo nové kolo.";
        public static readonly string CurrentPlayerInfo = "Na tahu je hráč: ";
        public static readonly string CurrentRoundInfo = "Kolo: ";
        public static readonly string SelectPiece = "Prosím vyberte figuru se kterou chcete táhnout.";
        public static readonly string SelectMove = "Prosím vyberte pozici kam chcete táhnout.";

        //Erorrs
        public static readonly string NullError = "Zadejte hodnotu pozice v libovolném pořadí.";
        public static readonly string TooLongError = "Zadali jste nevalidní pozici. Pozice obsahovala znaky navíc.";
        public static readonly string TooShortError = "Zadali jste nevalidní pozici. Pozice neobsahovala dostatek znaků.";
        public static readonly string BadCombinationError = "Zadaná hodnota neobsahuje číslo, nebo znak.";
        public static readonly string InvalidValuesError = "Číslo, nebo písmeno přesahuje maximální hodnotu hrací desky.";
        public static readonly string InvalidPiece = "Na vybraném poli se nenachází žádná figura.";
        public static readonly string InvalidMove = "Takto s figurou není možné hýbat.";
        public static readonly string SquareOccupied = "Na vybraném čtverci se nachází jiná figura.";
        public static readonly string InvalidTarget = "Vybrané pole není validní cíl pro vybranou figuru.";
        public static readonly string ThreatenedPosition = "Cílová pozice je ohrožována nepřátelskou figurou.";
    }
}
