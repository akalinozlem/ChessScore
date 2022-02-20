using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessScore
{
    internal class Score
    {

        /*
         * Bir taşın tehdit altında olup olmadığını kontrol eder.
         * Taş tehdit altında değilse kendi puanını, tehdit altındaysa puanının yarısını döner.
         */
        public static double FinalScore(string element, int i, int j, string[,] board)
        {

            double score = 0, finalScore = 0;

            string opponent, boardElement; //opponent: rakibin renk bilgisini; boardElement: tehdit eden taş bilgisini tutar.

            if (element.Contains("b"))
            {
                opponent = "s";
                element = element.Replace("b", "");
            }
            else
            {
                opponent = "b";
                if (!element.Equals("ss"))
                    element = element.Replace("s", "");
                else
                    element = "s";
            }

            // Taşların puan tablosu
            switch (element)
            {
                case "p":
                    score = 1;
                    break;
                case "a":
                    score = 3;
                    break;
                case "f":
                    score = 3;
                    break;
                case "k":
                    score = 5;
                    break;
                case "v":
                    score = 9;
                    break;
                case "s":
                    score = 100;
                    break;
                default:
                    break;
            }

            if (opponent.Equals("b"))
                element += "s";
            else
                element += "b";

            //Kale tarafından tehdit kontrolü
            boardElement = "k" + opponent;
            finalScore = Rook.CheckRook(element, boardElement, i, j, score, board);
            if ((score - finalScore) > 0.0000001)
                return finalScore;


            //Fil tarafından tehdit kontrolü
            boardElement = "f" + opponent;
            finalScore = Bishop.CheckBishop(element, boardElement, i, j, score, board);
            if ((score - finalScore) > 0.0000001)
                return finalScore;

            //Vezir tarafından tehdit kontrolü
            boardElement = "v" + opponent;
            finalScore = Bishop.CheckBishop(element, boardElement, i, j, score, board);
            if ((score - finalScore) > 0.0000001)
                return finalScore;

            finalScore = Rook.CheckRook(element, boardElement, i, j, score, board);
            if ((score - finalScore) > 0.0000001)
                return finalScore;

            //Kral tarafından tehdit kontrolü
            boardElement = "s" + opponent;
            finalScore = King.CheckKing(i, j, boardElement, score, board);
            if ((score - finalScore) > 0.0000001)
                return finalScore;

            //Piyon tarafından tehdit kontrolü
            boardElement = "p" + opponent;
            finalScore = Pawn.CheckPawn(element, boardElement, i, j, score, board);
            if ((score - finalScore) > 0.0000001)
                return finalScore;

            //At tarafından tehdit kontrolü
            boardElement = "a" + opponent;
            finalScore = Knight.CheckKnight(boardElement, i, j, score, board);
            if ((score - finalScore) > 0.0000001)
                return finalScore;


            return finalScore;
        }
    }
}
