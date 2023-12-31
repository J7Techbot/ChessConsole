﻿namespace ViewLayer.Constants
{
    /// <summary>
    /// It contains all the texts that can be displayed on the user interface.
    /// </summary>
    public static class ViewNotificationsConstants
    {
        //Infos
        public static readonly string NewGameInfo = "Vítám vás ve hře šachu.\n\nPro pokračování stiskněte jakékoliv tlačítko.";
        public static readonly string NewRoundInfo = "Začalo nové kolo.";
        public static readonly string CurrentPlayerInfo = "Na tahu je hráč: ";
        public static readonly string CurrentRoundInfo = "Kolo: ";
        public static readonly string SelectPieceInfo = "Prosím vyberte figuru se kterou chcete táhnout.\nPro ukončení hry zadejte [end]";
        public static readonly string SelectMoveInfo = "Prosím vyberte pozici kam chcete táhnout.\nPro ukončení hry zadejte [end]";

        //Erorrs
        public static readonly string NullError = "Zadejte hodnotu pozice v libovolném pořadí.";
        public static readonly string TooLongError = "Zadaná hodnota obsahovala znaky navíc.";
        public static readonly string TooShortError = "Zadaná hodnota neobsahovala dostatek znaků.";
        public static readonly string BadCombinationError = "Zadaná hodnota neobsahuje číslo, nebo znak.";
        public static readonly string InvalidValuesError = "Zadaná hodnota přesahuje maximální hodnotu hrací desky.";
        public static readonly string InvalidPieceError = "Na vybraném poli se nenachází žádná figura.";
        public static readonly string InvalidColorError = "V tomto kole nelze táhnout figurou této barvy.";
        public static readonly string InvalidMoveError = "Neplatný pohyb.";
        public static readonly string SquareOccupiedError = "Na vybraném čtverci se nachází jiná figura.";
        public static readonly string InvalidTargetError = "Nelze cílit na vlastní figury.";
        public static readonly string ThreatenedPositionError = "Cílová pozice je ohrožována nepřátelskou figurou.";

        //Game
        public static readonly string Check = "Král je v ohrožení!";
        public static readonly string MustProtectKing = "Tento tah zahrát nelze, král zůstane v ohrožení.";
        public static readonly string KingExposed = "Tento tah zahrát nelze, bude odkryt král.";
        public static readonly string GameOver = "Zvítězil hráč : ";
    }
}
