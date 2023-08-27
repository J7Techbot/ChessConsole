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
        public static readonly string TooLongError = "Zadaná hodnota obsahovala znaky navíc.";
        public static readonly string TooShortError = "Zadaná hodnota neobsahovala dostatek znaků.";
        public static readonly string BadCombinationError = "Zadaná hodnota neobsahuje číslo, nebo znak.";
        public static readonly string InvalidValuesError = "Zadaná hodnota přesahuje maximální hodnotu hrací desky.";
        public static readonly string InvalidPiece = "Na vybraném poli se nenachází žádná figura.";
        public static readonly string InvalidMove = "Neplatný pohyb.";
        public static readonly string SquareOccupied = "Na vybraném čtverci se nachází jiná figura.";
        public static readonly string InvalidTarget = "Nelze cílit na vlastní figury.";
        public static readonly string ThreatenedPosition = "Cílová pozice je ohrožována nepřátelskou figurou.";

        //Game
        public static readonly string Check = "Král je v ohrožení!";
    }
}
